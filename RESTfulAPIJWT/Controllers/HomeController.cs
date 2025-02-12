using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPIJWT.Models;
using RESTfulAPIJWT.Services;

namespace RESTfulAPIJWT.Controllers
{
    
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet(Name = "Index")]
        public JsonResult Index()
        {
            // Add action logic here
            return new JsonResult("Web API Online");


        }

        [HttpGet(Name = "GetServiceName")]
        public JsonResult GetServiceName(IService service)
        {

            // Add action logic here
            return new JsonResult(service.GetServiceName());

        }


    }
}
