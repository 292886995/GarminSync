namespace GarminModels
{
    /// <summary>
    /// 锻炼
    /// </summary>
    public class Workout
    {
        public int? WorkoutId { get; set; }
        public int? OwnerId { get; set; }
        public string WorkoutName { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public SportType SportType { get; set; } = null!;
        public string? TrainingPlanId { get; set; }
        public Author Author { get; set; } = null!;
        public int EstimatedDurationInSecs { get; set; }
        public string? EstimatedDistanceInMeters { get; set; }
        public string? EstimateType { get; set; }
        public Unit EstimatedDistanceUnit { get; set; } = null!;
        public int PoolLength { get; set; }
        public Unit PoolLengthUnit { get; set; } = null!;
        public string WorkoutProvider { get; set; } = null!;
        public string WorkoutSourceId { get; set; } = null!;
        public string? Consumer { get; set; }
        public string? AtpPlanId { get; set; }
        public string? WorkoutNameI18nKey { get; set; }
        public string? DescriptionI18nKey { get; set; }
        public bool Shared { get; set; }
        public bool Estimated { get; set; }
    }
}
