using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedTokenAsync(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}
