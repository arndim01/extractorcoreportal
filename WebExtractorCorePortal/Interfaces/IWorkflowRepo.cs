using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Interfaces
{
    public interface IWorkflowRepo
    {
        Task AddStartWorkflow(StartedWorkflow workflow);
        Task<StartedWorkflow> FindStartedWorkflowById(long id);
        Task ToogleActivate(ContractFileDetails cfd);
        Task<IEnumerable<WorkflowDetails>> GetAllWorkflows();
        Task ClaimWorkflow(WorkflowDetails workflowDetails, string userId);
        Task<object> FindClaimedWorkflow(string userId);
    }
}
