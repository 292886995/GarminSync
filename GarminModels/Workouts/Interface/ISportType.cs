namespace GarminModels
{
    /// <summary>
    /// 运动类型接口
    /// </summary>
    public interface ISportType
    {
        /// <summary>
        /// 运动类型ID
        /// </summary>
        public int SportTypeId { get; set; }

        /// <summary>
        /// 运动类型Key
        /// </summary>
        public SportTypeKey SportTypeKey { get; set; }
    }
}
