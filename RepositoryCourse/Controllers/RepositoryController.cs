using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryCourse.Repositories;

namespace RepositoryCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController<T> : IRepository<T> where T: class
    {
        protected readonly DbContext _context;
        public RepositoryController(DbContext context)
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

        public void Delete(T entitet)
        {
            _context.Set<T>().Remove(entitet);
        }

    }
}