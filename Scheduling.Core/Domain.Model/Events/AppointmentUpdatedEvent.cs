using System;
using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace Scheduling.Core.Domain.Model.Events
{
    public class AppointmentUpdatedEvent : IDomainEvent
    {

        public AppointmentUpdatedEvent(Appointment appointment) : this()
        {
            this.AppointmentUpdated = appointment;
        }        
        public AppointmentUpdatedEvent()
        {
            this.Id = Guid.NewGuid();
            DateTimeOccurred = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime DateTimeOccurred { get; private set; }
        public Appointment AppointmentUpdated { get; private set; }
    }
}