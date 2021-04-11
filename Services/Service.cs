using Entity;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class Service : IAppointment
    {
        private readonly ApplicationDbContext _context;

        public Service(ApplicationDbContext context)
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
        public Task UpdateAsync(Appointment newAppointment)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int appointmentId)
        {
            var appointment = GetById(appointmentId);
            _context.Update(appointmentId);
            await _context.SaveChangesAsync();
        }
    }
}
