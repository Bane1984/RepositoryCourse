using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryCourse.Repositories;
using RepositoryCourse.Models;
using AutoMapper;
using System.Runtime.Serialization;

namespace RepositoryCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRepositoryController : BaseController<Course>
    {
        private readonly ICourse _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RepositoryCourseContext _context;
        
        public RepositoryCourseContext RepositoryCourseContext
        {
            get { return _context as RepositoryCourseContext; }
        }
        public CourseRepositoryController(ICourse repository, IUnitOfWork unitOfWork, IMapper mapper):base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var a = base.GetAll();
            return Ok(a);
        }

        /// <summary>
        /// Get Top Selling Courses.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("GetTopSellingCourses/{count}")]
        public IActionResult GetTopSellingCourses(int count)
        {
            var a = _repository.GetTopSellingCourses(count);
            return Ok(a);
        }

        /// <summary>
        /// Create course.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(Course course)
        {
            _repository.Create(course);
            _unitOfWork.Complete();
            return Ok("Uspjesno kreiran kurs.");
        }

        ///// <summary>
        ///// Provjeris the specified identifier.
        ///// </summary>
        ///// <param name="id">The identifier.</param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentOutOfRangeException">Uneseni Id je van opsega.</exception>
        //[HttpGet("provjeri")]
        //public IActionResult Provjeri([FromQuery]int id)
        //{
        //    if (id > 100)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.BadRequest,
        //            Content = new StringContent("Ne mozete unijeti Id veci od 100.")
        //        });
        //    }

        //    return Ok("Uneseni id je u dozvoljenom opsegu!");
        //}

    }
}