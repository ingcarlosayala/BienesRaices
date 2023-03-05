using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.Models.ViewsModels
{
    public class PropiedadVM
    {
        public Propiedade Propiedade { get; set; }
        public IEnumerable<SelectListItem> ListaVendedor { get; set; }
    }
}
