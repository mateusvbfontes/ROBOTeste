using RoboContext.Domain.Entities;
using RoboContext.Domain.Enums;

namespace RoboContext.Tests
{
    public class RoboArmsServiceTests
    {
        [Fact]
        public void SetElbow_ValidElbowState_SetsElbowCorrectly()
        {
            // Arrange
            var model = new RoboArmsService();
            var expectedElbowState = ElbowStateEnum.SlightlyContracted;

            // Act
            model.Elbow = expectedElbowState;

            // Assert
            Assert.Equal(expectedElbowState, model.Elbow);
        }

        [Fact]
        public void SetElbow_InvalidElbowState_ThrowsArgumentException()
        {
            // Arrange
            var model = new RoboArmsService();
            var invalidElbowState = ElbowStateEnum.Contracted;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => model.Elbow = invalidElbowState);
        }

        [Fact]
        public void SetWristRotationAngle_ValidAngle_SetsWristRotationAngleCorrectly()
        {
            // Arrange
            var model = new RoboArmsService();
            var expectedAngle = 45;

            // Act
            model.Elbow = ElbowStateEnum.SlightlyContracted;
            model.Elbow = ElbowStateEnum.Contracted;
            model.Elbow = ElbowStateEnum.TightlyContracted;
            model.WristRotationAngle = expectedAngle;

            // Assert
            Assert.Equal(expectedAngle, model.WristRotationAngle);
        }

        [Fact]
        public void SetWristRotationAngle_InvalidAngle_ThrowsArgumentException()
        {
            // Arrange
            var model = new RoboArmsService();
            var invalidAngle = 60;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => model.WristRotationAngle = invalidAngle);
        }
    }
}