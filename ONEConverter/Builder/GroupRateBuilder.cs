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
    public class GroupRateBuilder<T> : IOneBuild<T> where T : class
    {
        public IItem<T> Details { get; set; }

        public async Task CompileDataTable(string xmlJSON, string ContractId, string AmdId)
        {
            Details = new Items<T>();

            dynamic jsonObject = JsonConvert.DeserializeObject(xmlJSON);
            var group_structure = jsonObject["ONE"]["GROUP_NOTES"];
            var rates_structures = jsonObject["ONE"]["RATES"];
            var total_groupnotes = jsonObject["ONE"]["DATA_MISC"]["TOTAL_GROUPNOTES_RATES"];
            var contractinfo_structures = jsonObject["ONE"]["CONTRACT_INFO"];
            JToken contractinfo_token = (JToken)contractinfo_structures;
            int gen_id = 1;
            //try
            //{
                if ( Convert.ToInt32(total_groupnotes)  == 1)
                {
                    JToken notes = (JToken)group_structure;
                    JArray rate_items = (JArray)rates_structures;
                    int ID = (int)notes["ID"];
                    int TOTAL_RNOTES = Convert.ToInt32(notes["TOTAL_NOTES"]);
                    int COLOR_SCHEME_COUNT = Convert.ToInt32(notes["COLOR_SCHEME_COUNT"]);
                    var groupTables = rate_items.Where(obj => obj["GROUP_ID"].Value<int>() == ID);
                    var color_scheme = await Generate.ColorSchemeNotes(notes, COLOR_SCHEME_COUNT);
                    var rateline_item = new List<List<dynamic>>();

                    
                    if (TOTAL_RNOTES == 1)
                    {
                        int R_COLOR_SCHEME_COUNT = Convert.ToInt32(notes["RATE_ITEMS"]["COLOR_SCHEME_COUNT"]);
                        if(R_COLOR_SCHEME_COUNT > 0)
                        {
                            var r_color_scheme = await Generate.ColorSchemeNotes(notes["RATE_ITEMS"], R_COLOR_SCHEME_COUNT);
                            var tables = groupTables.Where(obj => obj["TABLE_ID"].Value<int>() == notes["RATE_ITEMS"]["ID"].Value<int>());
                            var number_notes = new List<dynamic>();
                            foreach(var rates in tables)
                            {
                                if( !number_notes.Contains(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<long>()))
                                {
                                    number_notes.Add(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<long>());
                                }
                            }

                            var item = new List<dynamic>
                            {
                                notes["RATE_ITEMS"]["NOTES"].Value<string>(),
                                notes["RATE_ITEMS"]["ID"].Value<string>(),
                                number_notes.OrderBy(n => n).ToList(),
                                r_color_scheme
                            };
                            rateline_item.Add(item);
                            
                        }
                    
                    }
                    else if (TOTAL_RNOTES > 1)
                    {
                        foreach (var rnotes in notes["RATE_ITEMS"])
                        {
                            int R_COLOR_SCHEME_COUNT = Convert.ToInt32(rnotes["COLOR_SCHEME_COUNT"]);
                            if(R_COLOR_SCHEME_COUNT > 0){
                                var r_color_scheme = await Generate.ColorSchemeNotes(rnotes["COLOR_SCHEME"], R_COLOR_SCHEME_COUNT);
                                var tables = groupTables.Where(obj => obj["TABLE_ID"].Value<int>() == rnotes["ID"].Value<int>());
                                var number_notes = new List<dynamic>();
                                foreach(var rates in tables)
                                {
                                    if (!number_notes.Contains(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<long>()))
                                    {
                                        number_notes.Add(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<long>());
                                    }
                                }
                                var item = new List<dynamic>
                                {
                                    rnotes["NOTES"].Value<string>(),
                                    rnotes["ID"].Value<string>(),
                                    number_notes.OrderBy(n => n).ToList(),
                                    r_color_scheme
                                };
                                rateline_item.Add(item);
                            }
                        }
                    }
                    int genId = 1;
                    string genCode = "2-" + ContractId + "-" + AmdId + "-NOTES-" + genId;
                    var itemNotes = new List<dynamic>
                    {
                        notes["NOTES"].Value<string>(),
                        notes["ID"].Value<string>(),
                        color_scheme,
                        rateline_item,
                        genCode
                    };
                    Details.Add(itemNotes as T);
                    genId++;
                }
                else if( Convert.ToInt32(total_groupnotes) > 1)
                {
                    JArray item_notes = (JArray)group_structure;
                    JArray rate_items = (JArray)rates_structures;
                    
                    foreach ( var notes in item_notes)
                    {
                        int ID = (int)notes["ID"];
                        var groupTables = rate_items.Where(obj => obj["GROUP_ID"].Value<int>() == ID);
                        int TOTAL_RNOTES = Convert.ToInt32(notes["TOTAL_NOTES"]);
                        int COLOR_SCHEME_COUNT = Convert.ToInt32(notes["COLOR_SCHEME_COUNT"]);
                        Console.WriteLine("GROUP ID: " + ID);
                        var color_scheme = await Generate.ColorSchemeNotes(notes, COLOR_SCHEME_COUNT);
                        var rateline_item = new List<List<dynamic>>();
                        if (TOTAL_RNOTES == 1)
                        {
                            int R_COLOR_SCHEME_COUNT = Convert.ToInt32(notes["RATE_ITEMS"]["COLOR_SCHEME_COUNT"]);
                            
                            if (R_COLOR_SCHEME_COUNT > 0)
                            {
                                var tables = groupTables.Where(obj => obj["TABLE_ID"].Value<int>() == notes["RATE_ITEMS"]["ID"].Value<int>());
                                var r_color_scheme = await Generate.ColorSchemeNotes(notes["RATE_ITEMS"], R_COLOR_SCHEME_COUNT);
                                var number_notes = new List<dynamic>();
                                foreach(var rates in tables)
                                {
                                    if (!number_notes.Contains(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<long>()))
                                    {
                                        number_notes.Add(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<long>());
                                    }
                                }
                                var item = new List<dynamic>
                                {
                                    notes["RATE_ITEMS"]["NOTES"].Value<string>(),
                                    notes["RATE_ITEMS"]["ID"].Value<string>(),
                                    number_notes.OrderBy(n => n).ToList(),
                                    r_color_scheme
                                };
                                rateline_item.Add(item);

                            }
                        }
                        else if (TOTAL_RNOTES > 1)
                        {
                            foreach (var rnotes in notes["RATE_ITEMS"])
                            {
                                int R_COLOR_SCHEME_COUNT = Convert.ToInt32(rnotes["COLOR_SCHEME_COUNT"]);
                                if(R_COLOR_SCHEME_COUNT > 0)
                                {
                                    var tables = groupTables.Where(obj => obj["TABLE_ID"].Value<int>() == rnotes["ID"].Value<int>());
                                    var r_color_scheme = await Generate.ColorSchemeNotes(rnotes, R_COLOR_SCHEME_COUNT);
                                    var number_notes = new List<dynamic>();
                                    foreach(var rates in tables)
                                    {
                                        if (!number_notes.Contains(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<long>()))
                                        {
                                            number_notes.Add(rates["MISCRATE_INFO"]["NUMBER_NOTES"].Value<long>());
                                        }
                                    }
                                    var item = new List<dynamic>
                                    {
                                        rnotes["NOTES"].Value<string>(),
                                        rnotes["ID"].Value<string>(),
                                        number_notes.OrderBy(n => n).ToList(),
                                        r_color_scheme
                                    };
                                    rateline_item.Add(item);
                                }
                                
                            }
                        }
                        int genId = 1;
                        string genCode = "2-" + ContractId + "-" + AmdId + "-NOTES-" + genId;
                        var itemNotes = new List<dynamic>
                        {
                            notes["NOTES"].Value<string>(),
                            notes["ID"].Value<string>(),
                            color_scheme,
                            rateline_item,
                            genCode
                        };
                        Details.Add(itemNotes as T);
                        genId++;
                    }
                }
                else
                {
                    var test = new List<dynamic>
                    {
                        "failed",
                        total_groupnotes
                    };
                    Details.Add(test as T);
                }
            //}
            //catch
            //{

            //}
        }
    }
}
