using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoTecnicosJacto.Models
{
    public class AppointmentDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Código de Registro")]
        public int TechnicianId { get; set; }
        [Display(Name = "Nome do Técnico")]
        public string TechnicianName { get; set; }
        [Display(Name = "Nome do Agendamento")]
        public string AppointmentName { get; set; }
        [Display(Name = "Observação")]
        public string Observations { get; set; } // Details about the visit
        [DataType(DataType.Date), Display(Name = "Data de início")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date), Display(Name = "Data de término estimada")]
        public DateTime ExpectedFinalDate { get; set; } = DateTime.UtcNow.AddDays(1);
        [DataType(DataType.Date), Display(Name = "Data de término real")]
        public DateTime RealFinalDate { get; set; }
        [Display(Name = "Código Postal")]
        public string Postcode { get; set; }
        [Display(Name = "Endereço")]
        public string Address { get; set; }
        [Display(Name = "Cidade")]
        public string City { get; set; }
        [Display(Name = "Estado")]
        public string State { get; set; }
        [Display(Name = "Bairro")]
        public string District { get; set; }
        [Display(Name = "Número")]
        public int? Number { get; set; }
        [Display(Name = "Status")]
        public bool Completed { get; set; }
    }
}
