namespace GarminModels
{
    /// <summary>
    /// 跑步锻炼
    /// </summary>
    public class RunningWorkout
    {
        /// <summary>
        /// 锻炼ID
        /// </summary>
        public string? WorkoutId { get; set; }

        /// <summary>
        /// 锻炼描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 运动类型
        /// </summary>
        public SportType? SportType { get; set; }

        /// <summary>
        /// 锻炼名称
        /// </summary>
        public string? WorkoutName { get; set; }

        /// <summary>
        /// 锻炼分段列表
        /// </summary>
        public List<WorkoutSegment>? WorkoutSegments { get; set; }
    }
}
