using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Interfaces
{
    public interface IExtractorRepo
    {
        
        Task<IEnumerable<NotesIndexed>> GetNotes(string id, long Group_id);
        Task<IEnumerable<UnlocDetails>> GetUnlocsByCode(string code);
        Task<object> GetNotesValue(string hash);

        //LOADED FILE
        Task CreateLoadLogs(long AmdId);

        //CITY REPO
        Task AddCityAsync(RateCity rateCity);
        Task<LibCity> FindLibCityByHashName(string HashName, long CarrierId);

        //COMMODITY REPO
        Task<LibCommodity> FindLibCommodityByHashValue(string HashValue, long CarrierId);
        Task AddCommodityAsync(RateCommodity rateCommodity);

        //NOTES REPO
        Task InsertGeneralNotes(long Group_id, string MainValue, RateNoteType type, TabType tabType);
        Task InsertSpecificNotes(long Group_id, long Table_id, string MainValue, string NumberNotes, RateNoteType type, TabType tabType);

        //RATES REPO
        Task InsertScope(RateScope RateScope);
        Task InsertRateNote(RateNote RateNote);
        Task InsertRate(Rate Rate);
    }
}
