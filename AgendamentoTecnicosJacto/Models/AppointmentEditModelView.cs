using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoTecnicosJacto.Models
{
    public class AppointmentEditModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O código de registro é obrigatório"),
            Display(Name = "Código de Registro")]
        public int TechnicianId { get; set; }
        [Display(Name = "Código de Registro")]
        public string Observations { get; set; } // Details about the visit
        [DataType(DataType.Date), Display(Name = "Data de início")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date), Display(Name = "Data de término estimada")]
        public DateTime ExpectedFinalDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Data de término real")]
        public DateTime RealFinalDate { get; set; }
    }
}
