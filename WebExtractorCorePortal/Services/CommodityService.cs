using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Services
{
    public class CommodityService : ICommodityService
    {
        private readonly ICommodityRepo _commodityRepo;
        public CommodityService(ICommodityRepo commodityRepo)
        {
            _commodityRepo = commodityRepo;
        }

        public async Task<IActionResult> GetAllCommoditiesAsync()
        {
            try
            {
                IEnumerable<RateCommodity> commodities = await _commodityRepo.GetAllCommoditiesAsync();
                if( commodities != null)
                {
                    //return new OkObjectResult(commodities.Select(p => new CommodityDetails()
                    //{
                    //    Id = p.Id,
                    //    Main_value = p.Main_value,
                    //    Code = p.Code,
                    //    Description = p.Description,
                    //    Exclusions = p.Exclusion,
                    //    Nac = p.Nac
                    //}));
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }

            }
            catch
            {
                return new ConflictResult();
            }
        }
    }
}
