namespace GarminModels
{
    /// <summary>
    /// 睡眠呼吸数据
    /// </summary>
    public class WellnessEpochRespirationDataDTO
    {
        public long StartTimeGMT { get; set; }
        public double RespirationValue { get; set; }
    }
}
