namespace GarminModels
{
    /// <summary>
    /// 活动接口
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// 活动ID
        /// </summary>
        public long ActivityId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string? ActivityName { get; set; }

        /// <summary>
        /// 本地开始时间
        /// </summary>
        public string? StartTimeLocal { get; set; }

        /// <summary>
        /// GMT开始时间
        /// </summary>
        public string? StartTimeGMT { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        public ActivityTypeInfo ActivityType { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        public EventTypeInfo EventType { get; set; }

        /// <summary>
        /// 距离
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// 持续时间
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// 总耗时
        /// </summary>
        public double ElapsedDuration { get; set; }

        /// <summary>
        /// 移动时间
        /// </summary>
        public double MovingDuration { get; set; }

        /// <summary>
        /// 海拔上升
        /// </summary>
        public double ElevationGain { get; set; }

        /// <summary>
        /// 海拔下降
        /// </summary>
        public double ElevationLoss { get; set; }

        /// <summary>
        /// 平均速度
        /// </summary>
        public double AverageSpeed { get; set; }

        /// <summary>
        /// 最大速度
        /// </summary>
        public double MaxSpeed { get; set; }

        /// <summary>
        /// 起点纬度
        /// </summary>
        public double StartLatitude { get; set; }

        /// <summary>
        /// 起点经度
        /// </summary>
        public double StartLongitude { get; set; }

        /// <summary>
        /// 是否有轨迹线
        /// </summary>
        public bool HasPolyline { get; set; }

        /// <summary>
        /// 是否有图片
        /// </summary>
        public bool HasImages { get; set; }

        /// <summary>
        /// 拥有者ID
        /// </summary>
        public long OwnerId { get; set; }

        /// <summary>
        /// 拥有者显示名称
        /// </summary>
        public string? OwnerDisplayName { get; set; }

        /// <summary>
        /// 拥有者全名
        /// </summary>
        public string? OwnerFullName { get; set; }

        /// <summary>
        /// 拥有者头像（小图）
        /// </summary>
        public string? OwnerProfileImageUrlSmall { get; set; }

        /// <summary>
        /// 拥有者头像（中图）
        /// </summary>
        public string? OwnerProfileImageUrlMedium { get; set; }

        /// <summary>
        /// 拥有者头像（大图）
        /// </summary>
        public string? OwnerProfileImageUrlLarge { get; set; }

        /// <summary>
        /// 消耗卡路里
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// 基础代谢消耗卡路里
        /// </summary>
        public double BmrCalories { get; set; }

        /// <summary>
        /// 平均心率
        /// </summary>
        public double AverageHR { get; set; }

        /// <summary>
        /// 最大心率
        /// </summary>
        public double MaxHR { get; set; }

        /// <summary>
        /// 用户角色列表
        /// </summary>
        public List<string> UserRoles { get; set; }

        /// <summary>
        /// 隐私设置
        /// </summary>
        public PrivacyInfo Privacy { get; set; }

        /// <summary>
        /// 是否是专业用户
        /// </summary>
        public bool UserPro { get; set; }

        /// <summary>
        /// 是否有视频
        /// </summary>
        public bool HasVideo { get; set; }

        /// <summary>
        /// 时区ID
        /// </summary>
        public int TimeZoneId { get; set; }

        /// <summary>
        /// 开始时间戳
        /// </summary>
        public long BeginTimestamp { get; set; }

        /// <summary>
        /// 运动类型ID
        /// </summary>
        public int SportTypeId { get; set; }

        /// <summary>
        /// 有氧训练效果
        /// </summary>
        public double AerobicTrainingEffect { get; set; }

        /// <summary>
        /// 无氧训练效果
        /// </summary>
        public double AnaerobicTrainingEffect { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public long DeviceId { get; set; }

        /// <summary>
        /// 最低温度
        /// </summary>
        public double MinTemperature { get; set; }

        /// <summary>
        /// 最高温度
        /// </summary>
        public double MaxTemperature { get; set; }

        /// <summary>
        /// 最低海拔
        /// </summary>
        public double MinElevation { get; set; }

        /// <summary>
        /// 最高海拔
        /// </summary>
        public double MaxElevation { get; set; }

        /// <summary>
        /// 潜水总结信息
        /// </summary>
        public SummarizedDiveInfo SummarizedDiveInfo { get; set; }

        /// <summary>
        /// 最大垂直速度
        /// </summary>
        public double MaxVerticalSpeed { get; set; }

        /// <summary>
        /// 设备制造商
        /// </summary>
        public string? Manufacturer { get; set; }

        /// <summary>
        /// 位置名称
        /// </summary>
        public string? LocationName { get; set; }

        /// <summary>
        /// 圈数
        /// </summary>
        public int LapCount { get; set; }

        /// <summary>
        /// 终点纬度
        /// </summary>
        public double EndLatitude { get; set; }

        /// <summary>
        /// 终点经度
        /// </summary>
        public double EndLongitude { get; set; }

        /// <summary>
        /// 估计消耗水量
        /// </summary>
        public double WaterEstimated { get; set; }

        /// <summary>
        /// 训练效果标签
        /// </summary>
        public string? TrainingEffectLabel { get; set; }

        /// <summary>
        /// 活动训练负荷
        /// </summary>
        public double ActivityTrainingLoad { get; set; }

        /// <summary>
        /// 最短圈时长
        /// </summary>
        public double MinActivityLapDuration { get; set; }

        /// <summary>
        /// 有氧训练效果描述
        /// </summary>
        public string? AerobicTrainingEffectMessage { get; set; }

        /// <summary>
        /// 无氧训练效果描述
        /// </summary>
        public string? AnaerobicTrainingEffectMessage { get; set; }

        /// <summary>
        /// 分段总结
        /// </summary>
        public List<double> SplitSummaries { get; set; }

        /// <summary>
        /// 是否有分段
        /// </summary>
        public bool HasSplits { get; set; }

        /// <summary>
        /// 身体电量变化
        /// </summary>
        public int DifferenceBodyBattery { get; set; }

        /// <summary>
        /// 是否有热力图
        /// </summary>
        public bool HasHeatMap { get; set; }

        /// <summary>
        /// 心率区间1时间
        /// </summary>
        public double HrTimeInZone_1 { get; set; }

        /// <summary>
        /// 心率区间2时间
        /// </summary>
        public double HrTimeInZone_2 { get; set; }

        /// <summary>
        /// 心率区间3时间
        /// </summary>
        public double HrTimeInZone_3 { get; set; }

        /// <summary>
        /// 心率区间4时间
        /// </summary>
        public double HrTimeInZone_4 { get; set; }

        /// <summary>
        /// 心率区间5时间
        /// </summary>
        public double HrTimeInZone_5 { get; set; }

        /// <summary>
        /// GMT结束时间
        /// </summary>
        public string? EndTimeGMT { get; set; }

        /// <summary>
        /// 是否为合格潜水
        /// </summary>
        public bool QualifyingDive { get; set; }

        /// <summary>
        /// 是否为有目的活动
        /// </summary>
        public bool Purposeful { get; set; }

        /// <summary>
        /// 是否为手动录入活动
        /// </summary>
        public bool ManualActivity { get; set; }

        /// <summary>
        /// 是否为个人最佳
        /// </summary>
        public bool Pr { get; set; }

        /// <summary>
        /// 是否自动计算卡路里
        /// </summary>
        public bool AutoCalcCalories { get; set; }

        /// <summary>
        /// 是否校正海拔
        /// </summary>
        public bool ElevationCorrected { get; set; }

        /// <summary>
        /// 是否为ATP活动
        /// </summary>
        public bool AtpActivity { get; set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool Favorite { get; set; }

        /// <summary>
        /// 是否为减压潜水
        /// </summary>
        public bool DecoDive { get; set; }

        /// <summary>
        /// 是否为父活动
        /// </summary>
        public bool Parent { get; set; }

        public string? Comments { get; set; }
        public string? ParentId { get; set; }
        public double AverageRunningCadenceInStepsPerMinute { get; set; }
        public double MaxRunningCadenceInStepsPerMinute { get; set; }
        public double AverageBikingCadenceInRevPerMinute { get; set; }
        public double MaxBikingCadenceInRevPerMinute { get; set; }
        public double AverageSwimCadenceInStrokesPerMinute { get; set; }
        public double MaxSwimCadenceInStrokesPerMinute { get; set; }
        public double AverageSwolf { get; set; }
        public double ActiveLengths { get; set; }
        public string? Steps { get; set; }
        public double ConversationUuid { get; set; }
        public double ConversationPk { get; set; }
        public double NumberOfActivityLikes { get; set; }
        public double NumberOfActivityComments { get; set; }
        public double LikedByUser { get; set; }
        public double CommentedByUser { get; set; }
        public double ActivityLikeDisplayNames { get; set; }
        public double ActivityLikeFullNames { get; set; }
        public double ActivityLikeProfileImageUrls { get; set; }
        public double RequestorRelationship { get; set; }
        public double CourseId { get; set; }
        public double PoolLength { get; set; }
        public double UnitOfPoolLength { get; set; }
        public double VideoUrl { get; set; }
        public double AvgPower { get; set; }
        public double MaxPower { get; set; }
        public double Strokes { get; set; }
        public double NormPower { get; set; }
        public double LeftBalance { get; set; }
        public double RightBalance { get; set; }
        public double AvgLeftBalance { get; set; }
        public double Max20MinPower { get; set; }
        public double AvgVerticalOscillation { get; set; }
        public double AvgGroundContactTime { get; set; }
        public double AvgStrideLength { get; set; }
        public double AvgFractionalCadence { get; set; }
        public double MaxFractionalCadence { get; set; }
        public double TrainingStressScore { get; set; }
        public double IntensityFactor { get; set; }
        public double VO2MaxValue { get; set; }
        public double AvgVerticalRatio { get; set; }
        public double AvgGroundContactBalance { get; set; }
        public double LactateThresholdBpm { get; set; }
        public double LactateThresholdSpeed { get; set; }
        public double MaxFtp { get; set; }
        public double AvgStrokeDistance { get; set; }
        public double AvgStrokeCadence { get; set; }
        public double MaxStrokeCadence { get; set; }
        public double WorkoutId { get; set; }
        public double AvgStrokes { get; set; }
        public double MinStrokes { get; set; }
        public double AvgDoubleCadence { get; set; }
        public double MaxDoubleCadence { get; set; }
        public double SummarizedExerciseSets { get; set; }
        public double MaxDepth { get; set; }
        public double AvgDepth { get; set; }
        public double SurfaceInterval { get; set; }
        public double StartN2 { get; set; }
        public double EndN2 { get; set; }
        public double StartCns { get; set; }
        public double EndCns { get; set; }
        public double ActivityLikeAuthors { get; set; }
        public double AvgVerticalSpeed { get; set; }
        public double FloorsClimbed { get; set; }
        public double FloorsDescended { get; set; }
        public double DiveNumber { get; set; }
        public double BottomTime { get; set; }
        public double MinAirSpeed { get; set; }
        public double MaxAirSpeed { get; set; }
        public double AvgAirSpeed { get; set; }
        public double AvgWindYawAngle { get; set; }
        public double MinCda { get; set; }
        public double MaxCda { get; set; }
        public double AvgCda { get; set; }
        public double AvgWattsPerCda { get; set; }
        public double Flow { get; set; }
        public double Grit { get; set; }
        public double JumpCount { get; set; }
        public double CaloriesEstimated { get; set; }
        public double CaloriesConsumed { get; set; }
        public double WaterConsumed { get; set; }
        public double MaxAvgPower_1 { get; set; }
        public double MaxAvgPower_2 { get; set; }
        public double MaxAvgPower_5 { get; set; }
        public double MaxAvgPower_10 { get; set; }
        public double MaxAvgPower_20 { get; set; }
        public double MaxAvgPower_30 { get; set; }
        public double MaxAvgPower_60 { get; set; }
        public double MaxAvgPower_120 { get; set; }
        public double MaxAvgPower_300 { get; set; }
        public double MaxAvgPower_600 { get; set; }
        public double MaxAvgPower_1200 { get; set; }
        public double MaxAvgPower_1800 { get; set; }
        public double MaxAvgPower_3600 { get; set; }
        public double MaxAvgPower_7200 { get; set; }
        public double MaxAvgPower_18000 { get; set; }
        public double ExcludeFromPowerCurveReports { get; set; }
        public double TotalSets { get; set; }
        public double ActiveSets { get; set; }
        public double TotalReps { get; set; }
        public double MinRespirationRate { get; set; }
        public double MaxRespirationRate { get; set; }
        public double AvgRespirationRate { get; set; }
        public double AvgFlow { get; set; }
        public double AvgGrit { get; set; }
        public double AvgStress { get; set; }
        public double StartStress { get; set; }
        public double EndStress { get; set; }
        public double DifferenceStress { get; set; }
        public double MaxStress { get; set; }
        public double MaxBottomTime { get; set; }
        public double HasSeedFirstbeatProfile { get; set; }
        public double CalendarEventId { get; set; }
        public double CalendarEventUuid { get; set; }
        public double AvgGradeAdjustedSpeed { get; set; }
        public double AvgWheelchairCadence { get; set; }
    }
}
