using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using RepositoryCourse.Repositories;
using RepositoryCourse.Models;

namespace RepositoryCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : Controller where T:class
    {
        private IRepository<T> _repository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public BaseController(IRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        protected virtual IActionResult GetAll()
        {
            var svi = _repository.GetAll();
            return Ok(svi);
        }

        /// <summary>
        /// Get include Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        protected virtual IActionResult Get(int id)
        {
            var poIdu = _repository.Get(id);
            return Ok(poIdu);
        }

        /// <summary>
        /// Create object.
        /// </summary>
        /// <param name="entitet"></param>
        /// <returns></returns>
        [HttpPost("create")]
        protected virtual IActionResult Create(T entitet)
        {
            _repository.Create(entitet);
            _unitOfWork.Complete();
            return Ok("Kreirano!");
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("update")]
        protected virtual IActionResult Update(int id, T entity)
        {
            var ulaz = _repository.Get(id);
            _mapper.Map(entity, ulaz);
            _unitOfWork.Complete();
            return Ok("Update-ovano!");
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name = "entitet" ></ param >
        /// < returns ></ returns >
        //[HttpDelete("delete")]
        protected virtual IActionResult Delete(T entitet)
        {
            _repository.Delete(entitet);
            _unitOfWork.Complete();
            return Ok("Obrisano!");
        }
    }
}