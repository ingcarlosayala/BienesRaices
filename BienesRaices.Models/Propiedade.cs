using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.Models
{
    public class Propiedade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe debe ser mayor a cero")]
        public double Precio { get; set; }

        [Display(Name = "Imagen")]
        [DataType(DataType.ImageUrl)]
        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "La descripcion corta es requerida")]
        [Display(Name = "Descripcion")]
        public string DescripcionCorta { get; set; }

        [Required(ErrorMessage = "La descripcion larga es requerida")]
        [Display(Name = "Descripcion larga")]
        public string DescripcionLarga { get; set; }

        [Required(ErrorMessage = "La habitacion es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La habitacion debe ser 1 o mas")]
        public int Habitaciones { get; set; }

        [Required(ErrorMessage = "El baño es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El baño debe ser 1 o mas")]
        [Display(Name = "Baño")]
        public int Bano { get; set; }

        [Required(ErrorMessage = "El estacionamiento es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El estacionamiento debe ser 1 o mas")]
        public int Estacionamiento { get; set; }

        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        public string FechaCreacion { get; set; }

        [Required(ErrorMessage = "El vendedor es requerido")]
        [Display(Name = "Vendedor")]
        public int IdVendedor { get; set; }

        [ForeignKey("IdVendedor")]
        public Vendedor Vendedor { get; set; }
    }
}
