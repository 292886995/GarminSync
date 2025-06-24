namespace GarminModels
{
    /// <summary>
    /// 活动元数据数据传输对象
    /// </summary>
    public class MetadataDTO
    {
        public bool IsOriginal { get; set; }
        public int DeviceApplicationInstallationId { get; set; }
        public double AgentApplicationInstallationId { get; set; }
        public double AgentString { get; set; }
        public FileFormat? FileFormat { get; set; }
        public double AssociatedCourseId { get; set; }
        public string? LastUpdateDate { get; set; }
        public string? UploadedDate { get; set; }
        public double VideoUrl { get; set; }
        public bool HasPolyline { get; set; }
        public bool HasChartData { get; set; }
        public bool HasHrTimeInZones { get; set; }
        public bool HasPowerTimeInZones { get; set; }
        public UserInfoDTO? UserInfoDto { get; set; }
        public List<double>? ChildIds { get; set; }
        public List<double>? ChildActivityTypes { get; set; }
        public List<double>? Sensors { get; set; }
        public List<double>? ActivityImages { get; set; }
        public string? Manufacturer { get; set; }
        public double DiveNumber { get; set; }
        public int LapCount { get; set; }
        public int AssociatedWorkoutId { get; set; }
        public double IsAtpActivity { get; set; }
        public DeviceMetaDataDTO? DeviceMetaDataDTO { get; set; }
        public bool HasIntensityIntervals { get; set; }
        public bool HasSplits { get; set; }
        public double EBikeMaxAssistModes { get; set; }
        public double EBikeBatteryUsage { get; set; }
        public double EBikeBatteryRemaining { get; set; }
        public double EBikeAssistModeInfoDTOList { get; set; }
        public double CalendarEventInfo { get; set; }
        public bool PersonalRecord { get; set; }
        public bool Gcj02 { get; set; }
        public double RunPowerWindDataEnabled { get; set; }
        public bool AutoCalcCalories { get; set; }
        public bool Favorite { get; set; }
        public bool ManualActivity { get; set; }
        public bool Trimmed { get; set; }
        public bool ElevationCorrected { get; set; }
    }
}
