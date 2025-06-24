namespace GarminModels
{
    /// <summary>
    /// 分段概况信息
    /// </summary>
    public class SplitSummary
    {
        public double Distance { get; set; }
        public double Duration { get; set; }
        public double MovingDuration { get; set; }
        public double ElapsedDuration { get; set; }
        public double ElevationGain { get; set; }
        public double ElevationLoss { get; set; }
        public double AverageSpeed { get; set; }
        public double AverageMovingSpeed { get; set; }
        public double MaxSpeed { get; set; }
        public double Calories { get; set; }
        public double AverageHR { get; set; }
        public double MaxHR { get; set; }
        public double AverageRunCadence { get; set; }
        public double MaxRunCadence { get; set; }
        public double AverageTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double GroundContactTime { get; set; }
        public double GroundContactBalanceLeft { get; set; }
        public double StrideLength { get; set; }
        public double VerticalOscillation { get; set; }
        public double VerticalRatio { get; set; }
        public int TotalExerciseReps { get; set; }
        public string? SplitType { get; set; }
        public int NoOfSplits { get; set; }
        public double MaxElevationGain { get; set; }
        public double AverageElevationGain { get; set; }
        public double MaxDistance { get; set; }
    }
}
