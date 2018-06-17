using System;
using Xunit;

namespace FrontDesk.SharedKernel.UnitTests
{
    public class DateTimeRangeTests {
        [Fact]
        public void Is_On_Same_Day_As_TimeRange()
        {
            // Arrange
            DateTimeRange target = new DateTimeRange(new DateTime(2018, 6, 16, 12, 0, 0), new DateTime(2018, 6, 16, 12, 30, 0));
            DateTime searchOnDay = new DateTime(2018, 6, 16);

            // Act
            bool result = target.IsOnDate(searchOnDay);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void Is_Not_On_Same_Day_As_TimeRange()
        {
            // Arrange
            DateTimeRange target = new DateTimeRange(new DateTime(2018, 6, 16, 12, 0, 0), new DateTime(2018, 6, 16, 12, 30, 0));
            DateTime searchOnDay = new DateTime(2018, 6, 17);

            // Act
            bool result = target.IsOnDate(searchOnDay);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Ignores_Time_Of_Day_When_Determining_If_On_Same_Day()
        {
            // Arrange
            DateTimeRange target = new DateTimeRange(new DateTime(2018, 6, 16, 12, 0, 0), new DateTime(2018, 6, 16, 12, 30, 0));
            DateTime searchOnDay = new DateTime(2018, 6, 16, 14, 0, 0);

            // Act
            bool result = target.IsOnDate(searchOnDay);

            // Assert
            Assert.True(result);
        }
    }
}