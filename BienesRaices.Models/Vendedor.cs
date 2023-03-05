using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.Models
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del vendedor es requerido")]
        [Display(Name = "Vendedor")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del vendedor es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El telefono del vendedor es requerido")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
    }
}
