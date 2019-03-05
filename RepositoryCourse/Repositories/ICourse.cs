using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using RepositoryCourse.Models;

namespace RepositoryCourse.Repositories
{
    public interface ICourse:IRepository<Course>
    {
        //void Create(Course curs);
        IEnumerable<Course> GetAll();
        IEnumerable<Course> GetTopSellingCourses(int count);

    }
}
