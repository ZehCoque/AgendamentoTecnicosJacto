using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoTecnicosJacto.Models
{
    public class AppointmentIndexModelView
    {
        public int AppointmentId { get; set; }
        public int TechnicianId { get; set; }
        public string TechnicianName { get; set; }
        public string TechnicianEmail { get; set; }
        public string AppointmentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedFinalDate { get; set; }
        public DateTime RealFinalDate { get; set; }
        public bool Completed { get; set; }
    }
}
