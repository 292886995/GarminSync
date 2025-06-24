namespace GarminModels
{
    /// <summary>
    /// 水摄入量
    /// </summary>
    public class WaterIntake
    {
        public int UserId { get; set; }
        public string? CalendarDate { get; set; }
        public int ValueInML { get; set; }
        public int GoalInML { get; set; }
        public int? DailyAverageInML { get; set; }
        public string? LastEntryTimestampLocal { get; set; }
        public int? SweatLossInML { get; set; }
        public int ActivityIntakeInML { get; set; }
    }
}
