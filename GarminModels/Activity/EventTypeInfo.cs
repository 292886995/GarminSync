namespace GarminModels
{
    /// <summary>
    /// 事件类型信息
    /// </summary>
    public class EventTypeInfo
    {
        /// <summary>
        /// 事件类型ID
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 事件类型关键字
        /// </summary>
        public string? TypeKey { get; set; }

        /// <summary>
        /// 排序顺序
        /// </summary>
        public int SortOrder { get; set; }
    }
}
