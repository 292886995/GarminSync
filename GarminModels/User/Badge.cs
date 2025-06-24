namespace GarminModels
{
    /// <summary>
    /// 徽章
    /// </summary>
    public class Badge
    {
        public string? BadgeId { get; set; }
        public string? BadgeKey { get; set; }
        public string? BadgeName { get; set; }
        public string? BadgeUuid { get; set; }
        public int BadgeCategoryId { get; set; }
        public int BadgeDifficultyId { get; set; }
        public int BadgePoints { get; set; }
        public List<int> BadgeTypeIds { get; set; } = [];
        public string? BadgeSeriesId { get; set; }
        public string? BadgeStartDate { get; set; }
        public string? BadgeEndDate { get; set; }
        public int UserProfileId { get; set; }
        public string? FullName { get; set; }
        public string? DisplayName { get; set; }
        public string? BadgeEarnedDate { get; set; }
        public int BadgeEarnedNumber { get; set; }
        public string? BadgeLimitCount { get; set; }
        public bool BadgeIsViewed { get; set; }
        public int BadgeProgressValue { get; set; }
        public string? BadgeTargetValue { get; set; }
        public string? BadgeUnitId { get; set; }
        public int BadgeAssocTypeId { get; set; }
        public string? BadgeAssocDataId { get; set; }
        public string? BadgeAssocDataName { get; set; }
        public bool EarnedByMe { get; set; }
        public string? CurrentPlayerType { get; set; }
        public string? UserJoined { get; set; }
        public string? BadgeChallengeStatusId { get; set; }
        public string? BadgePromotionCodeType { get; set; }
        public string? PromotionCodeStatus { get; set; }
        public string? CreateDate { get; set; }
        public List<BadgeRelated>? RelatedBadges { get; set; }
        public int ConnectionNumber { get; set; }
        public List<BadgeSocialConnection>? Connections { get; set; }
    }
}
