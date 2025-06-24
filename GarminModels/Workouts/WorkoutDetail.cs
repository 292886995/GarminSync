namespace GarminModels
{
    /// <summary>
    /// 锻炼详情
    /// </summary>
    public class WorkoutDetail : Workout
    {
        public List<WorkoutSegment> WorkoutSegments { get; set; } = [];
    }
}
