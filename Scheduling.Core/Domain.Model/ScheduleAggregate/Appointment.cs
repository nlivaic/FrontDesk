using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Enums;
using Scheduling.Core.Domain.Model.Events;
using System;

namespace Scheduling.Core.Domain.Model.ScheduleAggregate {
    public class Appointment : Entity<Guid> {
        public Guid ScheduleId { get; private set; }
        public DateTimeRange TimeRange { get; private set; }
        public int ClientId { get; private set; }
        public int PatientId { get; private set; }
        public int RoomId { get; private set; }
        public int DoctorId { get; private set; }
        public int AppointmentTypeId { get; private set; }
        public string Title { get; private set; }
        public DateTime? DateTimeConfirmed { get; private set; }
        // Not persisted
        public TrackingState State { get; set; }
        // Not persisted
        public bool IsPotentiallyConflicting { get; set; }
        
        public Appointment(Guid id) : base(id) { }
        
        /// <summary>
        /// Required by EF.
        /// </summary>
        private Appointment() : base(/*Guid.NewGuid()*/) { }

        public void UpdateRoom(int roomId)
        {
            this.RoomId = roomId;
            AppointmentUpdatedEvent appointmentUpdated = new AppointmentUpdatedEvent(this);
            this.State = TrackingState.Modified;
            AddDomainEvent(appointmentUpdated);
        }
        public void UpdateTime(DateTimeRange timeRange)
        {
            this.TimeRange = timeRange;
            AppointmentUpdatedEvent appointmentUpdated = new AppointmentUpdatedEvent(this);
            this.State = TrackingState.Modified;
            AddDomainEvent(appointmentUpdated);
        }
        public void Confirm(DateTime dateConfirmed)
        {
            if (!DateTimeConfirmed.HasValue)
            {
                DateTimeConfirmed = dateConfirmed;
            }
            AddDomainEvent(new AppointmentConfirmedEvent(this));
        }
        public static Appointment Create(Guid scheduleId, 
            int clientId, int patientId, int roomId, 
            DateTime startTime, DateTime endTime, 
            int appointmentTypeId, int doctorId, string title)
        {
            Appointment appointment = new Appointment(Guid.NewGuid());
            appointment.ScheduleId = scheduleId;
            appointment.ClientId = clientId;
            appointment.PatientId = patientId;
            appointment.RoomId = roomId;
            appointment.TimeRange = new DateTimeRange(startTime, endTime);
            appointment.AppointmentTypeId = appointmentTypeId;
            appointment.DoctorId = doctorId;
            appointment.Title = title;

            return appointment;
        }
    }
}