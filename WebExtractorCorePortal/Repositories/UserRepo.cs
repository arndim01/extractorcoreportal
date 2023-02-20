using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Repositories
{
    public class UserRepo : IUserRepo
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public UserRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ApplicationUser> GetUserInfo(string userId)
        {
            return await _applicationDbContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        }
    }
}
