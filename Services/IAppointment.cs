using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IAppointment
    {
        Task CreateAsync(Appointment newAppointment);
        Appointment GetById(int appointmentId);
        Task UpdateAsync(Appointment newAppointment);
        Task UpdateAsync(int appointmentId);
        Task Delete(int appointmentId);
        IEnumerable<Appointment> GetAppointments(int technicianId);
    }
}
