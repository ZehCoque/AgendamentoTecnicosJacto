using Entity;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppointmentService : IAppointment
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Appointment newAppointment)
        {
            await _context.Appointments.AddAsync(newAppointment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int appointmentId)
        {
            var appointment = GetById(appointmentId);
            _context.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Appointment> GetAppointments(int technicianId) => _context.Appointments.Where(a => a.TechnicianId == technicianId);

        public Appointment GetById(int appointmentId) => _context.Appointments.Where(a => a.Id == appointmentId).FirstOrDefault();

        public Technician GetTechnician(string name) => _context.Technicians.Where(t => t.Email == name).FirstOrDefault();

        public async Task UpdateAsync(Appointment newAppointment)
        {
            _context.Update(newAppointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int appointmentId)
        {
            var appointment = GetById(appointmentId);
            _context.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
