namespace GarminModels
{
    public class WorkoutSegment
    {
        public int SegmentOrder { get; set; }

        // Updated SportType property to match the nullability of the interface  
        public SportType? SportType { get; set; }

        public List<WorkoutStep>? WorkoutSteps { get; set; }
    }
}
