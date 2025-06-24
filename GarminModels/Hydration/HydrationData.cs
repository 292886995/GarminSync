namespace GarminModels
{
    /// <summary>
    /// 补水数据
    /// </summary>
    public class HydrationData
    {
        public int UserId { get; set; }
        public string? CalendarDate { get; set; }
        public string? LastEntryTimestampLocal { get; set; }
        public int ValueInML { get; set; }
        public int GoalInML { get; set; }
        public int BaseGoalInML { get; set; }
        public int SweatLossInML { get; set; }
        public int ActivityIntakeInML { get; set; }
        public string? HydrationMeasurementUnit { get; set; }
        public List<HydrationContainer>? HydrationContainers { get; set; }
        public bool HydrationAutoGoalEnabled { get; set; }
    }
}
