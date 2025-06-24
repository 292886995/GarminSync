namespace GarminModels
{
    /// <summary>
    /// 装备信息
    /// </summary>
    public class Gear
    {
        public int GearPk { get; set; }
        public string? Uuid { get; set; }
        public int UserProfilePk { get; set; }
        public string? GearMakeName { get; set; }
        public string? GearModelName { get; set; }
        public string? GearTypeName { get; set; }
        public string? GearStatusName { get; set; }
        public string? DisplayName { get; set; }
        public string? CustomMakeModel { get; set; }
        public string? ImageNameLarge { get; set; }
        public string? ImageNameMedium { get; set; }
        public string? ImageNameSmall { get; set; }
        public string? DateBegin { get; set; }
        public string? DateEnd { get; set; }
        public int MaximumMeters { get; set; }
        public bool Notified { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
    }
}
