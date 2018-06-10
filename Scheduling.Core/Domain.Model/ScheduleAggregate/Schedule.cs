using System;
using System.Collections.Generic;
using System.Linq;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Enums;

namespace Scheduling.Core.Domain.Model.ScheduleAggregate {
    public class Schedule : Entity<Guid> {
        public int ClinicId { get; set; }        
        // Not persisted
        public DateTimeRange DateRange { get; set; }
        private List<Appointment> _appointments;
        public IEnumerable<Appointment> Appointments { 
            get 
            {
                return _appointments.AsEnumerable();
            }
            private set 
            {
                _appointments = (List<Appointment>)value;
            } 
        }
        
        public Schedule(Guid id, DateTimeRange dateRange, int clinicId, IEnumerable<Appointment> appointments) : base(id) 
        {
            this.DateRange = dateRange;
            this.ClinicId = clinicId;
            this._appointments = new List<Appointment>(appointments);

            /* Register for handling an AppointmentUpdatedEvent. */
        }
        
        /// <summary>
        /// Required by EF.
        /// </summary>
        private Schedule() : base(Guid.NewGuid()) { }

        public void AddNewAppointment(Appointment appointment)
        {
            if (_appointments.Contains(appointment))
            {
                throw new ArgumentException("Appointment already added to schedule.");
            }
            _appointments.Add(appointment);
            appointment.State = TrackingState.Added;

            /* Raise AppointmentScheduledEvent. */
        }

        public void DeleteAppointment(Appointment appointment)
        {
            if (!_appointments.Contains(appointment))
            {
                throw new ArgumentException("Appointment not scheduled.");
            }
            _appointments.Remove(appointment);
            appointment.State = TrackingState.Deleted;
        }

        // MarkConflictingAppointments
        
        /* Handle(AppointmentUpdatedEvent) */
    }
}