using System;
using System.Linq;
using FrontDesk.SharedKernel.Interfaces;
using Scheduling.Core.Domain.Model.Interfaces;
using Scheduling.Core.Domain.Model.ScheduleAggregate;
using Scheduling.Infrastructure.ApplicationEvents;

namespace Scheduling.Infrastructure.Services
{
    public class EmailConfirmationHandler : IEventHandler<AppointmentConfirmedEvent>
    {
        private readonly IScheduleRepository _repository;
        public EmailConfirmationHandler(IScheduleRepository repository)
        {
            this._repository = repository;
        }

        public void Handle(AppointmentConfirmedEvent args) { }
        public System.Threading.Tasks.Task Handle(AppointmentConfirmedEvent args, System.Threading.CancellationToken cancellationToken)
        {
            Schedule schedule = this._repository.GetScheduleForDate(1, new DateTime(2018, 6, 16));
            Appointment appointment = schedule.Appointments.Single(a => a.Id == args.AppointmentId);
            appointment.Confirm(args.DateTimeOccurred);
            _repository.Update(schedule);
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}