using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExtractorCorePortal.Helpers
{
    public class Generate
    {
        public static class String{

            public static async Task<string> GUI()
            {
                return await Task.FromResult(Guid.NewGuid().ToString());
            }
        }
    }
}
