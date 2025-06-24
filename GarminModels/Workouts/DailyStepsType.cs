namespace GarminModels
{
    /// <summary>
    /// 每日步数类型
    /// </summary>
    public class DailyStepsType
    {
        public string? CalendarDate { get; set; }
        public int StepGoal { get; set; }
        public int TotalDistance { get; set; }
        public int TotalSteps { get; set; }
    }
}
