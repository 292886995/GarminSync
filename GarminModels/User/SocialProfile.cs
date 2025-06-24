namespace GarminModels
{
    /// <summary>
    /// 社交资料
    /// </summary>
    public class SocialProfile
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string? GarminGUID { get; set; }
        public string? DisplayName { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? ProfileImageUuid { get; set; }
        public string? ProfileImageUrlLarge { get; set; }
        public string? ProfileImageUrlMedium { get; set; }
        public string? ProfileImageUrlSmall { get; set; }
        public string? Location { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? PersonalWebsite { get; set; }
        public string? Motivation { get; set; }
        public string? Bio { get; set; }
        public string? PrimaryActivity { get; set; }
        public List<string>? FavoriteActivityTypes { get; set; }
        public double RunningTrainingSpeed { get; set; }
        public double CyclingTrainingSpeed { get; set; }
        public List<string>? FavoriteCyclingActivityTypes { get; set; }
        public string? CyclingClassification { get; set; }
        public double CyclingMaxAvgPower { get; set; }
        public double SwimmingTrainingSpeed { get; set; }
        public string? ProfileVisibility { get; set; }
        public string? ActivityStartVisibility { get; set; }
        public string? ActivityMapVisibility { get; set; }
        public string? CourseVisibility { get; set; }
        public string? ActivityHeartRateVisibility { get; set; }
        public string? ActivityPowerVisibility { get; set; }
        public string? BadgeVisibility { get; set; }
        public bool ShowAge { get; set; }
        public bool ShowWeight { get; set; }
        public bool ShowHeight { get; set; }
        public bool ShowWeightClass { get; set; }
        public bool ShowAgeRange { get; set; }
        public bool ShowGender { get; set; }
        public bool ShowActivityClass { get; set; }
        public bool ShowVO2Max { get; set; }
        public bool ShowPersonalRecords { get; set; }
        public bool ShowLast12Months { get; set; }
        public bool ShowLifetimeTotals { get; set; }
        public bool ShowUpcomingEvents { get; set; }
        public bool ShowRecentFavorites { get; set; }
        public bool ShowRecentDevice { get; set; }
        public bool ShowRecentGear { get; set; }
        public bool ShowBadges { get; set; }
        public string? OtherActivity { get; set; }
        public string? OtherPrimaryActivity { get; set; }
        public string? OtherMotivation { get; set; }
        public List<string>? UserRoles { get; set; }
        public bool NameApproved { get; set; }
        public string? UserProfileFullName { get; set; }
        public bool MakeGolfScorecardsPrivate { get; set; }
        public bool AllowGolfLiveScoring { get; set; }
        public bool AllowGolfScoringByConnections { get; set; }
        public int UserLevel { get; set; }
        public int UserPoint { get; set; }
        public string? LevelUpdateDate { get; set; }
        public bool LevelIsViewed { get; set; }
        public int LevelPointThreshold { get; set; }
        public int UserPointOffset { get; set; }
        public bool UserPro { get; set; }
    }
}
