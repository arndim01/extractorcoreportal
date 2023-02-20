using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONEConverter.Helper;
using ONEConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONEConverter.Builder
{
    public class GroupArbsBuilder<T> : IOneBuild<T> where T : class
    {
        public IItem<T> Details { get; set; }

        public async Task CompileDataTable(string xmlJSON, string ContractId, string AmdId)
        {
            Details = new Items<T>();

            dynamic jsonObject = JsonConvert.DeserializeObject(xmlJSON);
            var arbs_group_structure = jsonObject["ONE"]["ARB_GROUP_NOTES"];
            var arbs_structure = jsonObject["ONE"]["ARBITRARY"];
            var total_groupnotes = jsonObject["ONE"]["DATA_MISC"]["TOTAL_GROUPNOTES_ARBS"];

            //try
            //{
                if( Convert.ToInt32(total_groupnotes) == 1)
                {
                    JToken notes = (JToken)arbs_group_structure;
                    JArray rate_items = (JArray)arbs_structure;
                    int ID = (int)notes["ID"];
                    int COLOR_SCHEME_COUNT = Convert.ToInt32(notes["COLOR_SCHEME_COUNT"]);
                    var color_scheme = await Generate.ColorSchemeNotes(notes, COLOR_SCHEME_COUNT);
                    var groupTables = rate_items.Where(obj => obj["TABLE_ID"].Value<int>() == ID);
                    var number_notes = new List<dynamic>();
                    foreach (var rates in groupTables)
                    {
                        Console.WriteLine(rates["ID"]);
                        if (!String.IsNullOrWhiteSpace(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<string>()))
                        {
                            if (!number_notes.Contains(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<string>()))
                            {
                                number_notes.Add(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<string>());
                            }
                        }
                    }
                    var itemNotes = new List<dynamic>
                    {
                        notes["NOTES"].Value<string>(),
                        notes["ID"].Value<string>(),
                        notes["EXTRACT_FROM"].Value<string>(),
                        number_notes.OrderBy(n => n).ToList(),
                        color_scheme
                    };
                    Details.Add(itemNotes as T);

                }
                else if( Convert.ToInt32(total_groupnotes) > 1)
                {
                    JArray item_notes = (JArray)arbs_group_structure;
                    JArray rate_items = (JArray)arbs_structure;
                    foreach (var notes in item_notes)
                    {
                        
                        int COLOR_SCHEME_COUNT = Convert.ToInt32(notes["COLOR_SCHEME_COUNT"]);
                        var color_scheme = await Generate.ColorSchemeNotes(notes, COLOR_SCHEME_COUNT);
                        int ID = (int)notes["ID"];
                    //Console.WriteLine(  ID);
                        var groupTables = rate_items.Where(obj => obj["TABLE_ID"].Value<int>() == ID);
                        var number_notes = new List<dynamic>();
                    //Console.WriteLine(groupTables);
                        foreach (var rates in groupTables)
                        {
                            Console.WriteLine(rates["ID"]);
                            if (!String.IsNullOrWhiteSpace(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<string>()))
                            {
                                if (!number_notes.Contains(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<string>()))
                                {
                                    number_notes.Add(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<string>());
                                }
                            }
                        }
                        var itemNotes = new List<dynamic>
                        {
                            notes["NOTES"].Value<string>(),
                            notes["ID"].Value<string>(),
                            notes["EXTRACT_FROM"].Value<string>(),
                            number_notes.OrderBy(n => n).ToList(),
                            color_scheme
                        };
                        Details.Add(itemNotes as T);
                    }
                }
            //}
            //catch
            //{

            //}

        }
    }
}
