using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPIJWT.Models;

namespace RESTfulAPIJWT.Controllers
{

    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static readonly List<ProductItem> productItems = new List<ProductItem>() { new ProductItem() { SerialNumber = "12345", Description = "Product A" }, new ProductItem() { SerialNumber = "12346", Description = "Product B" } };

        [HttpGet(Name = "GetProduct"), Authorize(Roles = "Admin")]
        public ProductItem GetProduct (string SerialNumber)
        {


#pragma warning disable CS8603 // Possible null reference return.
            return productItems.FirstOrDefault(pi => pi.SerialNumber.Equals(SerialNumber));
#pragma warning restore CS8603 // Possible null reference return.

        }

        [HttpGet(Name = "GetAllProducts"), Authorize(Roles = "Admin")]
        public IEnumerable<ProductItem> GetAllProducts()
        {

            return productItems;

        }



    }
}
