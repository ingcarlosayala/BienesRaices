using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BienesRaices.AccesoDatos.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        T Obtener(int id);
        IEnumerable<T> ObtenerTodo(
            Expression<Func<T,bool>> filtro = null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
            string incluirPropiedades = null
        );
        T ObtenerPrimero(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null
        );
        void Add(T entidad);
        void Remover(int id);
        void Remover(T entidad);
    }
}
