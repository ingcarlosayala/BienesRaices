using BienesRaices.AccesoDatos.Data;
using BienesRaices.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.AccesoDatos.IRepositorio.Repositorio
{
    public class VendedorRepositorio : Repositorio<Vendedor>, IVendedorRepositorio
    {
        private readonly ApplicationDbContext db;

        public VendedorRepositorio(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Actualizar(Vendedor vendedor)
        {
            var VendedorDb = db.Vendedor.FirstOrDefault(v => v.Id.Equals(vendedor.Id));

            if (VendedorDb != null)
            {
                VendedorDb.Nombre = vendedor.Nombre;
                VendedorDb.Apellido = vendedor.Apellido;
                VendedorDb.Telefono = vendedor.Telefono;
            }
        }

        public IEnumerable<SelectListItem> ListaVendedor()
        {
            return db.Vendedor.Select(v => new SelectListItem
            {
                Text = v.Nombre,
                Value = v.Id.ToString()
            });
        }
    }
}
