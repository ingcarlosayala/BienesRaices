using BienesRaices.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.AccesoDatos.IRepositorio.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext db;
        public IVendedorRepositorio Vendedor { get; private set; }
        public IPropiedadeRepositorio Propiedade { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            this.db = db;
            Vendedor = new VendedorRepositorio(db);
            Propiedade = new PropiedadeRepositorio(db);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Guardar()
        {
            db.SaveChanges();
        }
    }
}
