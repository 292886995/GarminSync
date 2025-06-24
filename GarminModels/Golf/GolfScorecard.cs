namespace GarminModels
{
    /// <summary>
    /// 高尔夫记分卡
    /// </summary>
    public class GolfScorecard
    {
        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public int PlayerProfileId { get; set; }
        public string? RoundPlayerName { get; set; }
        public string? ConnectDisplayName { get; set; }
        public int CourseGlobalId { get; set; }
        public int CourseSnapshotId { get; set; }
        public int FrontNineGlobalCourseId { get; set; }
        public string? ScoreType { get; set; }
        public bool UseHandicapScoring { get; set; }
        public bool UseStrokeCounting { get; set; }
        public double DistanceWalked { get; set; }
        public int StepsTaken { get; set; }
        public string? StartTime { get; set; }
        public string? FormattedStartTime { get; set; }
        public string? EndTime { get; set; }
        public string? FormattedEndTime { get; set; }
        public string? UnitId { get; set; }
        public string? RoundType { get; set; }
        public bool InProgress { get; set; }
        public bool ExcludeFromStats { get; set; }
        public int HolesCompleted { get; set; }
        public bool PublicRound { get; set; }
        public int Score { get; set; }
        public int PlayerHandicap { get; set; }
        public string? CourseHandicapStr { get; set; }
        public string? TeeBox { get; set; }
        public string? HandicapType { get; set; }
        public double TeeBoxRating { get; set; }
        public double TeeBoxSlope { get; set; }
        public string? LastModifiedDt { get; set; }
        public bool SensorOnPutter { get; set; }
        public int HandicappedStrokes { get; set; }
    }
}
