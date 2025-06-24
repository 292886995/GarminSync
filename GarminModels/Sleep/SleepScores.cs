namespace GarminModels
{
    /// <summary>
    /// 睡眠评分相关数据
    /// </summary>
    public class SleepScores
    {
        public SleepScoreDetail TotalDuration { get; set; } = null!;
        public SleepScoreDetail Stress { get; set; } = null!;
        public SleepScoreDetail AwakeCount { get; set; } = null!;
        public SleepScoreOverall Overall { get; set; } = null!;
        public SleepScoreRemPercentage RemPercentage { get; set; } = null!;
        public SleepScoreDetail Restlessness { get; set; } = null!;
        public SleepScoreLightPercentage LightPercentage { get; set; } = null!;
        public SleepScoreDeepPercentage DeepPercentage { get; set; } = null!;
    }
}
