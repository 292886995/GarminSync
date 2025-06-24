namespace GarminModels
{
    /// <summary>
    /// 活动类型数据传输对象
    /// </summary>
    public class ActivityTypeDTO
    {
        public int TypeId { get; set; }
        public string? TypeKey { get; set; }
        public int ParentTypeId { get; set; }
        public bool IsHidden { get; set; }
        public bool Restricted { get; set; }
        public bool Trimmable { get; set; }
    }
}
