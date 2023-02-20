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
    public class CityBuilder<T> : IOneBuild<T> where T : class
    {
        public IItem<T> Details { get; set; }
        public async Task CompileDataTable(string xmlJSON, string ContractId, string AmdId)
        {
            Details = new Items<T>();
            dynamic jsonObject = JsonConvert.DeserializeObject(xmlJSON);
            JArray items;
            string code = "";
            var structures = jsonObject["ONE"]["RATES"];
            var totalRates = jsonObject["ONE"]["DATA_MISC"]["TOTAL_RATES"];
            var totalArbs = jsonObject["ONE"]["DATA_MISC"]["TOTAL_ARBS"];
            var contractinfo_structures = jsonObject["ONE"]["CONTRACT_INFO"];
            JToken contractinfo_token = (JToken)contractinfo_structures;
            items = (JArray)structures;
            int gen_id = 1;
            for (int loop = 0; loop < Convert.ToInt32(totalRates); loop++)
            {
                string value = Convert.ToString(structures[loop]["ORIGIN_INFO"]["CITY_DETAIL"]);

                if (!String.IsNullOrWhiteSpace(value))
                {
                    code = value.Replace(",", "").Replace(" ", "").HashData();
                    var detail = await Task.Run( () =>  Details.Cast<List<dynamic>>().AsEnumerable().Where(c => c[0] == code).FirstOrDefault());
                    if (detail == null)
                    {
                        string gen_code = "2-" + ContractId + "-" + AmdId + "-CITY-" + gen_id;
                        var dict = new List<dynamic>()
                        {
                            code,
                            value,
                            gen_code
                        };
                        Details.Add(dict as T);
                        gen_id++;
                    }
                }
                value = Convert.ToString(structures[loop]["ORIGIN_INFO"]["CITY_VIA_DETAIL"]);

                if (!String.IsNullOrWhiteSpace(value))
                {
                    code = value.Replace(",", "").Replace(" ", "").HashData();
                    var detail = await Task.Run( () => Details.Cast<List<dynamic>>().AsEnumerable().Where(c => c[0] == code).FirstOrDefault());
                    if (detail == null)
                    {
                        string gen_code = "2-" + ContractId + "-" + AmdId + "-CITY-" + gen_id;
                        var dict = new List<dynamic>()
                        {
                            code,
                            value,
                            gen_code
                        };
                        Details.Add(dict as T);
                        gen_id++;
                    }
                }
                value = Convert.ToString(structures[loop]["DESTINATION_INFO"]["CITY_DETAIL"]);
                if (!String.IsNullOrWhiteSpace(value))
                {
                    code = value.Replace(",", "").Replace(" ", "").HashData();
                    var detail = await Task.Run ( () => Details.Cast<List<dynamic>>().AsEnumerable().Where(c => c[0] == code).FirstOrDefault());
                    if (detail == null)
                    {
                        string gen_code = "2-" + ContractId + "-" + AmdId + "-CITY-" + gen_id;
                        var dict = new List<dynamic>()
                        {
                           code,
                           value,
                           gen_code
                        };
                        Details.Add(dict as T);
                        gen_id++;
                    }
                }
                value = Convert.ToString(structures[loop]["DESTINATION_INFO"]["CITY_VIA_DETAIL"]);
                if (!String.IsNullOrWhiteSpace(value))
                {
                    code = value.Replace(",", "").Replace(" ", "").HashData();
                    var detail = await Task.Run( () => Details.Cast<List<dynamic>>().AsEnumerable().Where(c => c[0] == code).FirstOrDefault());
                    if (detail == null)
                    {
                        string gen_code = "2-" + ContractId + "-" + AmdId + "-CITY-" + gen_id;
                        var dict = new List<dynamic>()
                        {
                            code,
                            value,
                            gen_code
                        };
                        Details.Add(dict as T);
                        gen_id++;
                    }
                }
            }

            structures = jsonObject["ONE"]["ARBITRARY"];
            items = (JArray)structures;
            for (int loop = 0; loop < Convert.ToInt32(totalArbs); loop++)
            {
                string value = Convert.ToString(structures[loop]["INLAND_INFO"]["CITY_DETAIL"]);
                if (!String.IsNullOrWhiteSpace(value))
                {
                    code = value.Replace(",", "").Replace(" ", "").HashData();
                    var detail = await Task.Run( () =>  Details.Cast<List<dynamic>>().AsEnumerable().Where(c => c[0] == code).FirstOrDefault());
                    if (detail == null)
                    {
                        string gen_code = "2-" + ContractId + "-" + AmdId + "-CITY-" + gen_id;
                        var dict = new List<dynamic>()
                        {
                            code,
                            value,
                            gen_code
                        };
                        Details.Add(dict as T);
                        gen_id++;
                    }
                }
                value = Convert.ToString(structures[loop]["INLAND_INFO"]["CITY_VIA_DETAIL"]);
                if (!String.IsNullOrWhiteSpace(value))
                {
                    code = value.Replace(",", "").Replace(" ", "").HashData();
                    var detail = await Task.Run( () => Details.Cast<List<dynamic>>().AsEnumerable().Where(c => c[0] == code).FirstOrDefault());
                    if (detail == null)
                    {
                        string gen_code = "2-" + ContractId + "-" + AmdId + "-CITY-" + gen_id;
                        var dict = new List<dynamic>()
                        {
                            code,
                            value,
                            gen_code
                        };
                        Details.Add(dict as T);
                        gen_id++;
                    }
                }
            }
        }
    }
}
