namespace GarminModels
{
    /// <summary>
    /// 锻炼步骤
    /// </summary>
    public class WorkoutStep
    {
        /// <summary>
        /// 锻炼步骤类型
        /// </summary>
        public WorkoutStepType Type { get; set; }

        /// <summary>
        /// 锻炼步骤ID
        /// </summary>
        public string? StepId { get; set; }

        /// <summary>
        /// 锻炼步骤序号
        /// </summary>
        public int StepOrder { get; set; }

        /// <summary>
        /// 子步骤ID
        /// </summary>
        public string? ChildStepId { get; set; }

        /// <summary>
        /// 锻炼步骤描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 锻炼步骤类型
        /// </summary>
        public StepType? StepType { get; set; }

        /// <summary>
        /// 结束条件
        /// </summary>
        public EndCondition? EndCondition { get; set; }

        /// <summary>
        /// 首选结束条件单位
        /// </summary>
        public PreferredEndConditionUnit? PreferredEndConditionUnit { get; set; }

        /// <summary>
        /// 结束条件值
        /// </summary>
        public double? EndConditionValue { get; set; }

        /// <summary>
        /// 结束条件比较符
        /// </summary>
        public string? EndConditionCompare { get; set; }

        /// <summary>
        /// 结束条件区域
        /// </summary>
        public string? EndConditionZone { get; set; }

        /// <summary>
        /// 目标类型
        /// </summary>
        public TargetType? TargetType { get; set; }

        /// <summary>
        /// 目标1
        /// </summary>
        public string? TargetValueOne { get; set; }

        /// <summary>
        /// 目标2
        /// </summary>
        public string? TargetValueTwo { get; set; }

        /// <summary>
        /// 区域值
        /// </summary>
        public string? ZoneNumber { get; set; }
    }
}
