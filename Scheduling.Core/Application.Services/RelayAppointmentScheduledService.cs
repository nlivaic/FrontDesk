using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;

namespace Scheduling.Core.Application.Services
{
    public class RelayAppointmentScheduledService : IEventHandler<AppointmentScheduledEvent>
    {
        public IMessagePublisher _publisher { get; private set; }
        
        public RelayAppointmentScheduledService(IMessagePublisher publisher)
        {
            this._publisher = publisher;
        }

        public void Handle(AppointmentScheduledEvent args)
        {
            
        }
    }

}