namespace GarminModels
{
    /// <summary>
    /// 社交连接
    /// </summary>
    public class SocialConnection
    {
        public int UserId { get; set; }

        public string? DisplayName { get; set; }

        public string? FullName { get; set; }

        public string? Location { get; set; }

        public string? ProfileImageUrlMedium { get; set; }

        public string? ProfileImageUrlSmall { get; set; }

        public int UserLevel { get; set; }

        public int ConnectionRequestId { get; set; }

        public int ConnectionRequestorId { get; set; }

        public int UserConnectionStatus { get; set; }

        public List<string>? UserRoles { get; set; }

        public int ProfileVisibility { get; set; }

        public List<string>? DeviceInvitations { get; set; }

        public bool NameApproved { get; set; }

        public int BadgeVisibility { get; set; }

        public bool UserPro { get; set; }
    }
}
