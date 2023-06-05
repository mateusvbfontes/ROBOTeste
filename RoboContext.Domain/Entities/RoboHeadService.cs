using RoboContext.Domain.Enums;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[assembly: InternalsVisibleTo("RoboContext.Tests")]
namespace RoboContext.Domain.Entities
{
    public class RoboHeadService
    {
        private int _rotationAngle = 0;
        private HeadInclinationEnum _inclination { get; set; } = HeadInclinationEnum.Resting;

        public int RotationAngle
        {
            get { return _rotationAngle; }
            set
            {
                if (_inclination == HeadInclinationEnum.Downwards && value != _rotationAngle)
                {
                    throw new ArgumentException("Só poderá Rotacionar a Cabeça caso sua Inclinação da Cabeça não esteja em estado Para Baixo.");
                }

                if (IsValidAngle(value))
                {
                    _rotationAngle = value;
                }
                else
                {
                    throw new ArgumentException("Valor inválido de rotação da cabeça!");
                }
            }
        }


        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HeadInclinationEnum Inclination
        {
            get { return _inclination; }
            set
            {
                if (IsValidInclination(value))
                {
                    _inclination = value;
                }
                else
                {
                    throw new ArgumentException("Valor inválido de inclinação da cabeça!");
                }
            }
        }

        private bool IsValidAngle(int value)
        {
            int[] allowedAngles = { -90, -45, 0, 45, 90 };

            if (!allowedAngles.Contains(value))
            {
                return false;
            }

            int previousValue = _rotationAngle - 45;
            int nextValue = _rotationAngle + 45;

            // Retorna ok caso o valor esteja dentro do permitido, ou seja o mesmo
            return value == previousValue || value == nextValue || value == _rotationAngle;
        }


        private bool IsValidInclination(HeadInclinationEnum value)
        {
            // Get the current inclination value
            HeadInclinationEnum currentInclination = _inclination;

            // Get the next and previous inclination values
            HeadInclinationEnum nextInclination = (HeadInclinationEnum)((int)currentInclination + 1);
            HeadInclinationEnum previousInclination = (HeadInclinationEnum)((int)currentInclination - 1);

            // Check if the value is the direct next or previous inclination
            return value == nextInclination || value == previousInclination || value == currentInclination;
        }

    }
}