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
    public class FileRepo :IFileRepo
    {
        private readonly ApplicationDbContext _appDbContext;
        public FileRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddFileAsync(Source source)
        {
            await _appDbContext.TSource.AddAsync(source);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Source> FindSourceByFileNameAsync(string sourceName)
        {
            return await _appDbContext.TSource.Where(f => f.SourceName == sourceName).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Source>> GetAllFileAsync()
        {
            return await _appDbContext.TSource.ToListAsync();
        }
    }
}
