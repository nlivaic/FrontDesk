using System;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Core.Domain.Model.Interfaces;

namespace FrontDesk.Web.Controllers.Home {
    public class AppointmentController : Controller {
        private IScheduleRepository _repository;
        public AppointmentController(IScheduleRepository repo)
        {
            this._repository = repo;
        }

        public IActionResult Index()
        {
            return View(_repository.GetScheduleForDate(1, DateTime.Now));
        }
    }
}