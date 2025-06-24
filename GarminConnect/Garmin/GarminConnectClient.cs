using GarminConnect.Common;
using GarminModels;
using Newtonsoft.Json;
using OAuth1._0;
using System.ComponentModel;
using System.Reflection;
using System.Web;

namespace GarminConnect.Garmin
{
    /// <summary>
    /// 佳明Connect客户端
    /// </summary>
    public class GarminConnectClient()
    {
        private readonly GCCredentials _credentials=default!;
        private readonly UrlClass _url = default!;
        private readonly HttpClientWrapper _httpClient = default!;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="credentials">凭证</param>
        /// <param name="domain">域名</param>
        /// <exception cref="ArgumentException"></exception>
        public GarminConnectClient(GCCredentials credentials, GarminDomain domain = GarminDomain.GarminCom) : this()
        {
            _credentials = credentials ?? throw new ArgumentException("Missing credentials");
            _url = new UrlClass(domain);
            _httpClient = new HttpClientWrapper(_url);
        }

        /// <summary>
        /// 登录
        /// </summary>
        public async Task LoginAsync()
        {
            if (string.IsNullOrEmpty(_credentials.Username))
                throw new ArgumentException("Username cannot be null or empty", nameof(_credentials.Username));

            if (string.IsNullOrEmpty(_credentials.Password))
                throw new ArgumentException("Password cannot be null or empty", nameof(_credentials.Password));

            _ = await _httpClient.LoginAsync(_credentials.Username, _credentials.Password);
        }

        /// <summary>
        /// 导出Token文件
        /// </summary>
        /// <param name="dirPath">导出地址</param>
        public void ExportTokenToFile(string dirPath)
        {
            FileHelper.CreateDirectory(dirPath);

            if (_httpClient._oauth1Token != null)
                File.WriteAllText(Path.Combine(dirPath, "oauth1_token.json"), JsonConvert.SerializeObject(_httpClient._oauth1Token));

            if (_httpClient._oauth2Token != null)
                File.WriteAllText(Path.Combine(dirPath, "oauth2_token.json"), JsonConvert.SerializeObject(_httpClient._oauth2Token));
        }

        /// <summary>
        /// 从文件加载Token
        /// </summary>
        /// <param name="dirPath">文件地址</param>
        /// <exception cref="Exception"></exception>
        public void LoadTokenByFile(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                throw new Exception("loadTokenByFile: Directory not found: " + dirPath);

            var oauth1Path = Path.Combine(dirPath, "oauth1_token.json");
            if (File.Exists(oauth1Path))
            {
                var oauth1Data = File.ReadAllText(oauth1Path);
                var oauth1Token = JsonConvert.DeserializeObject<OAuth1Token>(oauth1Data) ?? throw new Exception("LoadTokenByFile: Failed to deserialize Oauth1Token.");
                _httpClient._oauth1Token = oauth1Token;
            }

            var oauth2Path = Path.Combine(dirPath, "oauth2_token.json");
            if (File.Exists(oauth2Path))
            {
                var oauth2Data = File.ReadAllText(oauth2Path);
                var oauth2Token = JsonConvert.DeserializeObject<OAuth2Token>(oauth2Data) ?? throw new Exception("LoadTokenByFile: Failed to deserialize Oauth2Token.");
                _httpClient._oauth2Token = oauth2Token;
            }
        }

        /// <summary>
        /// 加载Token
        /// </summary>
        /// <param name="oauth1"></param>
        /// <param name="oauth2"></param>
        public void LoadToken(OAuth1Token oauth1, OAuth2Token oauth2)
        {
            _httpClient._oauth1Token = oauth1!;
            _httpClient._oauth2Token = oauth2!;
        }

        /// <summary>
        /// 获取用户设置
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<UserSettings> GetUserSettingsAsync()
        {
            return await _httpClient.GetAsync<UserSettings>(_url.USER_SETTINGS) ?? throw new Exception("GetUserSettingsAsync: Failed to deserialize.");
        }

        /// <summary>
        /// 获取用户资料
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<SocialProfile> GetUserProfileAsync()
        {
            return await _httpClient.GetAsync<SocialProfile>(_url.USER_PROFILE) ?? throw new Exception("GetUserProfileAsync: Failed to deserialize.");
        }

        /// <summary>
        /// 获取活动集合
        /// </summary>
        /// <param name="start">开始页</param>
        /// <param name="limit">条数</param>
        /// <param name="activityType">活动类型</param>
        /// <param name="activitySubType">子活动类型</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Activity>> GetActivitiesAsync(int start,int limit)//, ActivityType activityType, ActivitySubType activitySubType) 
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["start"] = start.ToString();
            query["limit"] = limit.ToString();
            return await _httpClient.GetAsync<List<Activity>>($"{_url.ACTIVITIES}?{query}") ?? throw new Exception("GetActivitiesAsync: Failed to deserialize.");
        }

        /// <summary>
        /// 获取活动
        /// </summary>
        /// <param name="activityId">活动ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Activity> GetActivityAsync(int activityId)
        {
            return await _httpClient.GetAsync<Activity>($"{_url.ACTIVITY}{activityId}") ?? throw new Exception("GetActivityAsync: Failed to deserialize.");
        }

        /// <summary>
        /// 获取活动总数
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CountActivities> GetCountActivitiesAsync()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["aggregation"] = "lifetime";
            query["startDate"] = "1970-01-01";
            query["endDate"] = DateTime.Now.ToString("yyyy-MM-dd");
            query["metric"] = "duration";
            return await _httpClient.GetAsync<CountActivities>($"{_url.STAT_ACTIVITIES}{query}") ?? throw new Exception("GetCountActivitiesAsync: Failed to deserialize.");
        }

        /// <summary>
        /// 下载活动文件
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="filePath"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DownloadOriginalActivityDataAsync(long activityId, string filePath,string format = "zip")
        {
            var detectedFormat = format.ToLower();
            var allowedFormats = new List<string> { "zip", "gpx", "tcx", "kml" };
            if (!allowedFormats.Contains(detectedFormat))
            {
                throw new Exception("downloadOriginalActivityData - Invalid format: " + format);
            }
            var url = detectedFormat switch
            {
                "zip" => $"{_url.DOWNLOAD_ZIP}{activityId}",
                "gpx" => $"{_url.DOWNLOAD_GPX}{activityId}",
                "tcx" => $"{_url.DOWNLOAD_TCX}{activityId}",
                "kml" => $"{_url.DOWNLOAD_KML}{activityId}",
                _ => throw new Exception("Unsupported format: " + format)
            };

            var file = await _httpClient.Download(url);

            FileHelper.WriteToFile(filePath,file);
        }

        /// <summary>
        /// 上传活动
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <param name="format">文件格式</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<DetailedImportResult> UploadActivityAsync(string filePath, string format = "fit")
        {
            var detectedFormat = format.ToLower();
            var allowedFormats = new List<string> { "fit", "gpx", "tcx", "kml", "zip" };
            if (!allowedFormats.Contains(detectedFormat))
            {
                throw new Exception("uploadActivity - Invalid format: " + format);
            }

            using var content = new MultipartFormDataContent();
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileContent = new StreamContent(fileStream);
            content.Add(fileContent, "userfile", Path.GetFileName(filePath));

            return await _httpClient.PostAsync<DetailedImportResult>(_url.UPLOAD + "." + format, content);
        }

        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="activityId">活动ID</param>
        /// <returns></returns>
        public async Task DeleteActivityAsync(int activityId) 
        {
            await _httpClient.DeleteAsync<string>($"{_url.ACTIVITY}{activityId}"); 
        }

        /// <summary>
        /// 获取锻炼
        /// </summary>
        /// <param name="start">起始页</param>
        /// <param name="limit">条数</param>
        /// <returns></returns>
        public async Task<List<Workout>> GetWorkoutsAsync(int start, int limit) 
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["start"] = start.ToString();
            query["limit"] = limit.ToString();
            return await _httpClient.GetAsync<List<Workout>>($"{_url.WORKOUTS}{query}");
        }

        /// <summary>
        /// 获取锻炼详情
        /// </summary>
        /// <param name="workoutId">锻炼ID</param>
        /// <returns></returns>
        public async Task<WorkoutDetail> GetWorkoutDetailAsync(string workoutId) 
        {
            return await _httpClient.GetAsync<WorkoutDetail>(_url.WORKOUT(workoutId));
        }

        /// <summary>
        /// 添加锻炼
        /// </summary>
        /// <param name="workoutDetail">锻炼详情</param>
        /// <returns></returns>
        public async Task<WorkoutDetail> AddWorkoutAsync(WorkoutDetail workoutDetail) 
        {
            var newWorkout = OmitProperties(workoutDetail,"workoutId","ownerId","updatedDate","createdDate","author");
            if (string.IsNullOrEmpty(newWorkout["Description"].ToString()))
                newWorkout["Description"] = "Added by garmin-connect for C# | QingTian";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(newWorkout), System.Text.Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync<WorkoutDetail>(_url.WORKOUT(""),content);
        }

        /// <summary>
        /// 添加跑步锻炼
        /// </summary>
        /// <param name="workoutDetail">锻炼详情</param>
        /// <returns></returns>
        public async Task<WorkoutDetail> AddWorkoutAsync(Running workoutDetail)
        {
            if (string.IsNullOrEmpty(workoutDetail.Description))
                workoutDetail.Description = "Added by garmin-connect for C# | QingTian";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(workoutDetail), System.Text.Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync<WorkoutDetail>(_url.WORKOUT(""), content);
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DescriptionAttribute>();
            return attr != null ? attr.Description : value.ToString();
        }

        /// <summary>
        /// 返回一个字典，包含对象所有属性，排除指定属性名
        /// </summary>
        /// <param name="obj">源对象</param>
        /// <param name="propertiesToOmit">要排除的属性名数组</param>
        /// <returns>属性名-属性值字典</returns>
        private static Dictionary<string, object> OmitProperties(object obj, params string[] propertiesToOmit)
        {
            if (obj != null)
            {
                var omitSet = new HashSet<string>(propertiesToOmit, StringComparer.OrdinalIgnoreCase);
                var dict = new Dictionary<string, object>();

                PropertyInfo[] props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in props)
                {
                    if (omitSet.Contains(prop.Name))
                        continue;

                    object? value = prop.GetValue(obj);
                    if (value != null)
                    {
                        dict[prop.Name] = value;
                    }
                }

                return dict;
            }

            throw new ArgumentNullException(nameof(obj));
        }
    }

}

