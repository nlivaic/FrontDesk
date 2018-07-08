using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;

namespace FrontDesk.Web.Controllers.Hub {
    public class AppointmentUpdatedHandler : IEventHandler<AppointmentUpdatedEvent> {
        public void Handle(AppointmentUpdatedEvent args)
        {
            // ... SignalR here.
        }
    }
}