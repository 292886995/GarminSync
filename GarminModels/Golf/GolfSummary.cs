namespace GarminModels
{
    /// <summary>
    /// 高尔夫概括
    /// </summary>
    public class GolfSummary
    {
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
        public int TotalRows { get; set; }
        public List<ScorecardSummary>? ScorecardSummaries { get; set; }
    }
}
