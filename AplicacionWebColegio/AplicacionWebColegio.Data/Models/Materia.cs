using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWebColegio.Data.Models
{
    [Table("Materias")]
    public class Materia
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(80, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string Nombre { get; set; }


        [StringLength(80, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string Area { get; set; }


        [Display(Name = "Cant. Horas")]
        public int Horas { get; set; }


        public bool Activa { get; set; }



        public Materia()
        {
            Activa = true; 
        }

    }
}
