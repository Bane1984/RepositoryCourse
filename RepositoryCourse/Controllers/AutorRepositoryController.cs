using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryCourse.Repositories;
using RepositoryCourse.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorRepositoryController : RepositoryController<Autor>, IAutor
    {
        public AutorRepositoryController(RepositoryCourseContext context) : base(context)
        {

        }

        public RepositoryCourseContext RepositoryCourseContext
        {
            get { return _context as RepositoryCourseContext; }
        }

        [HttpGet("getautor/{id}")]
        public Autor GetAutor(int id)
        {
            var uzmi = RepositoryCourseContext.Autors.Include(c => c.Courses).SingleOrDefault(c => c.AutorId == id);
            return uzmi;
        }
    }
}