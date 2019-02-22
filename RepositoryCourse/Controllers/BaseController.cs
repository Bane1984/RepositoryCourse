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

        public BaseController(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;   
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var svi = _repository.GetAll();
            return Ok(svi);
        }

        public IActionResult Get(int id)
        {
            var poIdu = _repository.Get(id);
            return Ok(poIdu);
        }

        public IActionResult Create(T entitet)
        {
            _repository.Create(entitet);
            _unitOfWork.Complete();
            return Ok();
        }

        //public IActionResult Put(int id, T entity)
        //{
        //    _repository.Update(entity);
        //    _unitOfWork.Complete();
        //    return Ok();
        //}

        public IActionResult Delete(T entitet)
        {
            _repository.Delete(entitet);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}