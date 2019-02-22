using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryCourse.Repositories;
using RepositoryCourse.Models;

namespace RepositoryCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRepositoryController : RepositoryController<Course>, ICourse
    {
        public CourseRepositoryController(RepositoryCourseContext context) : base(context)
        {
                
        }

        public RepositoryCourseContext RepositoryCourseContext
        {
            get { return _context as RepositoryCourseContext; }
        }

        [HttpGet("GetTopSellingCourses/{count}")]
        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            var vrati = RepositoryCourseContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
            return vrati;
        }
    }
}