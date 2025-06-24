namespace GarminModels
{
    /// <summary>
    /// 睡眠数据类，包含所有相关的睡眠信息和统计数据
    /// </summary>
    public class SleepData
    {
        public SleepDTO DailySleepDTO { get; set; } = null!;
        public List<SleepMovement> SleepMovement { get; set; } = [];
        public bool RemSleepData { get; set; }
        public List<SleepLevels> SleepLevels { get; set; } = [];
        public int RestlessMomentsCount { get; set; }
        public List<WellnessEpochRespirationDataDTO> WellnessEpochRespirationDataDTOList { get; set; } = [];
        public List<SleepHeartRate> SleepHeartRate { get; set; } = [];
        public List<SleepBodyBattery> SleepBodyBattery { get; set; } = [];
        public double AvgOvernightHrv { get; set; }
        public string? HrvStatus { get; set; }
        public double BodyBatteryChange { get; set; }
        public int RestingHeartRate { get; set; }
    }
}
