namespace GarminModels
{
    /// <summary>
    /// 用户数据
    /// </summary>
    public class UserData
    {
        public string? Gender { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
        public string? TimeFormat { get; set; }
        public string? BirthDate { get; set; }
        public string? MeasurementSystem { get; set; }
        public string? ActivityLevel { get; set; }
        public string? Handedness { get; set; }
        public PowerFormat? PowerFormat { get; set; }
        public HeartRateFormat? HeartRateFormat { get; set; }
        public FirstDayOfWeek? FirstDayOfWeek { get; set; }
        public string? Vo2MaxRunning { get; set; }
        public string? Vo2MaxCycling { get; set; }
        public string? LactateThresholdSpeed { get; set; }
        public string? LactateThresholdHeartRate { get; set; }
        public string? DiveNumber { get; set; }
        public string? IntensityMinutesCalcMethod { get; set; }
        public int ModerateIntensityMinutesHrZone { get; set; }
        public int VigorousIntensityMinutesHrZone { get; set; }
        public string? HydrationMeasurementUnit { get; set; }
        public List<string> HydrationContainers { get; set; } = [];
        public bool HydrationAutoGoalEnabled { get; set; }
        public string? FirstbeatMaxStressScore { get; set; }
        public string? FirstbeatCyclingLtTimestamp { get; set; }
        public string? FirstbeatRunningLtTimestamp { get; set; }
        public string? ThresholdHeartRateAutoDetected { get; set; }
        public string? FtpAutoDetected { get; set; }
        public string? TrainingStatusPausedDate { get; set; }
        public WeatherLocation? WeatherLocation { get; set; }
        public string? GolfDistanceUnit { get; set; }
        public string? GolfElevationUnit { get; set; }
        public string? GolfSpeedUnit { get; set; }
        public string? ExternalBottomTime { get; set; }
    }
}
