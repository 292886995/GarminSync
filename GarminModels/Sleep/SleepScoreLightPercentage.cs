namespace GarminModels
{
    /// <summary>
    /// 睡眠评分浅睡百分比
    /// </summary>
    public class SleepScoreLightPercentage
    {
        public int Value { get; set; }
        public string? QualifierKey { get; set; }
        public int OptimalStart { get; set; }
        public int OptimalEnd { get; set; }
        public int IdealStartInSeconds { get; set; }
        public int IdealEndInSeconds { get; set; }
    }
}
