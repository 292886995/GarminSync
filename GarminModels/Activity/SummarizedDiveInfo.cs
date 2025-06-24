namespace GarminModels
{
    /// <summary>
    /// 潜水数据概括
    /// </summary>
    public class SummarizedDiveInfo
    {
        public double Weight { get; set; }
        public double WeightUnit { get; set; }
        public double Visibility { get; set; }
        public double VisibilityUnit { get; set; }
        public double SurfaceCondition { get; set; }
        public double Current { get; set; }
        public double WaterType { get; set; }
        public double WaterDensity { get; set; }

        /// <summary>
        /// 潜水气体数组
        /// </summary>
        public List<double> SummarizedDiveGases { get; set; } = [];
        public double TotalSurfaceTime { get; set; }
    }
}
