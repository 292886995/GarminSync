namespace GarminModels
{
    /// <summary>
    /// 设备元数据数据传输对象
    /// </summary>
    public class DeviceMetaDataDTO
    {
        public string? DeviceId { get; set; }
        public int DeviceTypePk { get; set; }
        public int DeviceVersionPk { get; set; }
    }
}
