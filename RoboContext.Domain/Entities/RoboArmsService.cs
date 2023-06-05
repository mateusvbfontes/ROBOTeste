using System.Text.Json.Serialization;
using RoboContext.Domain.Enums;

namespace RoboContext.Domain.Entities
{    
    public class RoboArmsService
    {
        private ElbowStateEnum _elbow { get; set; } = ElbowStateEnum.Resting;

        private int _wristRotationAngle = 0;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ElbowStateEnum Elbow
        {
            get { return _elbow; }
            set
            {
                if (IsValidElbowState(value))
                {
                    _elbow = value;
                }
                else
                {
                    throw new ArgumentException("Valor inválido de estado do cotovelo!");
                }
            }
        }

        public int WristRotationAngle
        {
            get { return _wristRotationAngle; }
            set
            {
                if (_elbow != ElbowStateEnum.TightlyContracted && value != _wristRotationAngle)
                {
                    throw new ArgumentException("Só poderá movimentar o Pulso caso o Cotovelo esteja Fortemente Contraído.");

                }

                if (IsValidAngle(value))
                {
                    _wristRotationAngle = value;
                }
                else
                {
                    throw new ArgumentException("Valor inválido de rotação do pulso!");
                }
            }
        }

        private bool IsValidElbowState(ElbowStateEnum value)
        {
            var currentInclination = _elbow;

            var nextInclination = (ElbowStateEnum)((int)currentInclination + 1);
            var previousInclination = (ElbowStateEnum)((int)currentInclination - 1);

            // Check if the value is the direct next or previous inclination
            return value == nextInclination || value == previousInclination || value == currentInclination;
        }



        private bool IsValidAngle(int value)
        {
            int[] allowedAngles = { -90, -45, 0, 45, 90, 135, 180 };

            if (!allowedAngles.Contains(value))
            {
                return false;
            }

            int previousValue = _wristRotationAngle - 45;
            int nextValue = _wristRotationAngle + 45;

            // Retorna ok caso o valor esteja dentro do permitido, ou seja o mesmo
            return value == previousValue || value == nextValue || value == _wristRotationAngle;
        }



    }
}