using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;

namespace FrontDesk.Web.Controllers.Hub {
    public class AppointmentUpdatedHandler : BaseEventHandler<AppointmentUpdatedEvent> {
        public override void Handle(AppointmentUpdatedEvent args)
        {
            // ... SignalR here.
        }
    }
}