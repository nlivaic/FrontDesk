using System;
using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Infrastructure.Services;

namespace Scheduling.Infrastructure.ApplicationEvents
{
    public class AppointmentConfirmedEvent : IApplicationEvent
    {
        public AppointmentConfirmedEvent(Guid appointmentId)
        {
            this.AppointmentId = appointmentId;
            this.Id = Guid.NewGuid();
            this.DateTimeOccurred = DateTime.Now;
        }
        public Guid Id { get; }
        public Guid AppointmentId { get; }
        public DateTime DateTimeOccurred { get; }
    }
}