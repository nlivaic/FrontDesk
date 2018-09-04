using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;

namespace FrontDesk.Web.Controllers.Hub {
    public class AppointmentUpdatedHandler : IEventHandler<AppointmentUpdatedEvent> {
        public void Handle(AppointmentUpdatedEvent args) { }
        public System.Threading.Tasks.Task Handle(AppointmentUpdatedEvent notification, System.Threading.CancellationToken cancellationToken)
        {
            // ... SignalR here.
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}