using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryCourse.Repositories;
using RepositoryCourse.Models;
using AutoMapper;

namespace RepositoryCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorRepositoryController : BaseController<Autor>
    {
        private readonly IAutor _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RepositoryCourseContext _context;

        public RepositoryCourseContext RepositoryCourseContext
        {
            get { return _context as RepositoryCourseContext; }
        }

        public AutorRepositoryController(IAutor repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all autors.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var a = base.GetAll();
            return Ok(a);
        }

        /// <summary>
        /// Get Autor(id).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var a = base.Get(id);
            return Ok(a);
        }

        /// <summary>
        /// Create autor.
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Autor autor)
        {
            var a = new Autor
            {
                AutorName = autor.AutorName
            };
            _unitOfWork.Complete();
            return Ok("Autor kreiran.");
        }
    }
}