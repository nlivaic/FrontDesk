using Scheduling.Core.Domain.Model.ScheduleAggregate;
using Scheduling.Infrastructure.Services;

namespace Scheduling.Infrastructure.Services.Interfaces
{
    public interface IAppointmentDTORepository
    {
        AppointmentDTO GetFromAppointment(Appointment appointment);
    }
}