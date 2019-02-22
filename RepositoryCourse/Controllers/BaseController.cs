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
        [HttpGet]
        public IActionResult GetAll()
        {
            var svi = _repository.GetAll();
            return Ok(svi);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var poIdu = _repository.Get(id);
            return Ok(poIdu);
        }

        [HttpPost]
        public IActionResult Create(Autor autor)
        {
            _unitOfWork.Autors.Create(autor);
            _unitOfWork.Complete();
            return Ok("Autor kreiran preko repozitorijuma!");
        }
    }
}