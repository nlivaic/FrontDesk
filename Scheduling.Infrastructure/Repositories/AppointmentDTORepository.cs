using Scheduling.Core.Domain.Model.ScheduleAggregate;
using Scheduling.Infrastructure.Services;
using Scheduling.Infrastructure.Services.Interfaces;

namespace Scheduling.Infrastructure.Repositories
{
    public class AppointmentDTORepository : IAppointmentDTORepository
    {
        public AppointmentDTO GetFromAppointment(Appointment appointment)
        {
            #warning Call other Bounded Context using REST API.
            #warning For now, return a mock DTO.
            return AppointmentDTO.Create(appointment.Id, 
                                         "John Doe", 
                                         "email@gmail.com", 
                                         "Benji", 
                                         "Dr. Gray", 
                                         appointment.TimeRange, 
                                         appointment.RoomId);
        }
    }
}