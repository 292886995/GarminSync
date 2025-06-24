namespace GarminModels
{
    /// <summary>
    /// 更新体重数据
    /// </summary>
    public class UpdateWeight
    {
        public string? DateTimestamp { get; set; }  // 格式示例: "2023-12-31T12:39:00.00"
        public string? GmtTimestamp { get; set; }   // 格式示例: "2023-12-31T20:39:00.00"
        public string? UnitKey { get; set; }        // 例如: "lbs"
        public double Value { get; set; }            // 例如: 202.9
    }
}
