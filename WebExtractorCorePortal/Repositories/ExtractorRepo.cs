using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Extentions;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Repositories
{
    public class ExtractorRepo : IExtractorRepo
    {

        private readonly ApplicationDbContext _appDbContext;

        public ExtractorRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #region RATES REPOSITORY

        public async Task InsertScope(RateScope RateScope)
        {
            await _appDbContext.TRateScopes.AddAsync(RateScope);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task InsertRateNote(RateNote RateNote)
        {
            await _appDbContext.TRateNotes.AddAsync(RateNote);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task InsertRate(Rate Rate)
        {
            await _appDbContext.TRates.AddAsync(Rate);
            await _appDbContext.SaveChangesAsync();
        }
        #endregion
        #region DATA LOADED
        public async Task CreateLoadLogs(long AmdId)
        {
            var loaded = new AmendmentLoaded
            {
                AmendmentRefId = AmdId
            };
            await _appDbContext.TAmendmentLoadeds.AddAsync(loaded);
            await _appDbContext.SaveChangesAsync();
        }
        #endregion
        #region CITY REPOSITORY
        public async Task AddCityAsync(RateCity rateCity)
        {
            await _appDbContext.TRateCities.AddAsync(rateCity);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<LibCity> FindLibCityByHashName(string HashName, long CarrierId)
        {
            return await (from city in _appDbContext.LibCities where city.Name_hash == HashName && city.CarrierRefId == CarrierId select city ).FirstOrDefaultAsync();
        }
        #endregion
        #region COMMODITY REPOSITORY
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
        public async Task AddCommodityAsync(RateCommodity rateCommodity)
        {
            await _appDbContext.TRateCommodities.AddAsync(rateCommodity);
            await _appDbContext.SaveChangesAsync();
        }
        #endregion

        public async Task<IEnumerable<NotesIndexed>> GetNotes(string id, long Group_id)
        {
            return await (from n in _appDbContext.TRateNoteIndexeds
                          where n.GroupId == Group_id
                          select new NotesIndexed
                          {
                              HashValue = n.HashValue,
                              NumberNotes = n.NumberNotes,
                              RateNoteType = n.RateNoteType
                          }).Distinct().ToListAsync();
        }

        public async Task<object> GetNotesValue(string hash)
        {
            return await (from n in _appDbContext.TRateNoteIndexeds
                          where n.HashValue == hash
                          select new { n.MainValue }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UnlocDetails>> GetUnlocsByCode(string code)
        {

            return await (from libCity in _appDbContext.LibCities
                          join libCityDetail in _appDbContext.LibCityDetails
                               on libCity.Id equals libCityDetail.CityDetailRefId
                          join unlocs in _appDbContext.SysUnlocs
                               on libCityDetail.UnlocRefId equals unlocs.Id
                          join unlocTrade in _appDbContext.SysUnlocTrades
                               on unlocs.Id equals unlocTrade.UnlocRefId
                          where libCity.Name_hash == code
                          select new UnlocDetails{
                              Name = unlocs.City,
                              State = unlocs.State,
                              Country = unlocs.Country,
                              Uncode = unlocs.Full_code,
                              Export = unlocTrade.Export_code,
                              Import = unlocTrade.Import_code

                            }).ToListAsync();
        }
        public async Task InsertGeneralNotes(long Group_id, string MainValue, RateNoteType type, TabType tabType)
        {
            var noteIndex = new RateNoteIndexed
            {
                GroupId = Group_id,
                MainValue = MainValue,
                HashValue = MainValue.HashData(),
                RateNoteType = type,
                TabType = tabType
            };
            await _appDbContext.TRateNoteIndexeds.AddAsync(noteIndex);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task InsertSpecificNotes(long Group_id, long Table_id, string MainValue, string NumberNotes, RateNoteType type, TabType tabType)
        {
            var noteIndex = new RateNoteIndexed
            {
                GroupId = Group_id,
                TableId = Table_id,
                MainValue = MainValue,
                HashValue = MainValue.HashData(),
                NumberNotes = NumberNotes,
                RateNoteType = type,
                TabType = tabType
            };
            await _appDbContext.TRateNoteIndexeds.AddAsync(noteIndex);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
