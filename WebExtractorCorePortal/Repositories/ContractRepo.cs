using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Helpers;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Repositories
{
    public class ContractRepo : IContractRepo
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly IHostingEnvironment _env;
        public ContractRepo(ApplicationDbContext appDbContext, IHostingEnvironment env)
        {
            _appDbContext = appDbContext;

            _env = env;
        }

        public async Task AddContractAsync(Contract contract)
        {
            await _appDbContext.TContracts.AddAsync(contract);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Contract> FindContractByIdAsync(string contractId)
        {
            return await _appDbContext.TContracts.Where(f => f.ContractId == contractId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ContractFileDetails>> GetAllContractAssign()
        {
           return await (from c in _appDbContext.TContracts
                      join a in _appDbContext.TAmendments
                        on c.Id equals a.ContractRefId
                      join sr in _appDbContext.TSource
                        on a.SourceId equals sr.Id
                      join sc in _appDbContext.SysCarriers
                        on c.CarrierRefId equals sc.Id
                      join u in _appDbContext.Users
                        on c.CreatorRefId equals u.Id
                      join st in _appDbContext.TStartedWorkflows
                        on a.Id equals st.AmendmendId into str from st in str.DefaultIfEmpty()
                      select new ContractFileDetails {
                          CarrierLogo = sc.CarrierDirPath,
                          CarrierName = sc.CarrierName,
                          ContractId = c.ContractId,
                          AmendmentId = a.AmendmentId,
                          CreatedOn = a.CreatedDate,
                          CreatedBy = new UserInfo { FirstName = u.FirstName, LastName = u.LastName },
                          ContractType = Constants.ContractType()[a.AmendmentType.ToString()],
                          StartedId = st.Id,
                          Started = st.Activate
                      }).ToListAsync();
        }
    }
}
