using System;
using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace Scheduling.Core.Domain.Model.Events
{
    public class AppointmentConfirmedEvent : IDomainEvent
    {
        public AppointmentConfirmedEvent(Appointment appointment)
        {
            this.Appointment = appointment;
            this.Id = Guid.NewGuid();
            this.DateTimeOccurred = DateTime.Now;
        }
        public Guid Id { get; }
        public Appointment Appointment { get; }
        public DateTime DateTimeOccurred { get; }
    }
}