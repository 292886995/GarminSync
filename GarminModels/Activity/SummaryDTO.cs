namespace GarminModels
{
    /// <summary>
    /// 概况数据传输对象
    /// </summary>
    public class SummaryDTO
    {
        public string? StartTimeLocal { get; set; }
        public string? StartTimeGMT { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
        public double MovingDuration { get; set; }
        public double ElapsedDuration { get; set; }
        public double ElevationGain { get; set; }
        public double ElevationLoss { get; set; }
        public double MaxElevation { get; set; }
        public double MinElevation { get; set; }
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
        public double TrainingEffect { get; set; }
        public double AnaerobicTrainingEffect { get; set; }
        public string? AerobicTrainingEffectMessage { get; set; }
        public string? AnaerobicTrainingEffectMessage { get; set; }
        public double VerticalRatio { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public double MaxVerticalSpeed { get; set; }
        public double MinActivityLapDuration { get; set; }
    }
}
