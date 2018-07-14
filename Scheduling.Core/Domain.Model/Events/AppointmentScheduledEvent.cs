using System;
using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace Scheduling.Core.Domain.Model.Events
{
    public class AppointmentScheduledEvent : IDomainEvent
    {
        public AppointmentScheduledEvent(Appointment appointment) : this()
        {
            this.Appointment = appointment;
        }

        public AppointmentScheduledEvent()
        {
            Id = Guid.NewGuid();
            this.DateTimeOccurred = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime DateTimeOccurred { get; private set; }
        public Appointment Appointment { get; private set; }
    }
}