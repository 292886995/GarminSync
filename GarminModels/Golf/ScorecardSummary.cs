namespace GarminModels
{
    /// <summary>
    /// 计分卡概括
    /// </summary>
    public class ScorecardSummary
    {
        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public int PlayerProfileId { get; set; }
        public string? ScoreType { get; set; }
        public string? CourseName { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public bool RoundInProgress { get; set; }
        public int Strokes { get; set; }
        public int HandicappedStrokes { get; set; }
        public int ScoreWithHandicap { get; set; }
        public int ScoreWithoutHandicap { get; set; }
        public int HolesCompleted { get; set; }
        public string? RoundType { get; set; }
    }
}
