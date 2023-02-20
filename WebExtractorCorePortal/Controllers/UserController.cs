using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
            _userManager = userManager;
        }
        [HttpGet("claims")]
        public async Task<IActionResult> Claims()
        {
            try
            {
                var userId = _caller.Claims.Single(c => c.Type == "id");
                var roles = _caller.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Role);
                var user = await _appDbContext.CUserDetails.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId.Value);
                if( user != null)
                {
                    return new OkObjectResult(new
                    {
                        user.Identity.Id,
                        user.Identity.FirstName,
                        user.Identity.LastName,
                        user.Identity.UserName,
                        roles.Value
                    });
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
        [HttpGet("roles")]
        public IActionResult Roles()
        {
            try
            {
                var roles = _caller.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Role);
                if( roles != null)
                {
                    return new OkObjectResult(new
                    {
                        roles.Value,
                        DateTime.Now
                    });
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
    }
}