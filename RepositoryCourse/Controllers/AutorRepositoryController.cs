using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryCourse.Repositories;
using RepositoryCourse.Models;
using AutoMapper;
using RepositoryCourse.DTO;

namespace RepositoryCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorRepositoryController : BaseController<Autor, AutorDTO>
    {
        private readonly IAutor _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
     

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
        public IActionResult Create(AutorDTO autor)
        {
            var add = base.Create(autor);
            return Ok(add);
        }

        /// <summary>
        /// Update autor.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="autor">The autor.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(int id, AutorDTO autor)
        {
            var update = base.Update(id, autor);
            return Ok(update);
        }

        /// <summary>
        /// Delete autor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var delete = base.Delete(id);
            return Ok(delete);
        }
    }
}