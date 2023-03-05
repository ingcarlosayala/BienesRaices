using BienesRaices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.AccesoDatos.IRepositorio
{
    public interface IPropiedadeRepositorio:IRepositorio<Propiedade>
    {
        void Actualizar(Propiedade propiedade);
    }
}
