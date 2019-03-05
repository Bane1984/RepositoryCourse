using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.IdentityModel.Tokens;
using RepositoryCourse.Repositories;
using RepositoryCourse.DTO;
using RepositoryCourse.Models;

namespace RepositoryCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, Tdto> : Controller where T:class where Tdto:class 
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
            if (svi != null)
            {
                _mapper.Map<IEnumerable<Tdto>>(svi);
                return Ok(svi);
            }
            return NotFound("Nije pronadjen ni jedan zapis.");
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
            _mapper.Map<Tdto>(poIdu);
            return Ok(poIdu);
        }

        /// <summary>
        /// Create object.
        /// </summary>
        /// <param name="entitet"></param>
        /// <returns></returns>
        [HttpPost("create")]
        protected virtual IActionResult Create(Tdto entitet)
        {
            var add = _mapper.Map<T>(entitet);
            _repository.Create(add);
            //_unitOfWork.Complete();
            return Ok(add);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("update")]
        protected virtual IActionResult Update(int id, Tdto entity)
        {
            var ulaz = _repository.Get(id);
            _mapper.Map(entity, ulaz);
            _unitOfWork.Complete();
            return Ok("Update-ovano!");
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name = "entitet" ></param >
        /// <returns ></returns >
        //[HttpDelete("delete")]
        protected virtual IActionResult Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Complete();
            return Ok("Obrisano!");
        }
    }
}