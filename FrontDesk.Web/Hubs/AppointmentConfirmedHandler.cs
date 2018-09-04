using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;

namespace FrontDesk.Web.Controllers.Hub {
    public class AppointmentConfirmedHandler : IEventHandler<AppointmentConfirmedEvent> {
        public void Handle(AppointmentConfirmedEvent args) { }
        public System.Threading.Tasks.Task Handle(AppointmentConfirmedEvent notification, System.Threading.CancellationToken cancellationToken)
        {
            // ... SignalR here.
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}