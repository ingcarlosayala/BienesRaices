
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.AccesoDatos.IRepositorio
{
    public interface IUnidadTrabajo:IDisposable
    {
        IVendedorRepositorio Vendedor { get; }
        IPropiedadeRepositorio Propiedade { get; }
        void Guardar();
    }
}
