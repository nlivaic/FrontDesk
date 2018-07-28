using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;
using Scheduling.Infrastructure.ApplicationEvents;
using Scheduling.Infrastructure.Services.Interfaces;

namespace Scheduling.Infrastructure.Services
{
    public class RelayAppointmentScheduledService : IEventHandler<Core.Domain.Model.Events.AppointmentScheduledEvent>
    {
        public IMessagePublisher _publisher { get; private set; }
        
        #warning Create an implementation for IMessagePublisher and register it with IoC.
        public RelayAppointmentScheduledService(IMessagePublisher publisher)
        {
            this._publisher = publisher;
        }

        public void Handle(Core.Domain.Model.Events.AppointmentScheduledEvent args)
        {
            #warning Fetch AppointmentDTO via repo?
            AppointmentDTO appointment = null;
            ApplicationEvents.AppointmentScheduledEvent newEvent = new ApplicationEvents.AppointmentScheduledEvent(appointment);
            _publisher.Publish(newEvent);
        }
    }

}