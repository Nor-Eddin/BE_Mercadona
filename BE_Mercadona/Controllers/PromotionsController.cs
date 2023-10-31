using AutoMapper;
using BE_Mercadona.DataBase;
using BE_Mercadona.DTOs;
using BE_Mercadona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BE_Mercadona.Controllers
{
    [Route("api/promotions")]
    [Controller]
    public class PromotionsController:ControllerBase
    {
        #region Properties
        private readonly ILogger<PromotionsController> _logger;
        private readonly ProductDbContext context;
        private readonly IMapper mapper;
        #endregion
        #region Constructeur
        public PromotionsController(ILogger<PromotionsController> logger, ProductDbContext context,IMapper mapper)
        {
            this._logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
        #endregion
        #region Methods CRUD for Promotions
        /// <summary>
        /// Get all promotions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PromotionDTO>> Get()
        {
            _logger.LogInformation("Getting all the promotions");
            var promotions = await context.Promotions.ToListAsync();
            return mapper.Map<List<PromotionDTO>>(promotions);
        }
        /// <summary>
        /// Create one promotion
        /// </summary>
        /// <param name="promotionCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PromotionCreationDTO promotionCreationDTO)
        {
            var promotion=mapper.Map<Promotion>(promotionCreationDTO);
            context.Promotions.Add(promotion);
            await context.SaveChangesAsync();
            return Ok("La promotion à été créer ");
        }

        /// <summary>
        /// Delete one promotion
        /// </summary>
        /// <param name="IdPromotion"></param>
        /// <returns></returns>
        [HttpDelete("{IdPromotion:int}")]
        public async Task<ActionResult> Delete(int IdPromotion)
        {
            var exist=await context.Promotions.AnyAsync(p=>p.IdPromotion==IdPromotion);
            if (!exist)
            {
                return NotFound();
            }
            context.Remove(new Promotion() { IdPromotion=IdPromotion });
            await context.SaveChangesAsync();
            return Ok("la promotion a ete supprimer");
        }
        #endregion
    }
}
