using BienesRaices.AccesoDatos.Data;
using BienesRaices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.AccesoDatos.IRepositorio.Repositorio
{
    public class PropiedadeRepositorio : Repositorio<Propiedade>, IPropiedadeRepositorio
    {
        private readonly ApplicationDbContext db;

        public PropiedadeRepositorio(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Actualizar(Propiedade propiedade)
        {
            var propiedadDb = db.Propiedade.FirstOrDefault(p => p.Id.Equals(propiedade.Id));

            if (propiedadDb != null)
            {
                propiedadDb.Titulo = propiedade.Titulo;
                propiedadDb.Precio = propiedade.Precio;
                propiedadDb.ImagenUrl = propiedade.ImagenUrl;
                propiedadDb.DescripcionCorta = propiedade.DescripcionCorta;
                propiedadDb.DescripcionLarga = propiedade.DescripcionLarga;
                propiedadDb.Habitaciones = propiedade.Habitaciones;
                propiedadDb.Bano = propiedade.Bano;
                propiedadDb.Estacionamiento = propiedade.Estacionamiento;
                propiedadDb.IdVendedor = propiedade.IdVendedor;
            }
        }
    }
}
