using Microsoft.EntityFrameworkCore;    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Repositories
{
    public class CommodityRepo : ICommodityRepo
    {
        private readonly ApplicationDbContext _context;
        public CommodityRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCommodityAsync(RateCommodity rateCommodity)
        {
            await _context.TRateCommodities.AddAsync(rateCommodity);
            await _context.SaveChangesAsync();
        }

        public Task<RateCommodity> DeleteCommodityAsync(int CommodityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RateCommodity>> FindCommodityAsync(string Commodity)
        {
            throw new NotImplementedException();
        }

        public async Task<RateCommodity> FindCommodityByHashValue(string HashValue, long CarrierId)
        {

            return await (from com in _context.TRateCommodities
                            join amd in _context.TAmendments 
                                on com.AmendmentRefId equals amd.Id
                            join con in _context.TContracts
                                on amd.ContractRefId equals con.Id
                            join car in _context.SysCarriers
                                on con.CarrierRefId equals car.Id
                            where com.Main_value_hash == HashValue && car.Id == CarrierId  select com).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RateCommodity>> GetAllCommoditiesAsync()
        {
            return await _context.TRateCommodities.ToListAsync();
        }

        public Task<RateCommodity> GetRateCommodityAsync(int CommodityId)
        {
            throw new NotImplementedException();
        }
    }
}
