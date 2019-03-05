using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RepositoryCourse.DTO;
using RepositoryCourse.Models;

namespace RepositoryCourse.Repositories
{
    public class RAutor:Repository<Autor>, IAutor
    {
        public RAutor(RepositoryCourseContext context):base(context)
        {
              
        }
        public RepositoryCourseContext RepositoryCourseContext
        {
            get { return _context as RepositoryCourseContext; }
        }

        //public Autor GetAutor(int id)
        //{
        //    var uzmi = RepositoryCourseContext.Autors.Include(c => c.Courses).SingleOrDefault(c => c.AutorId == id);
        //    return uzmi;
        //}

        //public IEnumerable<Autor> GetAll()
        //{
        //    var a = RepositoryCourseContext.Autors.ToList();
        //    return a;
        //}

        //public void Create(AutorDTO autor)
        //{
        //    RepositoryCourseContext.Autors.Add(autor);
        //    RepositoryCourseContext.SaveChanges();
        ////}

        //public void CreateAutor(Autor auto)
        //{
        //    RepositoryCourseContext.Autors.Add(auto);
        //}
    }
}
