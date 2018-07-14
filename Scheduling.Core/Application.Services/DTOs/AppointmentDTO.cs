using System;
using FrontDesk.SharedKernel;

namespace Scheduling.Core.Application.Services.DTOs
{
    public class AppointmentDTO
    {
        public Guid AppointmentId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmailAddress { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTimeRange TimeRange { get; set; }
        public int RoomNumber { get; set; }
    }
}