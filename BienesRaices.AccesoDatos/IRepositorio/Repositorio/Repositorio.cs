using BienesRaices.AccesoDatos.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.AccesoDatos.IRepositorio.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext db;
        internal DbSet<T> dbset;

        public Repositorio(ApplicationDbContext db)
        {
            this.db = db;
            dbset = db.Set<T>();
        }
        public void Add(T entidad)
        {
            dbset.Add(entidad);
        }

        public T Obtener(int id)
        {
            return dbset.Find(id);
        }

        public T ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbset;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            else if (incluirPropiedades != null)
            {
                foreach (var item in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> ObtenerTodo(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbset;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            else if (incluirPropiedades != null)
            {
                foreach (var item in incluirPropiedades.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            else if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public void Remover(int id)
        {
            T entidad = dbset.Find(id);
            Remover(entidad);
        }

        public void Remover(T entidad)
        {
            dbset.Remove(entidad);
        }
    }
}
