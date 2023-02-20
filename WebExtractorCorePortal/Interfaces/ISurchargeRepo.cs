using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExtractorCorePortal.Interfaces
{
    public interface ISurchargeRepo
    {
        Task<IEnumerable<Object>> FindSurcharge(string value);
    }
}   
