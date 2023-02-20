using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Interfaces
{
    public interface IFileRepo
    {
        Task<IEnumerable<Source>> GetAllFileAsync();
        Task<Source> FindSourceByFileNameAsync(string sourceName);
        Task AddFileAsync(Source source);
    }
}
