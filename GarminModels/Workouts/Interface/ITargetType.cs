namespace GarminModels
{
    /// <summary>
    /// 目标类型接口
    /// </summary>
    public interface ITargetType
    {
        /// <summary>
        /// 锻炼目标类型ID
        /// </summary>
        public int WorkoutTargetTypeId { get; set; }

        /// <summary>
        /// 锻炼目标类型Key
        /// </summary>
        public WorkoutTargetTypeKey WorkoutTargetTypeKey { get; set; }
    }
}
