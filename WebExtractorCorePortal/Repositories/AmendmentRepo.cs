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
    public class AmendmentRepo : IAmendmentRepo
    {
        private readonly ApplicationDbContext _appDbContext;
        public AmendmentRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAmendmentAsync(Amendment amendment)
        {
            await _appDbContext.TAmendments.AddAsync(amendment);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<Amendment> FindHashId(string hashId)
        {
            return await (from a in _appDbContext.TAmendments
                          where a.HashId == hashId
                          select a).FirstOrDefaultAsync();
        }
    }
}
