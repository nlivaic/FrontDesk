using System;
using Scheduling.Core.Domain.Model.ScheduleAggregate;

namespace FrontDesk.Web.Models {
    public class AppointmentViewModelFactory
    {
        public AppointmentViewModel FromAppointmentViewModel(Appointment appointment)
        {
            return new AppointmentViewModel
            {
                AppointmentId = appointment.Id,
                ClientId = appointment.ClientId,
                PatientId = appointment.PatientId,
                PatientName = String.Empty,             // kamion
                RoomId = appointment.RoomId,
                StartTime = appointment.TimeRange.StartDate,
                EndTime = appointment.TimeRange.EndDate,
                AppointmentTypeId = appointment.AppointmentTypeId,
                DoctorId = appointment.DoctorId,
                Title = appointment.Title,
                IsPotentiallyConflicting = appointment.IsPotentiallyConflicting,
                IsConfirmed = (appointment.DateTimeConfirmed != null)
            };
        }
    }
}