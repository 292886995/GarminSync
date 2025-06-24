namespace GarminModels
{
    /// <summary>
    /// 活动类型信息
    /// </summary>
    public class ActivityTypeInfo
    {
        /// <summary>
        /// 类型ID
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 类型关键字
        /// </summary>
        public string? TypeKey { get; set; }

        /// <summary>
        /// 父类型ID
        /// </summary>
        public int ParentTypeId { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// 是否可裁剪
        /// </summary>
        public bool Trimmable { get; set; }

        /// <summary>
        /// 是否受限
        /// </summary>
        public bool Restricted { get; set; }
    }
}
