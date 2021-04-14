using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoTecnicosJacto.Models
{
    public class AppointmentDoneViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Agendamento")]
        public string AppointmentName { get; set; }

        [DataType(DataType.Date), Display(Name = "Data de início")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date), Display(Name = "Data de término estimada")]
        public DateTime ExpectedFinalDate { get; set; }

        [Required(ErrorMessage = "Campo obrigatório"),
            DataType(DataType.Date), Display(Name = "Data de término real")]
        public DateTime RealFinalDate { get; set; } = DateTime.Today.AddDays(1);

        public bool Completed { get; set; }
    }
}
