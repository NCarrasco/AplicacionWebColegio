using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWebColegio.Data.Models
{
    [Table("Estudiantes")]
    public class Estudiante : Persona
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido...")]
        [Display(Name = "Matrícula")]
        [StringLength(10, ErrorMessage = "La longitud máxima del campo {0} es de {1}")]
        public string Matricula { get; set; }


        [StringLength(800, ErrorMessage = "La longitud máxima del campo {0} es de {1}")]
        public string Observaciones { get; set; }


        [Display(Name = "Fecha Matriculación")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaMatriculacion { get; set; }
    }
}
