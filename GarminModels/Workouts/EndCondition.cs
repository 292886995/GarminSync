namespace GarminModels
{
    /// <summary>
    /// 结束条件
    /// </summary>
    public class EndCondition : IEndCondition
    {
        /// <summary>
        /// 条件类型Key
        /// </summary>
        public ConditionTypeKey ConditionTypeKey { get; set; }

        /// <summary>
        /// 条件类型ID
        /// </summary>
        public int ConditionTypeId { get; set; }
    }
}
