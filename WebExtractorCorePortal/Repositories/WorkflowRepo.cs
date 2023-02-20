using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Helpers;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Repositories
{
    public class WorkflowRepo : IWorkflowRepo
    {
        private readonly ApplicationDbContext _appDbContext;
        public WorkflowRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddStartWorkflow(StartedWorkflow workflow)
        {
            await _appDbContext.TStartedWorkflows.AddAsync(workflow);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<StartedWorkflow> FindStartedWorkflowById(long id)
        {
            return await _appDbContext.TStartedWorkflows.Where(f => f.Id == id).SingleOrDefaultAsync();
        }
        public async Task<object> FindClaimedWorkflow(string userId)
        {
            return await (from swf in _appDbContext.TStartedWorkflows
                          join wf in _appDbContext.TWorkflows
                                on swf.Id equals wf.SWorkflowRefId into  wff from wf in wff.DefaultIfEmpty()
                          join a in _appDbContext.TAmendments
                                on swf.AmendmendId equals a.Id
                          where wf.UClaimedRefId == userId && wf.Completed == false
                          select a).FirstOrDefaultAsync();
        }
        public async Task ToogleActivate(ContractFileDetails cfd)
        {
            var result = await FindStartedWorkflowById(cfd.StartedId);
            result.Activate = cfd.Started;
            result.Date = DateTime.Now;
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<WorkflowDetails>> GetAllWorkflows()
        {
            return await (from st in _appDbContext.TStartedWorkflows 
                          join a in _appDbContext.TAmendments
                            on st.AmendmendId equals a.Id
                          join c in _appDbContext.TContracts
                            on a.ContractRefId equals c.Id
                          join syc in _appDbContext.SysCarriers
                            on c.CarrierRefId equals syc.Id
                          join w in _appDbContext.TWorkflows
                            on st.Id equals w.SWorkflowRefId into wr from w in wr.DefaultIfEmpty()
                          join u in _appDbContext.Users
                            on w.UClaimedRefId equals u.Id into ucl from u in ucl.DefaultIfEmpty()
                          where st.Activate == true
                          select new WorkflowDetails
                          {
                              CarrierLogo = syc.CarrierDirPath,
                              CarrierName = syc.CarrierName,
                              ContractId = c.ContractId,
                              AmendmentId = a.AmendmentId,
                              ContractType = Constants.ContractType()[a.AmendmentType.ToString()],
                              Started = st.Date,
                              ClaimedBy = ( u == null ) ? new UserInfo(): new UserInfo { FirstName = u.FirstName, LastName = u.LastName},
                              ClaimedDate = ( u == null )? (DateTime?) null : w.ClaimedDate,
                              StartedId = st.Id
                          }).ToListAsync();
        } 

        public async Task ClaimWorkflow(WorkflowDetails workflowDetails, string userId)
        {
            var result = await _appDbContext.TWorkflows.Where(f => f.SWorkflowRefId == workflowDetails.StartedId).SingleOrDefaultAsync();
            if (result != null)
            {
                result.ClaimedDate = DateTime.Now;
                result.UClaimedRefId = userId;
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                var workflow = new Workflow()
                {
                    ClaimedDate = DateTime.Now,
                    CompletedDate = DateTime.Now,
                    UClaimedRefId = userId,
                    SWorkflowRefId = workflowDetails.StartedId
                };
                await _appDbContext.TWorkflows.AddAsync(workflow);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
