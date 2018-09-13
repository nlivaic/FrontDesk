using System;
using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Events;
using Scheduling.Core.Domain.Model.Interfaces;
using Scheduling.Core.Domain.Model.ScheduleAggregate;
using Scheduling.Infrastructure.ApplicationEvents;
using Scheduling.Infrastructure.Services.Interfaces;

namespace Scheduling.Infrastructure.Services
{
    public class AppointmentScheduledHandler : BaseEventHandler<Core.Domain.Model.Events.AppointmentUpdatedEvent>
    {
        private readonly IScheduleRepository _repository;
        
        public AppointmentScheduledHandler(IScheduleRepository repo)
        {
            this._repository = repo;
        }

        public override void Handle(Core.Domain.Model.Events.AppointmentUpdatedEvent args)
        {
            Schedule schedule = _repository.GetScheduleForDate(1, args.AppointmentUpdated.TimeRange.StartDate);
            schedule.Handle(args);
        }
    }
}