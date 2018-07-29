using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;
using Scheduling.Infrastructure.ApplicationEvents;
using Scheduling.Infrastructure.Services.Interfaces;

namespace Scheduling.Infrastructure.Services
{
    public class RelayAppointmentScheduledService : IEventHandler<Core.Domain.Model.Events.AppointmentScheduledEvent>
    {
        private readonly IMessagePublisher _publisher;
        private readonly IAppointmentDTORepository _repository;
        
        #warning Create an implementation for IMessagePublisher and register it with IoC.
        public RelayAppointmentScheduledService(IAppointmentDTORepository repo, IMessagePublisher publisher)
        {
            this._repository = repo;
            this._publisher = publisher;
        }

        public void Handle(Core.Domain.Model.Events.AppointmentScheduledEvent args)
        {
            AppointmentDTO appointment = this._repository.GetFromAppointment(args.Appointment);
            ApplicationEvents.AppointmentScheduledEvent newEvent = new ApplicationEvents.AppointmentScheduledEvent(appointment);
            _publisher.Publish(newEvent);
        }
    }

}