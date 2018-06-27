using System;

namespace FrontDesk.Web.Models {

    public class AppointmentViewModel
    {
        public Guid AppointmentId { get; set; }
        public int ClientId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AppointmentTypeId { get; set; }
        public int DoctorId { get; set; }
        public string Title { get; set; }
        public bool IsPotentiallyConflicting { get; set; }
        public bool IsConfirmed { get; set; }
    }
}