namespace GarminModels
{
    /// <summary>
    /// 用户睡眠时间段
    /// </summary>
    public class UserSleepWindows
    {
        public string? SleepWindowFrequency { get; set; }
        public int StartSleepTimeSecondsFromMidnight { get; set; }
        public int EndSleepTimeSecondsFromMidnight { get; set; }
    }
}
