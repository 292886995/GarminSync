using GarminConnect.Garmin;

namespace GarminConnect
{
    /// <summary>
    /// 佳明URL类
    /// </summary>
    public class UrlClass
    {
        /// <summary>
        /// 佳明域名
        /// </summary>
        private readonly string _domain;

        /// 佳明URL基地址
        public string GC_MODERN { get; }
        public string GARMIN_SSO_ORIGIN { get; }
        public string GC_API { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="domain">Garmin 区域枚举</param>
        public UrlClass(GarminDomain domain = GarminDomain.GarminCom)
        {
            this._domain = domain == GarminDomain.GarminCom? "garmin.com": "garmin.cn";
            GC_MODERN = $"https://connect.{this._domain}/modern";
            GARMIN_SSO_ORIGIN = $"https://sso.{this._domain}";
            GC_API = $"https://connectapi.{this._domain}";
        }

        /// 佳明API URL
        public string GARMIN_SSO => $"{GARMIN_SSO_ORIGIN}/sso";
        public string GARMIN_SSO_EMBED => $"{GARMIN_SSO_ORIGIN}/sso/embed";
        public string BASE_URL => $"{GC_MODERN}/proxy";
        public string SIGNIN_URL => $"{GARMIN_SSO}/signin";
        public string LOGIN_URL => $"{GARMIN_SSO}/login";
        public string OAUTH_URL => $"{GC_API}/oauth-service/oauth";
        public string USER_SETTINGS => $"{GC_API}/userprofile-service/userprofile/user-settings/";
        public string USER_PROFILE => $"{GC_API}/userprofile-service/socialProfile";
        public string ACTIVITIES => $"{GC_API}/activitylist-service/activities/search/activities";
        public string ACTIVITY => $"{GC_API}/activity-service/activity/";
        public string STAT_ACTIVITIES => $"{GC_API}/fitnessstats-service/activity";
        public string DOWNLOAD_ZIP => $"{GC_API}/download-service/files/activity/";
        public string DOWNLOAD_GPX => $"{GC_API}/download-service/export/gpx/activity/";
        public string DOWNLOAD_TCX => $"{GC_API}/download-service/export/tcx/activity/";
        public string DOWNLOAD_KML => $"{GC_API}/download-service/export/kml/activity/";
        public string UPLOAD => $"{GC_API}/upload-service/upload/";
        public string IMPORT_DATA => $"{GC_API}/modern/import-data";
        public string DAILY_STEPS => $"{GC_API}/usersummary-service/stats/steps/daily/";
        public string DAILY_SLEEP => $"{GC_API}/sleep-service/sleep/dailySleepData";
        public string DAILY_WEIGHT => $"{GC_API}/weight-service/weight/dayview";
        public string UPDATE_WEIGHT => $"{GC_API}/weight-service/user-weight";
        public string DAILY_HYDRATION => $"{GC_API}/usersummary-service/usersummary/hydration/allData";
        public string HYDRATION_LOG => $"{GC_API}/usersummary-service/usersummary/hydration/log";
        public string GOLF_SCORECARD_SUMMARY => $"{GC_API}/gcs-golfcommunity/api/v2/scorecard/summary";
        public string GOLF_SCORECARD_DETAIL => $"{GC_API}/gcs-golfcommunity/api/v2/scorecard/detail";
        public string DAILY_HEART_RATE => $"{GC_API}/wellness-service/wellness/dailyHeartRate";
        public string WORKOUTS => $"{GC_API}/workout-service/workouts";

        public string WORKOUT(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return $"{GC_API}/workout-service/workout/{id}";
            }
            return $"{GC_API}/workout-service/workout";
        }
    }
}
