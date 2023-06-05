using RoboContext.Domain.Enums;
using System.Text.Json.Serialization;

namespace RoboContext.Domain.Models
{
    public class RoboDTO
    {
        public RoboHeadDTO Head { get; set; } = new RoboHeadDTO();

        public RoboArmsDTO LeftArm { get; set; } = new RoboArmsDTO();

        public RoboArmsDTO RightArm { get; set; } = new RoboArmsDTO();
    }

    public class RoboHeadDTO
    {
        public int RotationAngle { get; set; } = 0;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HeadInclinationEnum Inclination { get; set; } = HeadInclinationEnum.Resting;
    }

    public class RoboArmsDTO
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ElbowStateEnum Elbow { get; set; } = ElbowStateEnum.Resting;

        public int WristRotationAngle { get; set; } = 0;
    }
}
