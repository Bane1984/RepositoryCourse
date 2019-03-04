using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RepositoryCourse.Filters
{
    public class ActionExceptionFilter:IExceptionFilter
    {
        private readonly bool _isDevelopment;

        public ActionExceptionFilter(bool isDevelopment)
        {
            _isDevelopment = isDevelopment;
        }
        

        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            string error = string.Empty;
            string message = string.Empty; //podatak o gresci
            var exception = ex.Message; //poruka iz exceptiona koji je uhvacen
            string stackTrace = (_isDevelopment) ? context.Exception.StackTrace : string.Empty; //StackTrace od exceptiona koji je uhvacen
            IActionResult actionResult;

            if (ex is InvalidQuantityException)
            {
                error = "Nedozvoljen zahtjev 1.";
                actionResult = new BadRequestObjectResult(
                    new
                    {
                        Error = error,
                        Message = message,
                        Exception = exception,
                        StackTrace = stackTrace
                    });
            }
            else if (error is DbUpdateConcurrencyException)
            {
                error = "Nedozvoljen zahtjev 2.";
                actionResult = new BadRequestObjectResult(
                    new
                    {
                        Error = error,
                        Message = message,
                        Exception = exception,
                        StackTrace = stackTrace
                    });
            }
            else
            {
                error = "Generalna greska.";
                actionResult = new BadRequestObjectResult(new
                {
                    Error = error,
                    Message = message,
                    Exception = exception,
                    StackTrace = stackTrace
                })
                {
                    StatusCode = 500
                };
            }

            context.Result = actionResult;

        }
    }
}
