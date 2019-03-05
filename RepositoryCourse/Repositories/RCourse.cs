using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryCourse.Models;
using RepositoryCourse.DTO;

namespace RepositoryCourse.Repositories
{
    public class RCourse : Repository<Course>, ICourse
    {
        public readonly RepositoryCourseContext _context;
        public RCourse(RepositoryCourseContext context):base(context)
        {
            
        }
        public RepositoryCourseContext RepositoryCourseContext
        {
            get { return _context as RepositoryCourseContext; }
        }
        //public IEnumerable<Course> GetAll()
        //{
        //    return RepositoryCourseContext.Courses.ToList();
        //}

        //public void Create(Course curs)
        //{
        //    var kurs = new Course
        //    {
        //        CourseName = curs.CourseName,
        //        Description = curs.Description,
        //        Level = curs.Level,
        //        FullPrice = curs.FullPrice
        //    };
        //    RepositoryCourseContext.Add(kurs);
        //}

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            var vrati = RepositoryCourseContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
            return vrati;
        }
    }
}
