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

        public void Handle(AppointmentConfirmedEvent args)
        {
            Schedule schedule = this._repository.GetScheduleForDate(1, new DateTime(2018, 6, 16));
            Appointment appointment = schedule.Appointments.Single(a => a.Id == args.AppointmentId);
            appointment.Confirm(args.DateTimeOccurred);
            _repository.Update(schedule);
        }
    }
}