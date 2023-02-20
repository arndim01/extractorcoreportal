using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Interfaces
{
    public interface IContractRepo
    {
        Task<Contract> FindContractByIdAsync(string contractId);
        Task AddContractAsync(Contract contract);
        Task<IEnumerable<ContractFileDetails>> GetAllContractAssign();
    }
}
