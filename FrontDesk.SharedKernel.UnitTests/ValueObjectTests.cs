using FrontDesk.SharedKernel;
using System;
using Xunit;

namespace FrontDesk.SharedKernel.UnitTests
{
    public class ValueObjectTests
    {
        [Fact]
        public void DateTimeRange_Is_Equal()
        {
            // Arrange
            DateTimeRange timeRange1 = new DateTimeRange(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            DateTimeRange timeRange2 = new DateTimeRange(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            
            // Act
            bool result = timeRange1.Equals(timeRange2);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void DateTimeRange_Is_Not_Equal()
        {
            // Arrange
            DateTimeRange timeRange1 = new DateTimeRange(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            DateTimeRange timeRange2 = new DateTimeRange(new DateTime(2017, 5, 1), new DateTime(2017, 5, 3));
            
            // Act
            bool result = timeRange1.Equals(timeRange2);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public void DateTimeRange_One_Instance_Is_Null()
        {
            // Arrange
            DateTimeRange timeRange1 = new DateTimeRange(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            DateTimeRange timeRange2 = null;
            
            // Act
            bool result = timeRange1.Equals(timeRange2);

            // Assert
            Assert.False(result);
        }
        
        [Fact]
        public void DateTimeRange_Derived()
        {
            // Arrange
            DateTimeRangeNew timeRange1 = new DateTimeRangeNew(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            DateTimeRangeNew timeRange2 = new DateTimeRangeNew(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            
            // Act
            bool result = timeRange1.Equals(timeRange2);

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void DateTimeRange_Equality_Operator()
        {
            // Arrange
            DateTimeRange timeRange1 = new DateTimeRange(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            DateTimeRange timeRange2 = new DateTimeRange(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            
            // Act
            bool result = timeRange1 == timeRange2;

            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void DateTimeRange_Inequality_Operator()
        {
            // Arrange
            DateTimeRange timeRange1 = new DateTimeRange(new DateTime(2018, 6, 16), new DateTime(2018, 6, 18));
            DateTimeRange timeRange2 = new DateTimeRange(new DateTime(2017, 5, 1), new DateTime(2017, 5, 3));
            
            // Act
            bool result = timeRange1 != timeRange2;

            // Assert
            Assert.True(result);
        }

        private class DateTimeRangeNew : DateTimeRange
        {
            public DateTimeRangeNew(DateTime startDate, DateTime endDate) : base(startDate, endDate) { }
            public int MyProperty { get; set; }
        }
    }
}
