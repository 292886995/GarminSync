namespace GarminModels
{
    /// <summary>
    /// 体重数据传输对象
    /// </summary>
    public class DateWeight
    {
        public int SamplePk { get; set; }
        public long Date { get; set; }
        public string? CalendarDate { get; set; }
        public double Weight { get; set; }
        public double? Bmi { get; set; }
        public double? BodyFat { get; set; }
        public double? BodyWater { get; set; }
        public double? BoneMass { get; set; }
        public double? MuscleMass { get; set; }
        public double? PhysiqueRating { get; set; }
        public double? VisceralFat { get; set; }
        public double? MetabolicAge { get; set; }
        public string? SourceType { get; set; }
        public long TimestampGMT { get; set; }
        public double WeightDelta { get; set; }
    }
}
