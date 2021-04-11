using AgendamentoTecnicosJacto.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoTecnicosJacto.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointment _appointmentService;
        public AppointmentController(IAppointment employeeService)
        {
            _appointmentService = employeeService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new AppointmentCreateModelView();
            return View(model);
        }
    }
}
