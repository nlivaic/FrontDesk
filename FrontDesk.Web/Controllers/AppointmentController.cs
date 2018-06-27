using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Core.Domain.Model.Interfaces;
using Scheduling.Core.Domain.Model.ScheduleAggregate;
using System.Linq;
using FrontDesk.Web.Models;

namespace FrontDesk.Web.Controllers.Home {
    public class AppointmentController : Controller {
        private IScheduleRepository _repository;
        public AppointmentController(IScheduleRepository repo)
        {
            this._repository = repo;
        }

        public IActionResult Index()
        {
            AppointmentViewModelFactory factory = new AppointmentViewModelFactory();
            Schedule schedule = _repository.GetScheduleForDate(1, new DateTime(2018, 6, 16));

            IEnumerable<AppointmentViewModel> appointmentVMs = 
                schedule.Appointments.Select(a => factory.FromAppointmentViewModel(a)).OrderBy(a => a.StartTime);
            return View(appointmentVMs);
        }

        public IActionResult Create()
        {
            return View(nameof(Edit), new AppointmentViewModel());
        }

        [HttpGet]
        public IActionResult Edit(Guid appointmentId, DateTime startDate)
        {
            
            Schedule schedule = _repository.GetScheduleForDate(1, startDate);
            AppointmentViewModel appointmentVM = new AppointmentViewModelFactory().FromAppointmentViewModel(schedule.Appointments.Single(a => a.Id == appointmentId));
            return View(appointmentVM);
        }


        [HttpPost]
        public void Edit(AppointmentViewModel appointment)
        {
            Schedule schedule = _repository.GetScheduleForDate(1, new DateTime(2016, 6, 17));
            Appointment newAppointment = Appointment.Create(schedule.Id, appointment.ClientId, appointment.PatientId, 
                               appointment.RoomId, appointment.StartTime, appointment.EndTime, 
                               appointment.AppointmentTypeId, appointment.DoctorId, appointment.Title);
            schedule.AddNewAppointment(newAppointment);
            _repository.Update(schedule);
        }
    }

}