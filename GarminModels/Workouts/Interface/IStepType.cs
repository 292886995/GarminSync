namespace GarminModels
{
    /// <summary>
    /// 步骤类型接口
    /// </summary>
    public interface IStepType
    {
        /// <summary>
        /// 步骤类型ID
        /// </summary>
        public int StepTypeId { get; set; }

        /// <summary>
        /// 步骤类型Key
        /// </summary>
        public StepTypeKey StepTypeKey { get; set; }
    }
}
