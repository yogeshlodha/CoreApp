using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;
        public ErrorController(ILogger<ErrorController> _logger )
        {
            this.logger = _logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HandleStatusCodeError(int statusCode)
        {
            var errorDetail = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            switch (statusCode) {
                case 404:
                    logger.LogError($"404 Page not Found : {errorDetail.Path}");
                    ViewBag.ErrorMsg = "Page you are looking. it is not found.";
                    break;
                case 500:
                    logger.LogError($"500 Server side error. Unable to process request. ");
                    ViewBag.ErrorMsg = "500 Server side error. Unable to process request.";
                    break;
                default:
                    logger.LogError($"Error is not handle : {errorDetail.Path}");
                    ViewBag.ErrorMsg = "Contact to admin.";
                    break;
            }
            
            return View("Index");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var errorDetail = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"We add error here:  Error path : {errorDetail.Path}");
            ViewBag.ErrorMsg = errorDetail.Error.Message;
            return View("Index");
        }
    }
}
