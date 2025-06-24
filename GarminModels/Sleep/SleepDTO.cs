namespace GarminModels
{
    /// <summary>
    /// 睡眠数据传输对象
    /// </summary>
    public class SleepDTO
    {
        public int Id { get; set; }
        public int UserProfilePK { get; set; }
        public string? CalendarDate { get; set; }
        public int SleepTimeSeconds { get; set; }
        public int NapTimeSeconds { get; set; }
        public bool SleepWindowConfirmed { get; set; }
        public string? SleepWindowConfirmationType { get; set; }
        public long SleepStartTimestampGMT { get; set; }
        public long SleepEndTimestampGMT { get; set; }
        public long SleepStartTimestampLocal { get; set; }
        public long SleepEndTimestampLocal { get; set; }
        public long? AutoSleepStartTimestampGMT { get; set; }
        public long? AutoSleepEndTimestampGMT { get; set; }
        public int? SleepQualityTypePK { get; set; }
        public int? SleepResultTypePK { get; set; }
        public int UnmeasurableSleepSeconds { get; set; }
        public int DeepSleepSeconds { get; set; }
        public int LightSleepSeconds { get; set; }
        public int RemSleepSeconds { get; set; }
        public int AwakeSleepSeconds { get; set; }
        public bool DeviceRemCapable { get; set; }
        public bool Retro { get; set; }
        public bool SleepFromDevice { get; set; }
        public double AverageRespirationValue { get; set; }
        public double LowestRespirationValue { get; set; }
        public double HighestRespirationValue { get; set; }
        public int AwakeCount { get; set; }
        public double AvgSleepStress { get; set; }
        public string? AgeGroup { get; set; }
        public string? SleepScoreFeedback { get; set; }
        public string? SleepScoreInsight { get; set; }
        public SleepScores SleepScores { get; set; } = null!;
        public int SleepVersion { get; set; }
    }
}
