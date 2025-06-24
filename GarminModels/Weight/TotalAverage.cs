namespace GarminModels
{
    /// <summary>
    /// 体重数据的总平均值
    /// </summary>
    public class TotalAverage
    {
        public long From { get; set; }
        public long Until { get; set; }
        public double Weight { get; set; }
        public double? Bmi { get; set; }
        public double? BodyFat { get; set; }
        public double? BodyWater { get; set; }
        public double? BoneMass { get; set; }
        public double? MuscleMass { get; set; }
        public double? PhysiqueRating { get; set; }
        public double? VisceralFat { get; set; }
        public double? MetabolicAge { get; set; }
    }
}
