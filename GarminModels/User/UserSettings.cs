namespace GarminModels
{
    /// <summary>
    /// 用户设置
    /// </summary>
    public class UserSettings
    {
        public int Id { get; set; }

        public UserData UserData { get; set; } = null!;

        public UserSleep UserSleep { get; set; } = null!;

        public string? ConnectDate { get; set; }

        public string? SourceType { get; set; }

        public List<UserSleepWindows> UserSleepWindows { get; set; } = [];
    }
}
