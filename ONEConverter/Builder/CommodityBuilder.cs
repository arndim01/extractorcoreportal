using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONEConverter.Extension;
using ONEConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONEConverter.Builder
{
    public class CommodityBuilder<T> : IOneBuild<T> where T : class
    {
        public IItem<T> Details { get; set; }
        public async Task CompileDataTable(string xmlJSON, string ContractId, string AmdId)
        {
            Details = new Items<T>();
            dynamic jsonObject = JsonConvert.DeserializeObject(xmlJSON);
            var structures = jsonObject["ONE"]["RATES"];
            var contractinfo_structures = jsonObject["ONE"]["CONTRACT_INFO"];
            JToken contractinfo_token = (JToken)contractinfo_structures;
            JArray items = (JArray)structures;
            int gen_id = 1;
            for (int loop = 0; loop < items.Count; loop++)
            {
                string code = Convert.ToString(structures[loop]["COMMODITY"]["COMMODITY_DESC"]);
                string desc = Convert.ToString(structures[loop]["COMMODITY"]["COMMODITY_DESC"]);
                string excl = Convert.ToString(structures[loop]["COMMODITY"]["COMMODITY_EXCL"]);
                string nac = Convert.ToString(structures[loop]["COMMODITY"]["COMMODITY_NAC"]);
                var detail = await Task.Run(() =>  Details.Cast<List<dynamic>>().AsEnumerable().Where(c => c[0] == code.HashData()).FirstOrDefault());
                if (detail == null)
                {

                    string gen_code = "2-" + ContractId + "-" + AmdId + "-CMTY-" + gen_id.ToString(); 

                    var dict = new List<dynamic>()
                    {
                        code.HashData(),
                        code,
                        desc,
                        excl,
                        nac,
                        "",
                        gen_code
                    };
                    Details.Add(dict as T);
                    gen_id++;
                }
            }

        }
    }
}
