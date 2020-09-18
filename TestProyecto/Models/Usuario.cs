using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyecto.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Campo Teléfono obligatorio")]
        [Display(Name ="Teléfono")]
        public int Telefono{ get; set; }

        [Required(ErrorMessage ="Campo Celular obligatorio")]
        public int Celular { get; set; }


        [Required(ErrorMessage ="Campo Email obligatorio")]
        public string Email { get; set; }
    }
}
