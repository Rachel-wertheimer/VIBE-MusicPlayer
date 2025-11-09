using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core.Repositories
{
    public interface IRepository<T, E> where T : class
    {
        List<T> GetAll();
        T? GetById(E id);

        void Delete(E id);

        T Put(T entity);

        T Add(T entity);

    }
}
