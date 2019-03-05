using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using RepositoryCourse.Repositories;

namespace RepositoryCourse.Filters
{
    public class UnitOfWorkFilter:IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _unitOfWork.Start();
            var success = false;
            try
            {
                await next();

                _unitOfWork.Complete();
                success = true;
            }
            catch (Exception)
            {
                success = false;
                throw;
            }
            finally
            {
                if (success)
                {
                    _unitOfWork.Commit();
                    _unitOfWork.Dispose();
                }
                else
                {
                    _unitOfWork.Dispose();
                }
            }
        }

        //void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        //{
        //    throw new NotImplementedException();
        //}

        //void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
