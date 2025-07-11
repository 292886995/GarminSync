﻿using System.Collections.Specialized;
using System.Text;

namespace OAuth1.a;

/// <summary>
/// 符合 OAuth 1.0a 规范的请求包装器
/// </summary>
/// <seealso href="http://oauth.net/"/>
public class OAuthRequest
{
    /// <summary>
    /// 签名类型
    /// </summary>
    public virtual OAuthSignatureMethod SignatureMethod { get; set; }

    /// <summary>
    /// 签名转义处理方式
    /// </summary>
    public virtual OAuthSignatureTreatment SignatureTreatment { get; set; }

    /// <summary>
    /// 请求类型
    /// </summary>
    public virtual OAuthRequestType Type { get; set; }

    public virtual string Method { get; set; }
    public virtual string Realm { get; set; }
    public virtual string ConsumerKey { get; set; }
    public virtual string ConsumerSecret { get; set; }
    public virtual string Token { get; set; }
    public virtual string TokenSecret { get; set; }
    public virtual string Verifier { get; set; }
    public virtual string ClientUsername { get; set; }
    public virtual string ClientPassword { get; set; }
    public virtual string CallbackUrl { get; set; }
    public virtual string Version { get; set; }
    public virtual string SessionHandle { get; set; }

    /// <seealso cref="http://oauth.net/core/1.0#request_urls"/>
    public virtual string RequestUrl { get; set; }

    #region Authorization Header

#if !WINRT
    public string GetAuthorizationHeader(NameValueCollection parameters)
    {
        var collection = new WebParameterCollection(parameters);

        return GetAuthorizationHeader(collection);
    }
#endif

    public string GetAuthorizationHeader(IDictionary<string, string> parameters)
    {
        var collection = new WebParameterCollection(parameters);

        return GetAuthorizationHeader(collection);
    }

    public string GetAuthorizationHeader()
    {
        var collection = new WebParameterCollection(0);

        return GetAuthorizationHeader(collection);
    }

    public string GetAuthorizationHeader(WebParameterCollection parameters)
    {
        switch (Type)
        {
            case OAuthRequestType.RequestToken:
                ValidateRequestState();
                return GetSignatureAuthorizationHeader(parameters);
            case OAuthRequestType.AccessToken:
                ValidateAccessRequestState();
                return GetSignatureAuthorizationHeader(parameters);
            case OAuthRequestType.ProtectedResource:
                ValidateProtectedResourceState();
                return GetSignatureAuthorizationHeader(parameters);
            case OAuthRequestType.ClientAuthentication:
                ValidateClientAuthAccessRequestState();
                return GetClientSignatureAuthorizationHeader(parameters);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private string GetSignatureAuthorizationHeader(WebParameterCollection parameters)
    {
        var signature = GetNewSignature(parameters);

        parameters.Add("oauth_signature", signature);

        return WriteAuthorizationHeader(parameters);
    }

    private string GetClientSignatureAuthorizationHeader(WebParameterCollection parameters)
    {
        var signature = GetNewSignatureXAuth(parameters);

        parameters.Add("oauth_signature", signature);

        return WriteAuthorizationHeader(parameters);
    }

    private string WriteAuthorizationHeader(WebParameterCollection parameters)
    {
        var sb = new StringBuilder("OAuth ");

        if (!IsNullOrBlank(Realm))
        {
            sb.AppendFormat("realm=\"{0}\",", OAuthTools.UrlEncodeRelaxed(Realm));
        }

        parameters.Sort((l, r) => l.Name.CompareTo(r.Name));

        if (Type == OAuthRequestType.ProtectedResource)
        {
            foreach (var parameter in parameters.Where(parameter =>
                         !IsNullOrBlank(parameter.Name) &&
                         !IsNullOrBlank(parameter.Value) &&
                         (parameter.Name.StartsWith("oauth_") || parameter.Name.StartsWith("x_auth_")) ||
                         parameter.Name == "oauth_token" && parameter.Value != null))
            {
                sb.Append($"{parameter.Name}=\"{parameter.Value}\",");
            }
        }
        else
        {
            foreach (var parameter in parameters.Where(parameter =>
                         !IsNullOrBlank(parameter.Name) &&
                         !IsNullOrBlank(parameter.Value) &&
                         (parameter.Name.StartsWith("oauth_") || parameter.Name.StartsWith("x_auth_"))))
            {
                sb.Append($"{parameter.Name}=\"{parameter.Value}\",");
            }
        }

        sb.Remove(sb.Length - 1, 1);

        var authorization = sb.ToString();
        return authorization;
    }

    #endregion

    #region Authorization Query

#if !WINRT
    public string GetAuthorizationQuery(NameValueCollection parameters)
    {
        var collection = new WebParameterCollection(parameters);

        return GetAuthorizationQuery(collection);
    }
#endif

    public string GetAuthorizationQuery(IDictionary<string, string> parameters)
    {
        var collection = new WebParameterCollection(parameters);

        return GetAuthorizationQuery(collection);
    }

    public string GetAuthorizationQuery()
    {
        var collection = new WebParameterCollection(0);

        return GetAuthorizationQuery(collection);
    }

    private string GetAuthorizationQuery(WebParameterCollection parameters)
    {
        switch (Type)
        {
            case OAuthRequestType.RequestToken:
                ValidateRequestState();
                return GetSignatureAuthorizationQuery(parameters);
            case OAuthRequestType.AccessToken:
                ValidateAccessRequestState();
                return GetSignatureAuthorizationQuery(parameters);
            case OAuthRequestType.ProtectedResource:
                ValidateProtectedResourceState();
                return GetSignatureAuthorizationQuery(parameters);
            case OAuthRequestType.ClientAuthentication:
                ValidateClientAuthAccessRequestState();
                return GetClientSignatureAuthorizationQuery(parameters);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private string GetSignatureAuthorizationQuery(WebParameterCollection parameters)
    {
        var signature = GetNewSignature(parameters);

        parameters.Add("oauth_signature", signature);

        return WriteAuthorizationQuery(parameters);
    }

    private string GetClientSignatureAuthorizationQuery(WebParameterCollection parameters)
    {
        var signature = GetNewSignatureXAuth(parameters);

        parameters.Add("oauth_signature", signature);

        return WriteAuthorizationQuery(parameters);
    }

    private static string WriteAuthorizationQuery(WebParameterCollection parameters)
    {
        var sb = new StringBuilder();

        parameters.Sort((l, r) => l.Name.CompareTo(r.Name));

        var count = 0;

        foreach (var parameter in parameters.Where(parameter =>
                     !IsNullOrBlank(parameter.Name) &&
                     !IsNullOrBlank(parameter.Value) &&
                     (parameter.Name.StartsWith("oauth_") || parameter.Name.StartsWith("x_auth_"))))
        {
            count++;
            var format = count < parameters.Count ? "{0}={1}&" : "{0}={1}";
            sb.AppendFormat(format, parameter.Name, parameter.Value);
        }

        var authorization = sb.ToString();
        return authorization;
    }

    #endregion

    private string GetNewSignature(WebParameterCollection parameters)
    {
        var timestamp = OAuthTools.GetTimestamp();

        var nonce = OAuthTools.GetNonce();

        AddAuthParameters(parameters, timestamp, nonce);

        var signatureBase = OAuthTools.ConcatenateRequestElements(Method.ToUpperInvariant(), RequestUrl, parameters);

        var signature = OAuthTools.GetSignature(SignatureMethod, SignatureTreatment, signatureBase, ConsumerSecret, TokenSecret);

        return signature;
    }

    private string GetNewSignatureXAuth(WebParameterCollection parameters)
    {
        var timestamp = OAuthTools.GetTimestamp();

        var nonce = OAuthTools.GetNonce();

        AddXAuthParameters(parameters, timestamp, nonce);

        var signatureBase = OAuthTools.ConcatenateRequestElements(Method.ToUpperInvariant(), RequestUrl, parameters);

        var signature = OAuthTools.GetSignature(SignatureMethod, SignatureTreatment, signatureBase, ConsumerSecret, TokenSecret);

        return signature;
    }

    #region Static Helpers

    public static OAuthRequest ForRequestToken(string consumerKey, string consumerSecret, OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.HmacSha1)
    {
        var credentials = new OAuthRequest
        {
            Method = "GET",
            Type = OAuthRequestType.RequestToken,
            SignatureMethod = oAuthSignatureMethod,
            SignatureTreatment = OAuthSignatureTreatment.Escaped,
            ConsumerKey = consumerKey,
            ConsumerSecret = consumerSecret
        };
        return credentials;
    }

    public static OAuthRequest ForRequestToken(string consumerKey, string consumerSecret, string callbackUrl, OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.HmacSha1)
    {
        var credentials = ForRequestToken(consumerKey, consumerSecret, null, oAuthSignatureMethod: oAuthSignatureMethod);
        credentials.CallbackUrl = callbackUrl;
        return credentials;
    }

    public static OAuthRequest ForAccessToken(string consumerKey, string consumerSecret, string requestToken, string requestTokenSecret, OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.HmacSha1)
    {
        var credentials = new OAuthRequest
        {
            Method = "GET",
            Type = OAuthRequestType.AccessToken,
            SignatureMethod = oAuthSignatureMethod,
            SignatureTreatment = OAuthSignatureTreatment.Escaped,
            ConsumerKey = consumerKey,
            ConsumerSecret = consumerSecret,
            Token = requestToken,
            TokenSecret = requestTokenSecret
        };
        return credentials;
    }

    public static OAuthRequest ForAccessToken(string consumerKey, string consumerSecret, string requestToken, string requestTokenSecret, string verifier, OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.HmacSha1)
    {
        var credentials = ForAccessToken(consumerKey, consumerSecret, requestToken, requestTokenSecret, oAuthSignatureMethod);
        credentials.Verifier = verifier;
        return credentials;
    }

    public static OAuthRequest ForAccessTokenRefresh(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, string sessionHandle, OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.HmacSha1)
    {
        var credentials = ForAccessToken(consumerKey, consumerSecret, accessToken, accessTokenSecret, oAuthSignatureMethod);
        credentials.SessionHandle = sessionHandle;
        return credentials;
    }

    public static OAuthRequest ForAccessTokenRefresh(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, string sessionHandle, string verifier, OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.HmacSha1)
    {
        var credentials = ForAccessToken(consumerKey, consumerSecret, accessToken, accessTokenSecret, oAuthSignatureMethod);
        credentials.SessionHandle = sessionHandle;
        credentials.Verifier = verifier;
        return credentials;
    }

    public static OAuthRequest ForClientAuthentication(string consumerKey, string consumerSecret, string username, string password, OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.HmacSha1)
    {
        var credentials = new OAuthRequest
        {
            Method = "GET",
            Type = OAuthRequestType.ClientAuthentication,
            SignatureMethod = oAuthSignatureMethod,
            SignatureTreatment = OAuthSignatureTreatment.Escaped,
            ConsumerKey = consumerKey,
            ConsumerSecret = consumerSecret,
            ClientUsername = username,
            ClientPassword = password
        };

        return credentials;
    }

    public static OAuthRequest ForProtectedResource(string method, string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, OAuthSignatureMethod oAuthSignatureMethod = OAuthSignatureMethod.HmacSha1)
    {
        var credentials = new OAuthRequest
        {
            Method = method ?? "GET",
            Type = OAuthRequestType.ProtectedResource,
            SignatureMethod = oAuthSignatureMethod,
            SignatureTreatment = OAuthSignatureTreatment.Escaped,
            ConsumerKey = consumerKey,
            ConsumerSecret = consumerSecret,
            Token = accessToken,
            TokenSecret = accessTokenSecret
        };
        return credentials;
    }

    #endregion

    private void ValidateRequestState()
    {
        if (IsNullOrBlank(Method))
        {
            throw new ArgumentException("You must specify an HTTP method");
        }

        if (IsNullOrBlank(RequestUrl))
        {
            throw new ArgumentException("You must specify a request token URL");
        }

        if (IsNullOrBlank(ConsumerKey))
        {
            throw new ArgumentException("You must specify a consumer key");
        }

        if (IsNullOrBlank(ConsumerSecret))
        {
            throw new ArgumentException("You must specify a consumer secret");
        }
    }

    private void ValidateAccessRequestState()
    {
        if (IsNullOrBlank(Method))
        {
            throw new ArgumentException("You must specify an HTTP method");
        }

        if (IsNullOrBlank(RequestUrl))
        {
            throw new ArgumentException("You must specify an access token URL");
        }

        if (IsNullOrBlank(ConsumerKey))
        {
            throw new ArgumentException("You must specify a consumer key");
        }

        if (IsNullOrBlank(ConsumerSecret))
        {
            throw new ArgumentException("You must specify a consumer secret");
        }

        if (IsNullOrBlank(Token))
        {
            throw new ArgumentException("You must specify a token");
        }
    }

    private void ValidateClientAuthAccessRequestState()
    {
        if (IsNullOrBlank(Method))
        {
            throw new ArgumentException("You must specify an HTTP method");
        }

        if (IsNullOrBlank(RequestUrl))
        {
            throw new ArgumentException("You must specify an access token URL");
        }

        if (IsNullOrBlank(ConsumerKey))
        {
            throw new ArgumentException("You must specify a consumer key");
        }

        if (IsNullOrBlank(ConsumerSecret))
        {
            throw new ArgumentException("You must specify a consumer secret");
        }

        if (IsNullOrBlank(ClientUsername) || IsNullOrBlank(ClientPassword))
        {
            throw new ArgumentException("You must specify user credentials");
        }
    }

    private void ValidateProtectedResourceState()
    {
        if (IsNullOrBlank(Method))
        {
            throw new ArgumentException("You must specify an HTTP method");
        }

        if (IsNullOrBlank(ConsumerKey))
        {
            throw new ArgumentException("You must specify a consumer key");
        }

        if (IsNullOrBlank(ConsumerSecret))
        {
            throw new ArgumentException("You must specify a consumer secret");
        }
    }

    private void AddAuthParameters(ICollection<WebParameter> parameters, string timestamp, string nonce)
    {
        var authParameters = new WebParameterCollection
        {
            new WebParameter("oauth_consumer_key", ConsumerKey),
            new WebParameter("oauth_nonce", nonce),
            new WebParameter("oauth_signature_method", ToRequestValue(SignatureMethod)),
            new WebParameter("oauth_timestamp", timestamp),
            new WebParameter("oauth_version", Version ?? "1.0")
        };

        if (Type == OAuthRequestType.ProtectedResource)
        {
            if (Token != null) { authParameters.Add(new WebParameter("oauth_token", Token)); }
        }
        else
        {
            if (!IsNullOrBlank(Token)) { authParameters.Add(new WebParameter("oauth_token", Token)); }
        }

        if (!IsNullOrBlank(CallbackUrl))
        {
            authParameters.Add(new WebParameter("oauth_callback", CallbackUrl));
        }

        if (!IsNullOrBlank(Verifier))
        {
            authParameters.Add(new WebParameter("oauth_verifier", Verifier));
        }

        if (!IsNullOrBlank(SessionHandle))
        {
            authParameters.Add(new WebParameter("oauth_session_handle", SessionHandle));
        }

        foreach (var authParameter in authParameters)
        {
            parameters.Add(authParameter);
        }
    }

    private void AddXAuthParameters(ICollection<WebParameter> parameters, string timestamp, string nonce)
    {
        var authParameters = new WebParameterCollection
        {
            new WebParameter("x_auth_username", ClientUsername),
            new WebParameter("x_auth_password", ClientPassword),
            new WebParameter("x_auth_mode", "client_auth"),
            new WebParameter("oauth_consumer_key", ConsumerKey),
            new WebParameter("oauth_signature_method", ToRequestValue(SignatureMethod)),
            new WebParameter("oauth_timestamp", timestamp),
            new WebParameter("oauth_nonce", nonce),
            new WebParameter("oauth_version", Version ?? "1.0")
        };

        foreach (var authParameter in authParameters)
        {
            parameters.Add(authParameter);
        }
    }

    public static string ToRequestValue(OAuthSignatureMethod signatureMethod)
    {
        var value = signatureMethod.ToString().ToUpper();
        var shaIndex = value.IndexOf("SHA1");
        return shaIndex > -1 ? value.Insert(shaIndex, "-") : value;
    }

    private static bool IsNullOrBlank(string value)
    {
        return string.IsNullOrEmpty(value) || !string.IsNullOrEmpty(value) && value.Trim() == string.Empty;
    }
}