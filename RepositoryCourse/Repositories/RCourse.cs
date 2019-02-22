using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryCourse.Models;

namespace RepositoryCourse.Repositories
{
    public class RCourse : Repository<Course>, ICourse
    {

        public RCourse(RepositoryCourseContext context):base(context)
        {
            
        }
        public RepositoryCourseContext RepositoryCourseContext
        {
            get { return _context as RepositoryCourseContext; }
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            var vrati = RepositoryCourseContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
            return vrati;
        }
    }
}
