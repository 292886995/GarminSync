namespace GarminModels
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        public int UserProfileId { get; set; }
        public string? Username { get; set; }
        public string? EmailAddress { get; set; }
        public string? Locale { get; set; }
        public string? MeasurementSystemKey { get; set; }
        public string? TimeFormatKey { get; set; }
        public string? DateFormatKey { get; set; }
        public string? NumberFormatKey { get; set; }
        public string? HeartRateDisplayFormatKey { get; set; }
        public string? PowerDisplayFormatKey { get; set; }
        public string? TimeZoneGroupKey { get; set; }
        public string? DayKey { get; set; }
        public bool IsPublicByDefault { get; set; }
        public List<string>? Roles { get; set; }
        public string? DisplayName { get; set; }
        public string? TocAcceptedDate { get; set; }
        public string? DefaultActivityPrivacy { get; set; }
        public string? CustomerId { get; set; }
        public string? Birthdate { get; set; }
        public string? SocialNetwork { get; set; }
        public string? SocialIcon { get; set; }
        public bool SystemUser { get; set; }
        public bool SystemMetricUser { get; set; }
        public bool UnderAge { get; set; }
    }
}
