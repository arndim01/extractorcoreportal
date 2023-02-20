using ONEWriter.Extension;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONEWriter.Interfaces
{
    public interface ICarrierRepo
    {
        Task<SysCarrier> FindCarrierByIdAsync(long carrierId);
        Task<SysCarrier> FindCarrierByAmdHashId(string HashId);
    }
}
