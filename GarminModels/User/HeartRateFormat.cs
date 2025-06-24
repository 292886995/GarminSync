namespace GarminModels
{
    /// <summary>
    /// 心率格式
    /// </summary>
    public class HeartRateFormat
    {
        public int FormatId { get; set; }
        public string? FormatKey { get; set; }
        public int MinFraction { get; set; }
        public int MaxFraction { get; set; }
        public bool GroupingUsed { get; set; }
        public string? DisplayFormat { get; set; }
    }
}
