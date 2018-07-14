using System;
using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Application.Services.DTOs;

namespace Scheduling.Core.Application.Services.ApplicationEvents
{
    public class AppointmentScheduledEvent : IApplicationEvent
    {
        public AppointmentScheduledEvent(AppointmentDTO appointment)
        {
            this.Appointment = appointment;
            this.Id = Guid.NewGuid();
            this.DateTimeOccurred = DateTime.Now;
        }
        public Guid Id { get; }
        public AppointmentDTO Appointment { get; }
        public DateTime DateTimeOccurred { get; }
    }
}