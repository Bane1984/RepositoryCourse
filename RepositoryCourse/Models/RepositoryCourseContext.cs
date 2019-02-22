using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace RepositoryCourse.Models
{
    public class RepositoryCourseContext : DbContext
    {
        public RepositoryCourseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Autor> Autors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
