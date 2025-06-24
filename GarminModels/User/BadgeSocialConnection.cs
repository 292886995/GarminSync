namespace GarminModels
{
    /// <summary>
    /// 社交连接徽章
    /// </summary>
    public class BadgeSocialConnection
    {
        public string? UserProfileId { get; set; }
        public string? Pagination { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfileImageUrlMedium { get; set; }
        public string? ProfileImageUrlSmall { get; set; }
        public int UserLevel { get; set; }
        public string? BadgeEarnedDate { get; set; }
    }
}
