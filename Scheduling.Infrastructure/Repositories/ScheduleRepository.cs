using System;
using System.Collections.Generic;
using System.Linq;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Enums;
using Microsoft.EntityFrameworkCore;
using Scheduling.Core.Domain.Model.Interfaces;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace Scheduling.Infrastructure.Repositories {
    public class ScheduleRepository : IScheduleRepository {
        private ScheduleContext _context;
        public ScheduleRepository(ScheduleContext context) {
            this._context = context;
        }

        public Schedule GetScheduleForDate(int clinicId, DateTime date)
        {
            Guid scheduleId = GetScheduleIdForClinic(clinicId);
            // Get all appointments on that same day, starting with 00:00:00 and ending with 23:59:00.
            IEnumerable<Appointment> appointments = _context.Appointments.Where(a => a.ScheduleId == scheduleId && a.TimeRange.StartDate >= date.Date && a.TimeRange.EndDate < date.Date.AddDays(1)).AsEnumerable();
            Schedule schedule = new Schedule(scheduleId, new DateTimeRange(date.Date, date.AddDays(1).AddSeconds(-1)), clinicId, appointments);
            return schedule;
        }

        public void Update(Schedule schedule)
        {
            _context.Attach(schedule);
            foreach (Appointment appointment in schedule.Appointments)
            {
                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entity = _context.Entry(appointment);
                switch (appointment.State)
                {
                    case TrackingState.Added:
                        entity.State = EntityState.Added;
                        break;
                    case TrackingState.Modified:
                        entity.State = EntityState.Modified;
                        break;
                    case TrackingState.Deleted:
                        entity.State = EntityState.Deleted;
                        break;
                }
            }
            _context.SaveChanges();
        }

        private Guid GetScheduleIdForClinic(int clinicId)
        {
            return _context.Schedules.Where(s => s.ClinicId == clinicId).Select(s => s.Id).Single();
        }
        
    }
}