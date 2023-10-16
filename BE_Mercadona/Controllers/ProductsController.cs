using BE_Mercadona.DataBase;
using BE_Mercadona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Mercadona.Controllers
{
    [Route("api/products")]
    [Controller]
    public class ProductsController:ControllerBase
    {
        #region Propreerties
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductDbContext context;
        #endregion
        #region Constructeur
        public ProductsController (ILogger<ProductsController>logger,ProductDbContext context)
        {
            this._logger = logger;
            this.context = context;
        }
        #endregion
        #region Methods CRUD for Product
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            _logger.LogInformation("Getting all the products");
           return await context.Products.ToListAsync();
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
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return Ok("Le produit à été créer ");
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
        #endregion
    }
}
