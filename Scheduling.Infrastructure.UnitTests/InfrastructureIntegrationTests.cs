using System;
using Scheduling.Core.Domain.Model.ScheduleAggregate;
using Scheduling.Infrastructure.Repositories;
using Xunit;

namespace Scheduling.Infrastructure.UnitTests
{
    public class InfrastructureIntegrationTests
    {
        [Fact]
        public void Can_fetch_schedule_by_schedule_id_and_date()
        {
            // Arrange
            ScheduleContext context = new ScheduleContext();
            ScheduleRepository target = new ScheduleRepository(context);

            // Act
            Schedule result = target.GetScheduleForDate(1, new DateTime(2018, 6, 17));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ClinicId);
        }
    }
}
