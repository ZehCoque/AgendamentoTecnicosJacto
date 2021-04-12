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
        public string TechnicianName { get; set; }
        public string AppointmentName { get; set; }
        public string Observations { get; set; } // Details about the visit
        public DateTime StartDate { get; set; }
        public DateTime ExpectedFinalDate { get; set; }
        public DateTime RealFinalDate { get; set; }
        public string Postcode { get; set; } //CEP
        public string Address { get; set; } //Logradouro
        public string City { get; set; } //Localidade
        public string District { get; set; } //Bairro
        public int? Number { get; set; } // not provided by the API
        public bool Completed { get; set; }
    }
}
