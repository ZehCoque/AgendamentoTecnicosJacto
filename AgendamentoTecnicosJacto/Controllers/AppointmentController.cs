using AgendamentoTecnicosJacto.Models;
using Entity;
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

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevents cross-site Request Forgery Attacks
        public async Task<IActionResult> Create(AppointmentCreateModelView model)
        {
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    Id = model.Id,
                    TechnicianId = model.TechnicianId,
                    Observations = model.Observations,
                    StartDate = model.StartDate,
                    ExpectedFinalDate = model.ExpectedFinalDate,
                    RealFinalDate = model.RealFinalDate

                };
                await _appointmentService.CreateAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) //get info before editting
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            var model = new AppointmentEditModelView()
            {
                Id = appointment.Id,
                TechnicianId = appointment.TechnicianId,
                Observations = appointment.Observations,
                StartDate = appointment.StartDate,
                ExpectedFinalDate = appointment.ExpectedFinalDate,
                RealFinalDate = appointment.RealFinalDate

            };
            return View(model);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentEditModelView model)
        {
            if (ModelState.IsValid)
            {
                var appointment = _appointmentService.GetById(model.Id);
                if (appointment == null)
                {
                    return NotFound();
                }
                
                appointment.Id = model.Id;
                appointment.TechnicianId = model.TechnicianId;
                appointment.Observations = model.Observations;
                appointment.StartDate = model.StartDate;
                appointment.ExpectedFinalDate = model.ExpectedFinalDate;
                appointment.RealFinalDate = model.RealFinalDate;

                await _appointmentService.UpdateAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            var model = new AppointmentDeleteViewModel()
            {
                Id = appointment.Id,
                TechnicianId = appointment.TechnicianId
            };
            return View(model);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AppointmentDeleteViewModel model)
        {
            await _appointmentService.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
