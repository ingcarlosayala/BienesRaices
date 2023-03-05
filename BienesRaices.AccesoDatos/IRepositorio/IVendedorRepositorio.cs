using BienesRaices.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.AccesoDatos.IRepositorio
{
    public interface IVendedorRepositorio:IRepositorio<Vendedor>
    {
        void Actualizar(Vendedor vendedor);
        IEnumerable<SelectListItem> ListaVendedor();
    }
}
