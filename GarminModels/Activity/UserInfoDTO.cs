namespace GarminModels
{
    /// <summary>
    /// 用户信息数据传输对象
    /// </summary>
    public class UserInfoDTO
    {
        public int UserProfilePk { get; set; }
        public string? Displayname { get; set; }
        public string? Fullname { get; set; }
        public string? ProfileImageUrlLarge { get; set; }
        public string? ProfileImageUrlMedium { get; set; }
        public string? ProfileImageUrlSmall { get; set; }
        public bool UserPro { get; set; }
    }
}
