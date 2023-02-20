using System;   
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly ClaimsPrincipal _caller;
        private readonly IWorkflowRepo _workflowRepo;

        public WorkflowController(IHttpContextAccessor httpContextAccessor,  IWorkflowRepo workflowRepo)
        {
            _workflowRepo = workflowRepo;
            _caller = httpContextAccessor.HttpContext.User;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("toogle")]
        public async Task<IActionResult> StartWorkFlow([FromBody] ContractFileDetails cfd)
        {
            if (!ModelState.IsValid) return new BadRequestResult();
            try
            {
                var result = await _workflowRepo.FindStartedWorkflowById(cfd.StartedId);
                if(result != null)
                {
                    await _workflowRepo.ToogleActivate(cfd);
                    if (cfd.Started == true) return Content("Contract Activate");
                    else if (cfd.Started == false) return Content("Contract Deactivate");
                    else return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                var list = await _workflowRepo.GetAllWorkflows();
                if(list != null)
                {
                    return new OkObjectResult(list);
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpPost("claim")]
        public async Task<IActionResult> Claim([FromBody] WorkflowDetails workflowDetails)
        {
            if (!ModelState.IsValid) return new BadRequestResult();
            try
            {
                var userId = _caller.Claims.Single(c => c.Type == "id");
                var claimed = await _workflowRepo.FindClaimedWorkflow(userId.Value);



                if( claimed == null )
                {
                    var result = _workflowRepo.FindStartedWorkflowById(workflowDetails.StartedId);
                    if (result != null)
                    {
                        await _workflowRepo.ClaimWorkflow(workflowDetails, userId.Value);
                        return Content("Claimed contract");
                    }
                    else
                    {
                        return new NotFoundResult();
                    }
                }
                else
                {
                    return new BadRequestObjectResult("You already claimed a contract. Release or complete the contract before claiming a new one.");
                }
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpGet("claimed")]
        public async Task<IActionResult> Claimed()
        {
            try
            {
                var userId = _caller.Claims.Single(c => c.Type == "id");
                var claimed = await _workflowRepo.FindClaimedWorkflow(userId.Value);

                if( claimed != null)
                {
                    return new OkObjectResult(claimed);
                }
                else
                {
                    return new BadRequestObjectResult("No contract claimed yet.");
                }
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
    }
}