using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONEConverter.Context;
using ONEConverter.Helper;
using ONEConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONEConverter.Builder
{
    public class RatesBuilder<T> : IOneBuild<T> where T : class
    {
        public IItem<T> Details { get; set; }
        public async Task CompileDataTable(string xmlJSON, string ContractId, string AmdId)
        {
            Details = new Items<T>();
            dynamic jsonObject = JsonConvert.DeserializeObject(xmlJSON);
            var rates_structures = jsonObject["ONE"]["RATES"];
            var total_rates = jsonObject["ONE"]["DATA_MISC"]["TOTAL_RATES"];
            var contractinfo_structures = jsonObject["ONE"]["CONTRACT_INFO"];
            JToken contractinfo_token = (JToken)contractinfo_structures;
            int gen_id = 1;
            //try
            //{

            if ( Convert.ToInt32(total_rates) == 1)
                {
                    JToken rate = (JToken)rates_structures;
                    var colorArray = JObject.FromObject (rate["COLOR_SCHEME"]);
                    Dictionary<string, string> scheme_mode = await Generate.ColorSchemes((JArray)rate["COLOR_SCHEME"]);

                    string DATA_TYPE = "NORMAL";
                    if (scheme_mode["TYPE"] == "CUSTOM" || scheme_mode["TYPE"] == "CONFIRM")
                    {
                        DATA_TYPE = scheme_mode["DATA_TYPE"];
                    }
                    else if (scheme_mode["TYPE"] == "EMPTY")
                    {
                        DATA_TYPE = "NO_COLOR_EXIST";
                    }
                    string gen_code = "2-" + ContractId + "-" + AmdId + "-RATES-" + gen_id;

                    var itemRates = new List<dynamic>
                    {
                        rate["VALIDITY_INFO"]["EFFECTIVE_DATE"].Value<string>(),
                        rate["VALIDITY_INFO"]["EXPIRATION_DATE"].Value<string>(),
                        rate["COMMODITY"]["COMMODITY_CODE"].Value<string>(),

                        rate["ORIGIN_INFO"]["CITY_DETAIL"].Value<string>(),
                        rate["ORIGIN_INFO"]["CITY_VIA_DETAIL"].Value<string>(),
                        rate["DESTINATION_INFO"]["CITY_DETAIL"].Value<string>(),
                        rate["DESTINATION_INFO"]["CITY_VIA_DETAIL"].Value<string>(),

                        rate["MISCRATE_INFO"]["MODE"].Value<string>(),
                        rate["MISCRATE_INFO"]["CUSTOM_NOTES"].Value<string>(),
                        rate["MISCRATE_INFO"]["NUMBER_NOTES"].Value<string>(),
                        rate["MISCRATE_INFO"]["HAZ_TYPE"].Value<string>(),
                        rate["MISCRATE_INFO"]["ORG_SERVICE"].Value<string>(),
                        rate["MISCRATE_INFO"]["DEST_SERVICE"].Value<string>(),

                        rate["BASERATE_INFO"]["BR_20"].Value<string>(),
                        rate["BASERATE_INFO"]["BR_40"].Value<string>(),
                        rate["BASERATE_INFO"]["BR_40HC"].Value<string>(),
                        rate["BASERATE_INFO"]["BR_45"].Value<string>(),
                        rate["BASERATE_INFO"]["CONTAINER_TYPE"].Value<string>(),
                        rate["BASERATE_INFO"]["CURRENCY"].Value<string>(),
                        rate["BASERATE_INFO"]["RATE_TYPE"].Value<string>(),

                        rate["SCOPE_INFO"]["TRADE"].Value<string>(),

                        DATA_TYPE,

                        rate["GROUP_ID"].Value<string>(),
                        rate["TABLE_ID"].Value<string>(),
                        gen_code
                    };

                    Details.Add(itemRates as T);
                    gen_id++;

                }
                else if( Convert.ToInt32(total_rates) > 1)
                {
                    
                    JArray rate_items = (JArray)rates_structures;
                    foreach(var rate in rate_items)
                    {
                        Dictionary<string, string> scheme_mode = await Generate.ColorSchemes((JArray)rate["COLOR_SCHEME"]);


                        string DATA_TYPE = "NORMAL";
                        if (scheme_mode["TYPE"] == "CUSTOM" || scheme_mode["TYPE"] == "CONFIRM")
                        {
                            DATA_TYPE = scheme_mode["DATA_TYPE"];
                        }
                        else if( scheme_mode["TYPE"] == "EMPTY")
                        {
                            DATA_TYPE = "NO_COLOR_EXIST";
                        }
                        string gen_code = "2-" + ContractId + "-" + AmdId + "-RATES-" + gen_id;
                        var itemRates = new List<dynamic>
                        {
                            rate["VALIDITY_INFO"]["EFFECTIVE_DATE"].Value<string>(),
                            rate["VALIDITY_INFO"]["EXPIRATION_DATE"].Value<string>(),
                            rate["COMMODITY"]["COMMODITY_CODE"].Value<string>(),

                            rate["ORIGIN_INFO"]["CITY_DETAIL"].Value<string>(),
                            rate["ORIGIN_INFO"]["CITY_VIA_DETAIL"].Value<string>(),
                            rate["DESTINATION_INFO"]["CITY_DETAIL"].Value<string>(),
                            rate["DESTINATION_INFO"]["CITY_VIA_DETAIL"].Value<string>(),

                            rate["MISCRATE_INFO"]["MODE"].Value<string>(),
                            rate["MISCRATE_INFO"]["CUSTOM_NOTES"].Value<string>(),
                            rate["MISCRATE_INFO"]["NUMBER_NOTES"].Value<string>(),
                            rate["MISCRATE_INFO"]["HAZ_TYPE"].Value<string>(),
                            rate["MISCRATE_INFO"]["ORG_SERVICE"].Value<string>(),
                            rate["MISCRATE_INFO"]["DEST_SERVICE"].Value<string>(),

                            rate["BASERATE_INFO"]["BR_20"].Value<string>(),
                            rate["BASERATE_INFO"]["BR_40"].Value<string>(),
                            rate["BASERATE_INFO"]["BR_40HC"].Value<string>(),
                            rate["BASERATE_INFO"]["BR_45"].Value<string>(),
                            rate["BASERATE_INFO"]["CONTAINER_TYPE"].Value<string>(),
                            rate["BASERATE_INFO"]["CURRENCY"].Value<string>(),                       
                            rate["BASERATE_INFO"]["RATE_TYPE"].Value<string>(),

                            rate["SCOPE_INFO"]["TRADE"].Value<string>(),

                            DATA_TYPE,

                            rate["GROUP_ID"].Value<string>(),
                            rate["TABLE_ID"].Value<string>(),
                            gen_code
                        };

                        Details.Add(itemRates as T);
                        gen_id++;
                    }
                }
            //}
            //catch
            //{


            //}

        }
    }
}
