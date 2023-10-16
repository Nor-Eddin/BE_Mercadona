using BE_Mercadona.DataBase;
using BE_Mercadona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Mercadona.Controllers
{
    [Route("api/promotions")]
    [Controller]
    public class PromotionsController:ControllerBase
    {
        #region Properties
        private readonly ILogger<PromotionsController> _logger;
        private readonly ProductDbContext context;
        #endregion
        #region Constructeur
        public PromotionsController(ILogger<PromotionsController> logger, ProductDbContext context)
        {
            this._logger = logger;
            this.context = context;
        }
        #endregion
        #region Methods CRUD for Promotions
        /// <summary>
        /// Get all promotions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Promotion>> Get()
        {
            _logger.LogInformation("Getting all the promotions");
            return await context.Promotions.ToListAsync();
        }
        /// <summary>
        /// Get le promotion by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Id:int}")]
        public ActionResult<Promotion> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<Promotion>> Post([FromBody] Promotion promotion)
        {
            context.Promotions.Add(promotion);
            await context.SaveChangesAsync();
            return Ok("La promotion à été créer ");
        }

        [HttpPut]
        public ActionResult<Promotion> Put([FromBody] Promotion promotion)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult<Promotion> Delete()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
