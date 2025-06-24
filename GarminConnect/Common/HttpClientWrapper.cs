using OAuth1.a;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using OAuth1._0;

namespace GarminConnect.Common
{
    public class HttpClientWrapper
    {
        // 创建 CookieContainer 用于自动管理 Cookie
        private static readonly CookieContainer _cookieContainer = new();

        private static readonly Regex CSRF_RE = new("name=\"_csrf\"\\s+value=\"(.+?)\"", RegexOptions.Compiled);
        private static readonly Regex TICKET_RE = new("ticket=([^\"]+)\"", RegexOptions.Compiled);
        private static readonly Regex ACCOUNT_LOCKED_RE = new("var statuss*=s*\"([^\"]*)\"", RegexOptions.Compiled);
        private static readonly Regex PAGE_TITLE_RE = new("<title>([^<]*)</title>", RegexOptions.Compiled);

        private const string USER_AGENT_CONNECTMOBILE = "com.garmin.android.apps.connectmobile";
        private const string USER_AGENT_BROWSER = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/117.0.0.0 Safari/537.36";

        private const string OAUTH_CONSUMER_URL = "https://thegarth.s3.amazonaws.com/oauth_consumer.json";

        private readonly HttpClient _client;
        private readonly UrlClass _url;
        public OAuth1Token _oauth1Token = null!;
        public OAuth2Token _oauth2Token = null!;
        public OauthConsumer _oauthConsumer = default!;

        public HttpClientWrapper(UrlClass url)
        {
            _url = url;
            _client = new HttpClient(new HttpClientHandler() { UseCookies = true, CookieContainer = _cookieContainer, AllowAutoRedirect = true });
            _client.DefaultRequestHeaders.UserAgent.ParseAdd(USER_AGENT_BROWSER);
        }

        // 获取 OAuth Consumer
        public async Task FetchOauthConsumerAsync()
        {
            var resp = await _client.GetStringAsync(OAUTH_CONSUMER_URL);
            var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(resp);
            _oauthConsumer = new OauthConsumer
            {
                Key = obj?["consumer_key"],
                Secret = obj?["consumer_secret"]
            };
        }

        // Fix for CS8603: Possible null reference return  
        public async Task<T> GetAsync<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (_oauth2Token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _oauth2Token.AccessToken);
            }
            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                HandleHttpError(response);
            }
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result == null ? throw new InvalidOperationException("Deserialization returned null.") : result;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<byte[]> Download(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (_oauth2Token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _oauth2Token.AccessToken);
            }
            // 发送 GET 请求
            using HttpResponseMessage response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                HandleHttpError(response);
            }
            response.EnsureSuccessStatusCode();

            // 读取响应流
            byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
            return fileBytes;
        }

        // POST 请求
        public async Task<T> PostAsync<T>(string url, HttpContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (_oauth2Token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _oauth2Token.AccessToken);
            }
            request.Content = content;
            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                HandleHttpError(response);
            }
            var respContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(respContent);
            return result == null ? throw new InvalidOperationException("Deserialization returned null.") : result;
        }

        // DELETE 请求（通过 POST + X-Http-Method-Override）
        public async Task<T> DeleteAsync<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (_oauth2Token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _oauth2Token.AccessToken);
            }
            request.Headers.Add("X-Http-Method-Override", "DELETE");
            request.Content = new StringContent(string.Empty);
            var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                HandleHttpError(response);
            }
            var respContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(respContent);
            return result == null ? throw new InvalidOperationException("Deserialization returned null.") : result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<HttpClientWrapper> LoginAsync(string username, string password)
        {
            await FetchOauthConsumerAsync();

            var ticket = await GetLoginTicketAsync(username, password);

            await GetOauth1TokenAsync(ticket);

            await ExchangeAsync();

            return this;
        }

        /// <summary>
        /// 获取登录票据
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> GetLoginTicketAsync(string username, string password)
        {
            // Step1: Set cookie
            var step1Params = new Dictionary<string, string>
            {
                { "clientId", "GarminConnect" },
                { "locale", "en" },
                { "service", _url.GC_MODERN }
            };
            var step1Url = $"{_url.GARMIN_SSO_EMBED}?{BuildQueryString(step1Params)}";
            await _client.GetAsync(step1Url);

            // Step2: Get _csrf
            var step2Params = new Dictionary<string, string>
            {
                { "id", "gauth-widget" },
                { "embedWidget", "true" },
                { "locale", "en" },
                { "gauthHost", _url.GARMIN_SSO_EMBED }
            };
            var step2Url = $"{_url.SIGNIN_URL}?{BuildQueryString(step2Params)}";
            var step2Result = await _client.GetStringAsync(step2Url);
            var csrfMatch = CSRF_RE.Match(step2Result);
            if (!csrfMatch.Success)
                throw new Exception("login - csrf not found");
            var csrf_token = csrfMatch.Groups[1].Value;

            // Step3: Get ticket
            var signinParams = new Dictionary<string, string>
            {
                { "id", "gauth-widget" },
                { "embedWidget", "true" },
                { "clientId", "GarminConnect" },
                { "locale", "en" },
                { "gauthHost", _url.GARMIN_SSO_EMBED },
                { "service", _url.GARMIN_SSO_EMBED },
                { "source", _url.GARMIN_SSO_EMBED },
                { "redirectAfterAccountLoginUrl", _url.GARMIN_SSO_EMBED },
                { "redirectAfterAccountCreationUrl", _url.GARMIN_SSO_EMBED }
            }; 
            var step3Url = $"{_url.SIGNIN_URL}?{BuildQueryString(signinParams)}";

            var formData = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("embed", "true"),
                new KeyValuePair<string, string>("_csrf", csrf_token)
            ]);

            var request = new HttpRequestMessage(HttpMethod.Post, step3Url)
            {
                Content = formData
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            request.Headers.Add("Dnt", "1");
            request.Headers.Add("Origin", _url.GARMIN_SSO_ORIGIN);
            request.Headers.UserAgent.ParseAdd(USER_AGENT_BROWSER);

            var response = await _client.SendAsync(request);

            var step3Result = await response.Content.ReadAsStringAsync();

            HandleAccountLocked(step3Result);
            HandlePageTitle(step3Result);

            var ticketMatch = TICKET_RE.Match(step3Result);
            if (!ticketMatch.Success)
                throw new Exception("login failed (Ticket not found or MFA), please check username and password");

            return ticketMatch.Groups[1].Value;
        }

        /// <summary>
        /// 获取 Oauth1 令牌
        /// </summary>
        /// <param name="ticket">登录票据</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        private async Task GetOauth1TokenAsync(string ticket)
        {
            if (_oauthConsumer == null || string.IsNullOrEmpty(_oauthConsumer.Key) || string.IsNullOrEmpty(_oauthConsumer.Secret))
                throw new Exception("Invalid OAUTH_CONSUMER: Key or Secret is null or empty.");

            var parameters = new Dictionary<string, string>
           {
               { "ticket", ticket },
               { "login-url", _url.GARMIN_SSO_EMBED },
               { "accepts-mfa-tokens", "true" }
           };
            var url = $"{_url.OAUTH_URL}/preauthorized?{BuildQueryString_(parameters)}";

            var oauthClient = OAuthRequest.ForRequestToken(_oauthConsumer.Key, _oauthConsumer.Secret);
            oauthClient.RequestUrl = url;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, oauthClient.RequestUrl);
            httpRequestMessage.Headers.Add("User-Agent", USER_AGENT_CONNECTMOBILE);
            httpRequestMessage.Headers.Add("Authorization", oauthClient.GetAuthorizationHeader());
            var response = await _client.SendAsync(httpRequestMessage);
            var responseStr = await response.Content.ReadAsStringAsync();
            var tokenDict = HttpUtility.ParseQueryString(responseStr);
            var oauthToken = tokenDict["oauth_token"] ?? throw new InvalidOperationException("OauthToken is null.");
            var oauthTokenSecret = tokenDict["oauth_token_secret"] ?? throw new InvalidOperationException("OauthTokenSecret is null.");

            _oauth1Token = new OAuth1Token
            {
                OAuthToken = oauthToken,
                OAuthTokenSecret = oauthTokenSecret
            };
        }

        /// <summary>
        /// 交换 Oauth1 令牌为 Oauth2 令牌
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task ExchangeAsync()
        {
            // Validate _oauthConsumer and its properties to ensure they are not null
            if (_oauthConsumer == null || string.IsNullOrEmpty(_oauthConsumer.Key) || string.IsNullOrEmpty(_oauthConsumer.Secret))
            {
                throw new InvalidOperationException("Invalid OAUTH_CONSUMER: Key or Secret is null or empty.");
            }

            // Validate oauth1 and its Token property to ensure they are not null
            if (_oauth1Token == null || string.IsNullOrEmpty(_oauth1Token.OAuthToken) || string.IsNullOrEmpty(_oauth1Token.OAuthTokenSecret))
            {
                throw new InvalidOperationException("Invalid Oauth1: Token or its properties are null or empty.");
            }

            var oauth2Client = OAuthRequest.ForProtectedResource(
                "POST",
                _oauthConsumer.Key, // Guaranteed non-null after validation
                _oauthConsumer.Secret, // Guaranteed non-null after validation
                _oauth1Token.OAuthToken, // Guaranteed non-null after validation
                _oauth1Token.OAuthTokenSecret // Guaranteed non-null after validation
            );

            oauth2Client.RequestUrl = $"{_url.OAUTH_URL}/exchange/user/2.0";

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, oauth2Client.RequestUrl);
            httpRequestMessage.Headers.Add("User-Agent", USER_AGENT_CONNECTMOBILE);
            httpRequestMessage.Headers.Add("Authorization", oauth2Client.GetAuthorizationHeader());

            httpRequestMessage.Content = new FormUrlEncodedContent([new KeyValuePair<string, string>()]);
            var response = await _client.SendAsync(httpRequestMessage);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            _oauth2Token = JsonConvert.DeserializeObject<OAuth2Token>(responseContent) ?? throw new InvalidOperationException("Deserialization returned null for Oauth2Token.");
        }

        private static string BuildQueryString(Dictionary<string, string> parameters)
        {
            var list = new List<string>();
            foreach (var kv in parameters)
            {
                list.Add($"{HttpUtility.UrlEncode(kv.Key)}={HttpUtility.UrlEncode(kv.Value)}");
            }
            return string.Join("&", list);
        }

        private static string BuildQueryString_(Dictionary<string, string> parameters)
        {
            var list = new List<string>();
            foreach (var kv in parameters)
            {
                list.Add($"{kv.Key}={kv.Value}");
            }
            return string.Join("&", list);
        }

        /// <summary>
        /// 处理 HTTP 错误
        /// </summary>
        /// <param name="response"></param>
        /// <exception cref="Exception"></exception>
        private static void HandleHttpError(HttpResponseMessage response)
        {
            var status = (int)response.StatusCode;
            var statusText = response.ReasonPhrase;
            var data = response.Content.ReadAsStringAsync().Result;
            var msg = $"ERROR: ({status}), {statusText}, {data}";
            Console.Error.WriteLine(msg);
            throw new Exception(msg);
        }

        /// <summary>
        /// 处理页面标题
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <exception cref="Exception"></exception>
        private static void HandlePageTitle(string htmlStr)
        {
            var match = PAGE_TITLE_RE.Match(htmlStr);
            if (match.Success)
            {
                var title = match.Groups[1].Value;
                Console.WriteLine($"login page title: {title}");
                if (title.Contains("Update Phone Number"))
                {
                    throw new Exception("login failed (Update Phone number), please update your phone number, currently I don't know where to update it");
                }
            }
        }

        /// <summary>
        /// 处理账号锁定
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <exception cref="Exception"></exception>
        private static void HandleAccountLocked(string htmlStr)
        {
            var match = ACCOUNT_LOCKED_RE.Match(htmlStr);
            if (match.Success)
            {
                var msg = match.Groups[1].Value;
                Console.Error.WriteLine(msg);
                throw new Exception("login failed (AccountLocked), please open connect web page to unlock your account");
            }
        }
    }
}
