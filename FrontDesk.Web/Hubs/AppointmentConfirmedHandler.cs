using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;

namespace FrontDesk.Web.Controllers.Hub {
    public class AppointmentConfirmedHandler : IEventHandler<AppointmentConfirmedEvent> {
        public void Handle(AppointmentConfirmedEvent args)
        {
            // ... SignalR here.
        }
    }
}