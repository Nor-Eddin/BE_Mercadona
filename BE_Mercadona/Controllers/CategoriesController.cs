using AutoMapper;
using BE_Mercadona.DataBase;
using BE_Mercadona.DTOs;
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
        private readonly IMapper mapper;
        #endregion
        #region Constructeur
        public CategoriesController(ILogger<CategoriesController> logger, ProductDbContext context,IMapper mapper)
        {
            this._logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        #endregion
        #region Methods CRUD for Category
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<CategoryDTO>> Get()
        {
            _logger.LogInformation("Getting all the categories");
            var categories = await context.Categories.ToListAsync();
            return mapper.Map<List<CategoryDTO>>(categories);
        }
        /// <summary>
        /// Create one category
        /// </summary>
        /// <param name="categoryCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryCreationDTO categoryCreationDTO)
        {
            var category = mapper.Map<Category>(categoryCreationDTO);
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return Ok("La category à été créer ");
        }
        /// <summary>
        /// Delete one category
        /// </summary>
        /// <param name="CatId"></param>
        /// <returns></returns>
        [HttpDelete("{CatId:int}")]
        public async Task<ActionResult> Delete(int CatId)
        {
            var exists=await context.Categories.AnyAsync(c=>c.CatId==CatId);
            if (!exists)
            {
                return NotFound();
            }
            context.Remove(new Category() { CatId = CatId });
            await context.SaveChangesAsync();
            return Ok("la categorie est supprimer");
        }
        #endregion
    
}
}
