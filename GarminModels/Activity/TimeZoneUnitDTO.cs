namespace GarminModels
{
    /// <summary>
    /// 时区单位数据传输对象
    /// </summary>
    public class TimeZoneUnitDTO
    {
        public int UnitId { get; set; }
        public string? UnitKey { get; set; }
        public double Factor { get; set; }
        public string? TimeZone { get; set; }
    }
}
