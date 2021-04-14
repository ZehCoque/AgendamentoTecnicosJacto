using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoTecnicosJacto.Models
{
    public class AppointmentCreateModelView
    {

        public int AppointmentId { get; set; }
        [Display(Name = "Código de Registro")]
        public int TechnicianId { get; set; }
        [Display(Name = "Email")]
        public string TechnicianEmail { get; set; }
        [Display(Name = "Nome do Técnico")]
        public string TechnicianName { get; set; }
        [Required(ErrorMessage = "Campo obrigatório"), 
            Display(Name = "Nome do Agendamento")]
        public string AppointmentName { get; set; }
        [Display(Name = "Observação")]
        public string Observations { get; set; } // Details about the visit
        [Required(ErrorMessage = "Campo obrigatório"), 
            DataType(DataType.DateTime), Display(Name = "Data de início")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Campo obrigatório"),
            DataType(DataType.DateTime), Display(Name = "Data de término estimada")]
        public DateTime ExpectedFinalDate { get; set; } = DateTime.UtcNow.AddDays(1);
        [Required(ErrorMessage = "Campo obrigatório"), RegularExpression(@"^[0-9]*$"),
            Display(Name = "Código Postal")]
        public string Postcode { get; set; } 
        [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Endereço")]
        public string Address { get; set; } 
        [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Cidade")]
        public string City { get; set; }
        [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Estado")]
        public string State { get; set; }
        [Required(ErrorMessage = "Campo obrigatório"), Display(Name = "Bairro")]
        public string District { get; set; }
        [Display(Name = "Número")]
        public int? Number { get; set; }
        public bool Completed { get; set; } = false;
    }
}
