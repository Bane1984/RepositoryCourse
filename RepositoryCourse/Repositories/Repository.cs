using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryCourse.Filters;
using RepositoryCourse.Models;

namespace RepositoryCourse.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly RepositoryCourseContext _context;
        public Repository(RepositoryCourseContext context)
        {
            _context = context;
        }

        public T Get(int id)
        {
            var uzeti = _context.Set<T>().Find(id);
            if (uzeti == null)
            {
                throw new InvalidQuantityException("Trazeni entitet nije pronadjen."); //eksepsn koji sam kreirao u Filters
            }
            return uzeti;
        }

        public IEnumerable<T> GetAll()
        {
            var sve = _context.Set<T>().ToList();
            return sve;
        }

        public void Create(T entitet)
        {
            _context.Set<T>().Add(entitet);
        }

        public void Update(int id, T entitet)
        {
            var ureFind = _context.Set<T>().Find(id);
            if (ureFind==null)
            {
                throw new InvalidQuantityException("Trazeni entitet nije pronadjen.");
            }
            var apdejtuj = _context.Set<T>().Attach(entitet);
            apdejtuj.State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var find = _context.Set<T>().Find(id);
            //ovdje ubaciti eksepsn
            if (find == null)
            {
                throw new InvalidQuantityException("Trazeni entitet nije pronadjen.");
            }
            _context.Set<T>().Remove(find);
        }
    }
}
