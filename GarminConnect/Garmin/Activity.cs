using GarminModels;
using System.ComponentModel;

namespace GarminConnect
{
    /// <summary>
    /// 活动类型枚举
    /// </summary>
    public enum ActivityType
    {
        [Description("cycling")]
        Cycling,

        [Description("fitness_equipment")]
        FitnessEquipment,

        [Description("walking")]
        Walking,

        [Description("hiking")]
        Hiking,

        [Description("other")]
        Other,

        [Description("water_sports")]
        WaterSport,

        [Description("street_running")]
        Running
    }

    /// <summary>
    /// 活动子类型枚举
    /// </summary>
    public enum ActivitySubType
    {
        [Description("indoor_cardio")]
        IndoorCardio,       // Maps to FitnessEquipment

        [Description("strength_training")]
        StrengthTraining,   // Maps to FitnessEquipment

        [Description("hiit")]
        HIIT,               // Maps to FitnessEquipment

        [Description("yoga")]
        Yoga,               // Maps to FitnessEquipment

        [Description("indoor_cycling")]
        IndoorCycling,      // Maps to Cycling

        [Description("breathwork")]
        Breathwork,         // Maps to Other

        [Description("surfing")]
        Surfing,            // Maps to WaterSport

        [Description("street_running")]
        StreetRunning,      // Maps to Running

        [Description("trail_running")]
        TrailRunning,       // Maps to Running

        [Description("indoor_running")]
        IndoorRunning       // Maps to Running
    }

    /// <summary>
    /// 活动详情接口
    /// </summary>
    public interface IActivityDetails
    {
        public int ActivityId { get; set; }
        public ActivityUUID ActivityUUID { get; set; }
        public string? ActivityName { get; set; }
        public int UserProfileId { get; set; }
        public bool IsMultiSportParent { get; set; }
        public ActivityTypeDTO ActivityTypeDTO { get; set; }
        public EventTypeDTO EventTypeDTO { get; set; }
        public AccessControlRuleDTO AccessControlRuleDTO { get; set; }
        public TimeZoneUnitDTO TimeZoneUnitDTO { get; set; }
        public MetadataDTO MetadataDTO { get; set; }
        public SummaryDTO SummaryDTO { get; set; }
        public string? LocationName { get; set; }
        public List<SplitSummary> SplitSummaries { get; set; }
    }

    /// <summary>
    /// 导出文件类型枚举
    /// </summary>
    public enum ExportFileType
    {
        tcx,
        gpx,
        kml,
        zip
    }

    /// <summary>
    /// 上传文件类型枚举
    /// </summary>
    public enum UploadFileType
    {
        tcx,
        gpx,
        fit
    }

}
