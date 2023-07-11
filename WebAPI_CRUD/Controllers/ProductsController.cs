using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        static List<string> myProducts = new List<string>()
        { "Ac", "Washing Machine", "Fridge", "TV", "Fan", "Mobile", "Laptop" };

        #region Get
        [HttpGet]
        [Route("/product/list")]
        public IActionResult GetAllProducts()
        {
            return Ok(myProducts);
        }
        [HttpGet]
        [Route("/product/Index/{id}")]
        public IActionResult GetProductByIndex(int id)
        {
            if (myProducts.Count < id)
            {
                return NotFound(string.Format($"Sorry Product not found with the id:" + id));
            }
            string Product = myProducts[id];
            return Ok(Product);
        }
        [HttpGet]
        [Route("/product/Character/{chars}")]
        public IActionResult GetProductByChar(string chars)
        {
            if (!myProducts.Contains(chars))
            {
                return NotFound(string.Format($"Sorry Product not found with the name:" + chars));
            }
            var Product = from f in myProducts where f.StartsWith(chars) select f;
            return Ok(Product);
        }
        [HttpGet]
        [Route("/product/Count")]
        public IActionResult GetCount()
        {
            return Ok(myProducts.Count);
        }
        #endregion

        #region Post
        [HttpPost]
        [Route("/product/add")]
        public IActionResult AddProduct(string name)
        {
            myProducts.Add(name);
            return Ok(name + " Is added to the list");
            //return Accepted("/List", name + " Is added to the list");
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("/product/delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            string name = myProducts[id];
            myProducts.RemoveAt(id);
            return Accepted(name + " has been removed from ProductList.");

        }
        [HttpDelete]
        [Route("/product/delete/ByName/{name}")]
        public IActionResult DeleteProductByName(string name)
        {
            myProducts.Remove(name);
            return Accepted(name + " has been removed from ProductList.");

        }
        #endregion

        #region Put
        [HttpPut]
        [Route("/product/update/{id}/{name}")]
        public IActionResult UpdateProduct(int id, string name)
        {
            string oldname = myProducts[id];
            myProducts[id] = name;
            return Ok(name + " Has been updated from " + oldname);
        }
        #endregion
    }
}
