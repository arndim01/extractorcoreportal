using Microsoft.EntityFrameworkCore;
using System.Linq;
using ONEWriter.Context;
using ONEWriter.Extension;
using ONEWriter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONEWriter.Repositories
{
    public class CarrierRepo : ICarrierRepo
    {
        private ApplicationContext _appDbContext = new ApplicationContext();
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
