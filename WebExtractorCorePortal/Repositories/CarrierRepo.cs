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
    public class CarrierRepo : ICarrierRepo
    {
        private readonly ApplicationDbContext _appDbContext;
        public CarrierRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<SysCarrier> FindCarrierByAmdHashId(string HashId)
        {
            return await (from amd in _appDbContext.TAmendments
                          join con in _appDbContext.TContracts
                              on amd.ContractRefId equals con.Id
                          join car in _appDbContext.SysCarriers
                              on con.CarrierRefId equals car.Id
                          select car).FirstOrDefaultAsync();
        }

        public async Task<SysCarrier> FindCarrierByIdAsync(long carrierId)
        {
            return await _appDbContext.SysCarriers.Where(f => f.Id == carrierId).SingleOrDefaultAsync();
        }
    }
}
