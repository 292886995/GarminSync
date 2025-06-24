namespace GarminModels
{
    /// <summary>
    /// 徽章相关信息
    /// </summary>
    public class BadgeRelated
    {
        public string? BadgeId { get; set; }
        public string? BadgeKey { get; set; }
        public string? BadgeName { get; set; }
        public string? BadgeUuid { get; set; }
        public int BadgeCategoryId { get; set; }
        public int BadgeDifficultyId { get; set; }
        public int BadgePoints { get; set; }
        public List<int> BadgeTypeIds { get; set; } = [];
        public bool EarnedByMe { get; set; }
    }
}
