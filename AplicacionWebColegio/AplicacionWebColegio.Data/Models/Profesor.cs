using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWebColegio.Data.Models
{
    [Table("Profesores")]
    public class Profesor : Persona
    {
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(800, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        public string Observaciones { get; set; }

        public bool Activo { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
    }
}
