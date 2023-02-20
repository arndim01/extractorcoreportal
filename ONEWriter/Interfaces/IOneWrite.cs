using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONEWriter.Interfaces
{
    public interface IOneWrite
    {
        Task OnConstructJsonData(string FilePath, long CarrierId, string ContractId, string AmdId); 
    }
}
