using ONEWriter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONEWriter.Builder
{
    public class RatesWrite : IOneWrite
    {
        public Task OnConstructJsonData(string FilePath, long CarrierId, string ContractId, string AmdId)
        {
            throw new NotImplementedException();
        }
    }
}
