namespace GarminModels
{
    /// <summary>
    /// 事件类型数据传输对象
    /// </summary>
    public class EventTypeDTO
    {
        public int TypeId { get; set; }
        public string? TypeKey { get; set; }
        public int SortOrder { get; set; }
    }
}
