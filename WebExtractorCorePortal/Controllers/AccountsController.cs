using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Models;
using WebExtractorCorePortal.Helpers;

namespace WebExtractorCorePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        //POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
            await _userManager.AddToRoleAsync(userIdentity, "Member");
            await _appDbContext.CUserDetails.AddAsync(new UserDetails { IdentityId = userIdentity.Id });
            await _appDbContext.SaveChangesAsync();

            return Content("Account Created");
        }

    }
}