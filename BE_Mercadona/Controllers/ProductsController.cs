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
        /// Get one product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{IdProduct:int}")]
        public async Task<ActionResult<ProductDTO>> Get(int IdProduct)
        {
            var product = await context.Products.FindAsync(IdProduct);
            //var product = await context.Products.FirstOrDefaultAsync(c => c.IdProduct == IdProduct);
            if (product == null)
            {
                return NotFound();
            }
            return mapper.Map<ProductDTO>(product);
        }
        /// <summary>
        /// Create one product
        /// </summary>
        /// <param name="productCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCreationDTO productCreationDTO)
        {
            var product=mapper.Map<Product>(productCreationDTO);
            context.Add(product);
            await context.SaveChangesAsync();
            return Ok("Le produit à été créer ");
        }
        /// <summary>
        /// Update one product
        /// </summary>
        /// <param name="IdProduct"></param>
        /// <param name="productCreationDTO"></param>
        /// <returns></returns>
        [HttpPut("{IdProduct:int}")]
        public async Task<ActionResult> Put(int IdProduct,[FromBody] ProductCreationDTO productCreationDTO)
        {
            var product = await context.Products.FindAsync(IdProduct);
            //var product = await context.Products.FirstOrDefaultAsync(p => p.IdProduct == IdProduct);
            if(product == null)
            {
                return NotFound();
            }
            product = mapper.Map(productCreationDTO, product);
            await context.SaveChangesAsync();
            return Ok("Update done");
        }
        /// <summary>
        /// Delete one product
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete("{IdProduct:int}")]
        public async Task<ActionResult>Delete(int IdProduct)
        {
            var exists = await context.Products.AnyAsync(p => p.IdProduct == IdProduct);
            if(!exists)
            {
                return NotFound();
            }
            context.Remove(new Product() { IdProduct=IdProduct});
            await context.SaveChangesAsync();
            return Ok("Produit supprimer");
        }
        #endregion
    }
}
