using BE_Mercadona.Models;
using BE_Mercadona.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_Mercadona.Controllers
{
    [Route("api/products")]
    [Controller]
    public class ProductsController:ControllerBase
    {        
        private readonly ILogger<ProductsController> _logger;
        public ProductsController (ILogger<ProductsController>logger)
        {
            this._logger = logger;
        }
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            _logger.LogInformation("Getting all the products");
            return  new List<Product>() {new Product(){ IdProduct = 1, ProductName = "seviette", DescriptionProduct = "azertdfghxcvbsdfgh", Price = 5, Image = "sdfghj" } };
        }
        /// <summary>
        /// Get le product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Id:int}")]
        public ActionResult<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {

            throw new NotImplementedException();
        }
        

        [HttpPut]
        public ActionResult<Product> Put([FromBody] Product product)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult<Product>Delete()
        {
            throw new NotImplementedException();
        }
    }
}
