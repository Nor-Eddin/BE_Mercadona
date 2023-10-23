using AutoMapper;
using BE_Mercadona.DataBase;
using BE_Mercadona.DTOs;
using BE_Mercadona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Mercadona.Controllers
{
    [Route("api/products")]
    [Controller]
    public class ProductsController:ControllerBase
    {
        #region Properties
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductDbContext context;
        private readonly IMapper mapper;
        #endregion
        #region Constructeur
        public ProductsController (ILogger<ProductsController>logger,ProductDbContext context,IMapper mapper)
        {
            this._logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        #endregion
        #region Methods CRUD for Product
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ProductDTO>> Get()
        {
            _logger.LogInformation("Getting all the products");
            var products = await context.Products.ToListAsync();
           return mapper.Map<List<ProductDTO>>(products);
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
        public async Task<ActionResult> Post([FromBody] ProductCreationDTO productCreationDTO)
        {
            var product=mapper.Map<Product>(productCreationDTO);
            context.Add(product);
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
