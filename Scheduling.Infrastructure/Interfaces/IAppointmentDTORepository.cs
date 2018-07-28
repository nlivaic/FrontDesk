using Scheduling.Core.Domain.Model.ScheduleAggregate;
using Scheduling.Infrastructure.Services;

namespace Scheduling.Core.ScheduleAggregate.Infrastructure.Interfaces
{
    #warning Create an implementation.
    public interface IAppointmentDTORepository
    {
        AppointmentDTO GetFromAppointment(Appointment appointment);
    }
}