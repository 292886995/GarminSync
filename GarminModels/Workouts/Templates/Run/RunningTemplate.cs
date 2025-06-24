using System.ComponentModel;
using System.Reflection;

namespace GarminModels
{
    /// <summary>
    /// 跑步锻炼工厂
    /// </summary>
    public static class RunningWorkoutFactory
    {
        /// <summary>
        /// 创建默认的跑步锻炼实例
        /// </summary>
        /// <returns>跑步锻炼实例</returns>
        public static RunningWorkout CreateDefault()
        {
            return new RunningWorkout
            {
                Description = null,
                WorkoutId = null,
                SportType = new SportType
                {
                    SportTypeId = 1,
                    SportTypeKey = GetEnumDescription(SportTypeKey.running)
                },
                WorkoutName = string.Empty,
                WorkoutSegments = new List<WorkoutSegment>
                    {
                        new WorkoutSegment
                        {
                            SegmentOrder = 1,
                            SportType = new SportType
                            {
                                SportTypeId = 1,
                                SportTypeKey = GetEnumDescription(SportTypeKey.running)
                            },
                            WorkoutSteps = new List<WorkoutStep> // Fix: Change type to List<IWorkoutStep>
                            {
                                new WorkoutStep
                                {
                                    Type = WorkoutStepType.executableStepDTO,
                                    StepId = null,
                                    StepOrder = 1,
                                    ChildStepId = null,
                                    Description = null,
                                    StepType = new StepType
                                    {
                                        StepTypeId = 3,
                                        StepTypeKey = GetEnumDescription(StepTypeKey.interval)
                                    },
                                    EndCondition = new EndCondition
                                    {
                                        ConditionTypeKey = ConditionTypeKey.distance,
                                        ConditionTypeId = 3
                                    },
                                    PreferredEndConditionUnit = new PreferredEndConditionUnit
                                    {
                                        UnitKey = UnitKey.kilometer
                                    },
                                    EndConditionValue = null,
                                    EndConditionCompare = null,
                                    EndConditionZone = null,
                                    TargetType = new TargetType
                                    {
                                        WorkoutTargetTypeId = 1,
                                        WorkoutTargetTypeKey = GetEnumDescription(WorkoutTargetTypeKey.noTarget)
                                    },
                                    TargetValueOne = null,
                                    TargetValueTwo = null,
                                    ZoneNumber = null
                                }
                            }
                        }
                    }
            };
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttribute<DescriptionAttribute>();
            return attr != null ? attr.Description : value.ToString();
        }
    }
}
