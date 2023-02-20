using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Interfaces;

namespace WebExtractorCorePortal.Repositories
{
    public class SurchargeRepo : ISurchargeRepo
    {
        private readonly ApplicationDbContext _appDbContext;
        public SurchargeRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<object>> FindSurcharge(string value)
        {
            return await (from c in _appDbContext.SysSurchargeKeywords  
                          where c.Name.Contains(value) || c.Code.Contains(value)
                          select new
                          {
                              c.Id,
                              c.Name,
                              c.Code
                          }).Take(1000).ToListAsync();
        }
    }
}
