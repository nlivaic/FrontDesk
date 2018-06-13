using System;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace Scheduling.Core.Domain.Model.Interfaces {
    public interface IScheduleRepository {
        Schedule GetScheduleForDate(int clinic, DateTime date);
        void Update(Schedule schedule);
    }
}