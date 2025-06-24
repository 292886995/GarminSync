namespace GarminModels
{
    /// <summary>
    /// 一周的第一天
    /// </summary>
    public class FirstDayOfWeek
    {
        public int DayId { get; set; }
        public string? DayName { get; set; }
        public int SortOrder { get; set; }
        public bool IsPossibleFirstDay { get; set; }
    }
}
