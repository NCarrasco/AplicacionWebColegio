using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWebColegio.Data.Models
{
    [Table("Secciones")]
    public class Seccion
    {
        public int Id { get; set; }


        public int ProfesorId { get; set; }


        public int MateriaId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(80, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(120, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        [Display(Name="Ubicación")]
        public string Ubicacion { get; set; }


        [Display(Name = "Máximo de Estudiante")]
        //[Range(5, Int32.MinValue,ErrorMessage = "El valor mínimo del {0} es de {1}")]
        //[MaxLength(35,ErrorMessage = "Cantidad del {0} es de {1}")]
        public int? MaximoEstudiantes { get; set; }


        public bool Activa { get; set; }


        [Display(Name = "Fecha de Registro")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }


        [StringLength(500, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }


        [ForeignKey("ProfesorId")]
        public virtual Profesor Profesor { get; set; }


        [ForeignKey("MateriaId")]
        public virtual Materia Materia { get; set; }


        public Seccion()
        {
            Activa = true;
        }
    }
}
