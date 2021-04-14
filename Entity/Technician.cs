using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Technician
    {
        public string Id { get; set; }
        [Required]
        public int TechnicianId { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
