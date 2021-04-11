using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Appointment
    {
        public int Id { get; set; }
        [ForeignKey("Technician")] // one to many relatioship with Technician class given by TechnicianId 
        public int TechnicianId { get; set; }
        public string Observations { get; set; } // Details about the visit
        [Column(TypeName = "decimal(18, 2)")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public DateTime ExpectedFinalDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public DateTime RealFinalDate { get; set; }
    }
}
