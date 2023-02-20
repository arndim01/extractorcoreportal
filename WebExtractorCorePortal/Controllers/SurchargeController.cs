using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebExtractorCorePortal.Interfaces;

namespace WebExtractorCorePortal.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class SurchargeController : ControllerBase
    {

        private readonly ClaimsPrincipal _caller;
        private readonly IHostingEnvironment _env;
        private readonly ISurchargeRepo _surchargeRepo;
        public SurchargeController(IHostingEnvironment env, IHttpContextAccessor httpContextAccessor,
            ISurchargeRepo surchargeRepo)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _env = env;
            _surchargeRepo = surchargeRepo;

        }

        [HttpGet("getsurcharges/{scode}")]
        public async Task<IActionResult> GetSurcharges(string scode)
        {
            if (String.IsNullOrWhiteSpace(scode)) return new EmptyResult() ;
            try
            {
                var surcharge = await _surchargeRepo.FindSurcharge(scode);
                return new OkObjectResult(surcharge);
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
    }
}