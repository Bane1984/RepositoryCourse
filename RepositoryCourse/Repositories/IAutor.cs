using RepositoryCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryCourse.Repositories
{
    public interface IAutor:IRepository<Autor>
    {
        IEnumerable<Autor> GetAll();
        Autor GetAutor(int id);
        void Create(Autor curs);

    }
}
