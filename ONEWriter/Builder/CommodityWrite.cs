using Newtonsoft.Json;
using ONEWriter.Extension;
using ONEWriter.Interfaces;
using ONEWriter.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONEWriter.Builder
{
    public class CommodityWrite : IOneWrite
    {
        public async Task OnConstructJsonData(string FilePath, long CarrierId, string ContractId, string AmdId)
        {
            IExtractorRepo _extractorRepo = new ExtractorRepo();
            dynamic jsonObject = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(FilePath));
            foreach (var item in jsonObject["Details"])
            {
                RateCommodity libcommodity = await _extractorRepo.FindLibCommodityByHashValue(item[0], CarrierId);
                if (libcommodity != null)
                {

                    var commodity = new RateCommodity
                    {
                        GenId = item[6],
                        Main_value = libcommodity.Main_value,
                        Main_value_hash = libcommodity.Main_value_hash,
                        Code = libcommodity.Code,
                        Description = libcommodity.Description,
                        Brief_description = libcommodity.Brief_description,
                        Nac = libcommodity.Nac,
                        Exclusion = libcommodity.Exclusion
                    };
                    await _extractorRepo.AddCommodityAsync(commodity);

                }
            }



        }
    }
}
