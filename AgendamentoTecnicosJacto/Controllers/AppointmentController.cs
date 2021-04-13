using AgendamentoTecnicosJacto.Models;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public IActionResult Index(int technicianId)
        {
            var appointments = _appointmentService.GetAppointments(technicianId).Select(appointment => new AppointmentIndexModelView
            {
                Id = appointment.Id,
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
        public IActionResult Create(int technicianId)
        {
            var technician = _appointmentService.GetTechnician(technicianId);
            if (technician == null)
            {
                return NotFound();
            }
            var model = new AppointmentCreateModelView()
            {
                TechnicianName = technician.Name,
                TechnicianId = technician.TechnicianId
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
                    Id = model.Id,
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
                return RedirectToAction(nameof(Index), new { technicianId = 1 });
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
                return RedirectToAction(nameof(Index), new { technicianId = 1 });
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
            return RedirectToAction(nameof(Index), new { technicianId = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> PostcodeAPI(string postcode)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("viacep.com.br/ws/" + postcode + "/json/");

                // Now parse with JSON.Net

                return View();
            }

            
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
