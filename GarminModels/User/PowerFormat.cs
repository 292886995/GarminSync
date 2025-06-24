namespace GarminModels
{
    /// <summary>
    /// 电池格式
    /// </summary>
    public class PowerFormat
    {
        public int FormatId { get; set; }
        public string? FormatKey { get; set; }
        public int MinFraction { get; set; }
        public int MaxFraction { get; set; }
        public bool GroupingUsed { get; set; }
        public string? DisplayFormat { get; set; }
    }
}
