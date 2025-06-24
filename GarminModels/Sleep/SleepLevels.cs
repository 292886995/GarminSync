namespace GarminModels
{
    /// <summary>
    /// 睡眠阶段数据
    /// </summary>
    public class SleepLevels
    {
        public string? StartGMT { get; set; }
        public string? EndGMT { get; set; }
        public int ActivityLevel { get; set; }
    }
}
