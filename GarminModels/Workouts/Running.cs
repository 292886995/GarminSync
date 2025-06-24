using System.Text.Json;

namespace GarminModels
{
    /// <summary>
    /// 跑步
    /// </summary>
    public class Running
    {
        /// <summary>
        /// 跑步数据
        /// </summary>
        private RunningWorkout _data;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Running()
        {
            _data = RunningWorkoutFactory.CreateDefault();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get => _data.WorkoutName;
            set => _data.WorkoutName = value ?? string.Empty;
        }

        /// <summary>
        /// 距离
        /// </summary>
        public double Distance
        {
            get
            {
                // 取第一个训练段第一个训练步骤的结束条件值，若为 null 返回 0
                var value = _data?.WorkoutSegments?[0]?.WorkoutSteps?[0]?.EndConditionValue;
                return value ?? 0;
            }
            set
            {
                if (_data?.WorkoutSegments != null && _data.WorkoutSegments.Count > 0 &&
                    _data.WorkoutSegments[0].WorkoutSteps != null && _data.WorkoutSegments[0].WorkoutSteps.Count > 0)
                {
                    _data.WorkoutSegments[0].WorkoutSteps[0].EndConditionValue = Math.Round(value);
                }
            }
        }

        /// <summary>
        /// 锻炼ID
        /// </summary>
        public string WorkoutId
        {
            get => _data.WorkoutId;
            set => _data.WorkoutId = value;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get => _data.Description;
            set => _data.Description = value;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && Distance > 0;
        }

        /// <summary>
        /// 将跑步数据转换为 JSON 字符串
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            // 修复错误：将 _data 序列化为 JSON 字符串
            return JsonSerializer.Serialize(_data);
        }

        /// <summary>
        /// 将跑步对象转换为字符串表示形式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}, {(Distance / 1000):F2}km";
        }
    }
}
