using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPIJWT.Models;

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



    }
}
