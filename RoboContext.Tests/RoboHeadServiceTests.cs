using RoboContext.Domain.Entities;
using RoboContext.Domain.Enums;

namespace RoboContext.Tests
{
    public class RoboHeadServiceTests
    {
        [Fact]
        public void RotationAngle_ValidAngle_SetRotationAngle()
        {
            // Arrange
            var service = new RoboHeadService();
            int angle = 45;

            // Act
            service.RotationAngle = angle;

            // Assert
            Assert.Equal(angle, service.RotationAngle);
        }

        [Theory]
        [InlineData(-90)]        
        [InlineData(90)]
        public void RotationAngle_InvalidAngle_ThrowArgumentException(int angle)
        {
            // Arrange
            var service = new RoboHeadService();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.RotationAngle = angle);
        }

        [Theory]
        [InlineData(45, HeadInclinationEnum.Downwards)]
        [InlineData(-45, HeadInclinationEnum.Downwards)]
        public void RotationAngle_InclinationDownwards_ThrowArgumentException(int angle, HeadInclinationEnum inclination)
        {
            // Arrange
            var service = new RoboHeadService();
            service.Inclination = inclination;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.RotationAngle = angle);
        }

        [Theory]
        [InlineData(45, HeadInclinationEnum.Upwards)]
        [InlineData(0, HeadInclinationEnum.Upwards)]
        [InlineData(-45, HeadInclinationEnum.Upwards)]
        public void RotationAngle_InclinationUpwards_SetRotationAngle(int angle, HeadInclinationEnum inclination)
        {
            // Arrange
            var service = new RoboHeadService();
            service.Inclination = inclination;

            // Act
            service.RotationAngle = angle;

            // Assert
            Assert.Equal(angle, service.RotationAngle);
        }

        [Fact]
        public void Inclination_ValidInclination_SetInclination()
        {
            // Arrange
            var service = new RoboHeadService();
            var inclination = HeadInclinationEnum.Upwards;

            // Act
            service.Inclination = inclination;

            // Assert
            Assert.Equal(inclination, service.Inclination);
        }

        [Theory]
        [InlineData(HeadInclinationEnum.Upwards)]
        [InlineData(HeadInclinationEnum.Downwards)]
        public void Inclination_InvalidInclination_ThrowArgumentException(HeadInclinationEnum inclination)
        {
            // Arrange
            var service = new RoboHeadService();

            if (inclination == HeadInclinationEnum.Upwards)
            {
                service.Inclination = HeadInclinationEnum.Downwards;
            }
            else if (inclination == HeadInclinationEnum.Downwards)
            {
                service.Inclination = HeadInclinationEnum.Upwards;
            }

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.Inclination = inclination);
        }    
    }
}
