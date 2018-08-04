using System;
using System.Collections.Generic;
using System.Linq;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Enums;
using Scheduling.Core.Domain.Model.Events;

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

            DomainEvents.Register<AppointmentUpdatedEvent>(Handle);
        }
        
        /// <summary>
        /// Required by EF.
        /// </summary>
        private Schedule() : base(/*Guid.NewGuid()*/) 
        {
            _appointments = new List<Appointment>();
        }

        public void AddNewAppointment(Appointment appointment)
        {
            if (_appointments.Contains(appointment))
            {
                throw new ArgumentException("Appointment already added to schedule.");
            }
            _appointments.Add(appointment);
            appointment.State = TrackingState.Added;

            DomainEvents.Raise(new AppointmentScheduledEvent(appointment));
        }

        public void DeleteAppointment(Appointment appointment)
        {
            if (!_appointments.Contains(appointment))
            {
                throw new ArgumentException("Appointment not scheduled.");
            }
            appointment.State = TrackingState.Deleted;
        }

        public void MarkConflictingAppointments()
        {
            // ...
        }
        
        /// <summary>
        /// Callback.
        /// Used to maintain a business invariant on appointment conflicts.
        /// Triggered on associated appointments change.
        /// A handler is used because we do not have a reference from 
        /// Appointment back to Schedule aggregate root.
        /// </summary>
        /// <param name="args"></param>
        public void Handle(AppointmentUpdatedEvent args)
        {
            MarkConflictingAppointments();
        }
    }
}