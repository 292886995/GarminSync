namespace GarminModels
{
    /// <summary>
    /// 睡眠运动数据
    /// </summary>
    public class SleepMovement
    {
        public string? StartGMT { get; set; }
        public string? EndGMT { get; set; }
        public int ActivityLevel { get; set; }
    }
}
