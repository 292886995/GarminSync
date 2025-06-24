namespace GarminModels
{
    /// <summary>
    /// 心率数据
    /// </summary>
    public class HeartRate
    {
        public int UserProfilePK { get; set; }
        public string? CalendarDate { get; set; }
        public string? StartTimestampGMT { get; set; }
        public string? EndTimestampGMT { get; set; }
        public string? StartTimestampLocal { get; set; }
        public string? EndTimestampLocal { get; set; }
        public int MaxHeartRate { get; set; }
        public int MinHeartRate { get; set; }
        public int RestingHeartRate { get; set; }
        public int LastSevenDaysAvgRestingHeartRate { get; set; }
        public List<HeartRateValueDescriptor>? HeartRateValueDescriptors { get; set; }
        public List<List<HeartRateEntry>>? HeartRateValues { get; set; }
    }
}
