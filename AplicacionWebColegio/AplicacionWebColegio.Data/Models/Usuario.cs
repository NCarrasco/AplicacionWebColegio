using AplicacionWebColegio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWebColegio.Data.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "La longitud máxima del campo {0} es {1}")]
        [Display(Name="Usuario")]
        public string NombreUsuario { get; set; }


        public UsuarioNivel Nivel { get; set; }

        public bool Activo { get; set; }


        public Usuario()
        {
            Activo = true;

            Nivel = UsuarioNivel.Administrador;
        }
    }
}
