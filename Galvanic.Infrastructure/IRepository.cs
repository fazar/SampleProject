using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galvanic.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
    }
}
