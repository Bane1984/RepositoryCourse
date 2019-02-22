using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryCourse.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); 
        T Get(int id);
        void Create(T entitet);
        void Delete(T entitet);
    }
}
