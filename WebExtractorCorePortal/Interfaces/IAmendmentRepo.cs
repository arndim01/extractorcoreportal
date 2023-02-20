using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Interfaces
{
    public interface IAmendmentRepo
    {
        Task AddAmendmentAsync(Amendment amendment);
        Task<Amendment> FindHashId(string hashId);
    }
}
