using System;
using FrontDesk.SharedKernel;

namespace Scheduling.Infrastructure.Services
{
    public class AppointmentDTO
    {
        public static AppointmentDTO Create(Guid appointmentId, string clientName, string clientEmailAddress, string patientName,
            string doctorName, DateTimeRange timeRange, int roomNumber)
        {
            return new AppointmentDTO(appointmentId, clientName, clientEmailAddress, patientName,
                doctorName, timeRange, roomNumber);
        }

        private AppointmentDTO(Guid appointmentId, string clientName, string clientEmailAddress, string patientName,
            string doctorName, DateTimeRange timeRange, int roomNumber)
        {
            this.AppointmentId = appointmentId;
            this.ClientName = clientName;
            this.ClientEmailAddress = clientEmailAddress;
            this.PatientName = patientName;
            this.DoctorName = doctorName;
            this.TimeRange = timeRange;
            this.RoomNumber = roomNumber;
        }

        public Guid AppointmentId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmailAddress { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTimeRange TimeRange { get; set; }
        public int RoomNumber { get; set; }
    }
}