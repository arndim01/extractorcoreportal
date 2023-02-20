using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Interfaces
{
    public interface ICommodityRepo
    {
        Task<IEnumerable<RateCommodity>> GetAllCommoditiesAsync();
        Task<RateCommodity> GetRateCommodityAsync(int CommodityId);
        Task<IEnumerable<RateCommodity>> FindCommodityAsync(string Commodity);
        Task<RateCommodity> DeleteCommodityAsync(int CommodityId);
        Task AddCommodityAsync(RateCommodity rateCommodity);
        Task<RateCommodity> FindCommodityByHashValue(string HashValue, long CarrierId);
    }
}
