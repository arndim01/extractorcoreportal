using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Interfaces
{
    public interface ICarrierRepo
    {
        Task<SysCarrier> FindCarrierByIdAsync(long carrierId);
        Task<SysCarrier> FindCarrierByAmdHashId(string HashId);
    }
}
