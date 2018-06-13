using System;
using Scheduling.Core.Domain.Model.Interfaces;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace Scheduling.Infrastructure.Repositories {
    public class ScheduleRepository : IScheduleRepository {
        public ScheduleRepository() {
            
        }

        public Schedule GetScheduleForDate(int clinic, DateTime date)
        {
            return new Schedule();
        }

        public void Update(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}