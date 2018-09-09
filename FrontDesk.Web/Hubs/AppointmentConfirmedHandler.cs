using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;

namespace FrontDesk.Web.Controllers.Hub {
    public class AppointmentConfirmedHandler : BaseEventHandler<AppointmentConfirmedEvent> {
        public override void Handle(AppointmentConfirmedEvent args)
        {
            // ... SignalR here.
        }
    }
}