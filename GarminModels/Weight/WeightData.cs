namespace GarminModels
{
    /// <summary>
    /// 体重数据
    /// </summary>
    public class WeightData
    {
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public List<DateWeight> DateWeightList { get; set; } = new List<DateWeight>();
        public TotalAverage TotalAverage { get; set; } = null!;
    }
}
