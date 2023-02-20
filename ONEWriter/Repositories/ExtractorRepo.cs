using Microsoft.EntityFrameworkCore;
using ONEWriter.Context;
using ONEWriter.Extension;
using ONEWriter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONEWriter.Repositories
{
    public class ExtractorRepo : IExtractorRepo
    {
        private ApplicationContext _appDbContext = new ApplicationContext();
        public Task AddCityAsync(RateCity rateCity)
        {
            throw new NotImplementedException();
        }

        public Task AddCommodityAsync(RateCommodity rateCommodity)
        {
            throw new NotImplementedException();
        }

        public Task CreateLoadLogs(long AmdId)
        {
            throw new NotImplementedException();
        }

        public Task<LibCity> FindLibCityByHashName(string HashName, long CarrierId)
        {
            throw new NotImplementedException();
        }

        public async Task<LibCommodity> FindLibCommodityByHashValue(string HashValue, long CarrierId)
        {
            return await (from com in _appDbContext.LibCommodities
                          join con in _appDbContext.TContracts
                              on com.ContractRefId equals con.Id
                          join car in _appDbContext.SysCarriers
                              on con.CarrierRefId equals car.Id
                          where com.Main_hash_value == HashValue && car.Id == CarrierId
                          select com).FirstOrDefaultAsync();
        }

        public Task<object> GetNotesValue(string hash)
        {
            throw new NotImplementedException();
        }

        public Task InsertGeneralNotes(long Group_id, string MainValue, RateNoteType type)
        {
            throw new NotImplementedException();
        }

        public Task InsertSpecificNotes(long Group_id, long Table_id, string MainValue, string NumberNotes, RateNoteType type)
        {
            throw new NotImplementedException();
        }
    }
}
