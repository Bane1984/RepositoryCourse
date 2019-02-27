using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RepositoryCourse.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public T Get(int id)
        {
            var uzeti = _context.Set<T>().Find(id);
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
            var apdejtuj = _context.Set<T>().Attach(entitet);
            apdejtuj.State = EntityState.Modified;
        }

        public void Delete(T entitet)
        {
            _context.Set<T>().Remove(entitet);
        }
    }
}
