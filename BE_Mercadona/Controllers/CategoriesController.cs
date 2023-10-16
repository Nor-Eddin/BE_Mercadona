using BE_Mercadona.DataBase;
using BE_Mercadona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Mercadona.Controllers
{
    [Route("api/categories")]
    [Controller]
    public class CategoriesController : ControllerBase
    {
        #region Properties
        private readonly ILogger<CategoriesController> _logger;
        private readonly ProductDbContext context;
        #endregion
        #region Constructeur
        public CategoriesController(ILogger<CategoriesController> logger, ProductDbContext context)
        {
            this._logger = logger;
            this.context = context;
        }
        #endregion
        #region Methods CRUD for Category
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            _logger.LogInformation("Getting all the products");
            return await context.Categories.ToListAsync();
        }
        /// <summary>
        /// Get le product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Id:int}")]
        public ActionResult<Category> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return Ok("Le produit à été créer ");
        }

        [HttpPut]
        public ActionResult<Category> Put([FromBody] Category category)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult<Category> Delete()
        {
            throw new NotImplementedException();
        }
        #endregion
    
}
}
