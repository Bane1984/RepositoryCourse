using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RepositoryCourse.DTO
{
    public class CourseDTO
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }
    }
}
