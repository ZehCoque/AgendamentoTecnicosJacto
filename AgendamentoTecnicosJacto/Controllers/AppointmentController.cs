using AgendamentoTecnicosJacto.Models;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AgendamentoTecnicosJacto.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointment _appointmentService;
        public AppointmentController(IAppointment employeeService)
        {
            _appointmentService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var technicianId = _appointmentService.GetTechnician(User.Identity.Name).TechnicianId;

            var appointments = _appointmentService.GetAppointments(technicianId).Select(appointment => new AppointmentIndexModelView
            {
                AppointmentId = appointment.Id,
                TechnicianId = appointment.TechnicianId,
                TechnicianName = appointment.TechnicianName,
                AppointmentName = appointment.AppointmentName,
                StartDate = appointment.StartDate,
                ExpectedFinalDate = appointment.ExpectedFinalDate,
                RealFinalDate = appointment.RealFinalDate,
                Completed = appointment.Completed,
            }).ToList();

            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var technician = _appointmentService.GetTechnician(User.Identity.Name);
            if (technician == null)
            {
                return NotFound();
            }
            var model = new AppointmentCreateModelView()
            {
                TechnicianName = technician.Name,
                TechnicianId = technician.TechnicianId,
                TechnicianEmail = technician.Email
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Prevents cross-site Request Forgery Attacks
        public async Task<IActionResult> Create(AppointmentCreateModelView model)
        {
            if (model.StartDate > model.ExpectedFinalDate)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                var appointment = new Appointment
                {
                    Id = model.AppointmentId,
                    TechnicianId = model.TechnicianId,
                    TechnicianName = model.TechnicianName,
                    Observations = model.Observations,
                    StartDate = model.StartDate,
                    ExpectedFinalDate = model.ExpectedFinalDate,
                    Address = model.Address,
                    AppointmentName = model.AppointmentName,
                    City = model.City,
                    District = model.District,
                    Number = model.Number,
                    Postcode = model.Postcode,
                    State = model.State
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
                TechnicianName = appointment.TechnicianName,
                Observations = appointment.Observations,
                StartDate = appointment.StartDate,
                ExpectedFinalDate = appointment.ExpectedFinalDate,
                Address = appointment.Address,
                AppointmentName = appointment.AppointmentName,
                City = appointment.City,
                District = appointment.District,
                Number = appointment.Number,
                Postcode = appointment.Postcode,
                State = appointment.State
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentEditModelView model)
        {
            if (model.StartDate > model.ExpectedFinalDate)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                var appointment = _appointmentService.GetById(model.Id);
                if (appointment == null)
                {
                    return NotFound();
                }

                appointment.Observations = model.Observations;
                appointment.StartDate = model.StartDate;
                appointment.ExpectedFinalDate = model.ExpectedFinalDate;
                appointment.Address = model.Address;
                appointment.AppointmentName = model.AppointmentName;
                appointment.City = model.City;
                appointment.District = model.District;
                appointment.Number = model.Number;
                appointment.Postcode = model.Postcode;
                appointment.State = model.State;

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
                AppointmentName = appointment.AppointmentName
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AppointmentDeleteViewModel model)
        {
            await _appointmentService.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Details(int id) 
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var model = new AppointmentDetailsViewModel()
            {
                Id = appointment.Id,
                TechnicianId = appointment.TechnicianId,
                TechnicianName = appointment.TechnicianName,
                Observations = appointment.Observations,
                StartDate = appointment.StartDate,
                ExpectedFinalDate = appointment.ExpectedFinalDate,
                RealFinalDate = appointment.RealFinalDate,
                Address = appointment.Address,
                AppointmentName = appointment.AppointmentName,
                City = appointment.City,
                District = appointment.District,
                Number = appointment.Number,
                Postcode = appointment.Postcode,
                State = appointment.State
            };

            return View(model);
        }

    }
}
