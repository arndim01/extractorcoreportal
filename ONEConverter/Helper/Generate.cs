using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ONEConverter.Context;
using ONEConverter.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ONEConverter.Helper
{
    public static class Generate
    {
        internal static async Task<List<List<string>>> ColorSchemeNotes (JToken JSON, int count)
        {

            ApplicationContext applicationContext = new ApplicationContext();
            var notes = new List<List<string>>();

            if( count == 1)
            {
                var color_scheme = JSON;


                if (color_scheme["COLOR_SCHEME"]["DEFAULT_SCHEME"].Value<string>() == "CUSTOM")
                {
                    if (color_scheme["COLOR_SCHEME"]["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "COLOR")
                    {
                        string value = color_scheme["COLOR_SCHEME"]["COLOR_VALUE"].Value<string>();
                        var color =  await (from cc in applicationContext.SysColorSchemeColoreds
                                           where cc.HtmlColor.Contains(value) || cc.ColorName == value
                                           select new
                                           {
                                               Color = cc
                                           }).SingleOrDefaultAsync();

                        if (color != null)
                        {
                            var n = new List<string>
                            {
                                color.Color.HtmlColor.ColorCode(),
                                color_scheme["COLOR_SCHEME"]["TEXT_VALUE"].Value<string>()
                            };
                            notes.Add(n);
                        }
                    }
                    else if (color_scheme["COLOR_SCHEME"]["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "INDEXED")
                    {
                        string value = color_scheme["COLOR_SCHEME"]["COLOR_INDEX"].Value<string>();
                        int valueInt = Convert.ToInt32(value);
                        var color = await  (from ci in applicationContext.SysColorSchemeIndexeds
                                           where ci.Indexed == valueInt || ci.HtmlColor.Contains(value)
                                           select new
                                           {
                                               Color = ci
                                           }).SingleOrDefaultAsync();

                        if (color != null)
                        {
                            var n = new List<string>
                            {
                                color.Color.HtmlColor.ColorCode(),
                                color_scheme["COLOR_SCHEME"]["TEXT_VALUE"].Value<string>()
                            };
                            notes.Add(n);
                        }
                    }
                    else if( color_scheme["COLOR_SCHEME"]["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "THEME")
                    {
                        var n = new List<string>
                        {
                            color_scheme["COLOR_SCHEME"]["COLOR_THEME"].Value<string>(),
                            color_scheme["COLOR_SCHEME"]["TEXT_VALUE"].Value<string>()
                        };
                        notes.Add(n);
                    }
                    else
                    {
                        var n = new List<string>
                        {
                            "NO_COLOR",
                            color_scheme["COLOR_SCHEME"]["TEXT_VALUE"].Value<string>()
                        };
                        notes.Add(n);
                    }
                }
                else if (color_scheme["COLOR_SCHEME"]["DEFAULT_SCHEME"].Value<string>() == "DEFAULT")
                {
                    var n = new List<string>
                    {
                        "NO_COLOR",
                        color_scheme["COLOR_SCHEME"]["TEXT_VALUE"].Value<string>()
                    };
                    notes.Add(n);
                }

            }
            else if(count > 1)
            {
                foreach (var color_scheme in JSON["COLOR_SCHEME"])
                {

                    if (color_scheme["DEFAULT_SCHEME"].Value<string>() == "CUSTOM")
                    {
                        if (color_scheme["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "COLOR")
                        {
                            string value = color_scheme["COLOR_VALUE"].Value<string>();
                            var color = await (from cc in applicationContext.SysColorSchemeColoreds
                                               where cc.HtmlColor.Contains(value) || cc.ColorName == value
                                               select new
                                               {
                                                   Color = cc,
                                               }).SingleOrDefaultAsync();

                            if (color != null)
                            {
                                var n = new List<string>
                                {
                                    color.Color.HtmlColor.ColorCode(),
                                    color_scheme["TEXT_VALUE"].Value<string>()
                                };
                                notes.Add(n);
                            }
                        }
                        else if (color_scheme["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "INDEXED")
                        {
                            string value = color_scheme["COLOR_INDEX"].Value<string>();
                            int valueInt = Convert.ToInt32(value);
                            var color = await (from ci in applicationContext.SysColorSchemeIndexeds
                                               where ci.Indexed == valueInt || ci.HtmlColor.Contains(value)
                                               select new
                                               {
                                                   Color = ci
                                               }).SingleOrDefaultAsync();

                            if (color != null)
                            {
                                var n = new List<string>
                                {
                                    color.Color.HtmlColor.ColorCode(),
                                    color_scheme["TEXT_VALUE"].Value<string>()
                                };
                                notes.Add(n);
                            }
                        }
                        else if( color_scheme["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "THEME")
                        {
                            var n = new List<string>
                            {
                                "NO_COLOR_THEME",
                                color_scheme["TEXT_VALUE"].Value<string>()
                            };
                            notes.Add(n);
                        }
                        else
                        {
                            var n = new List<string>
                            {
                                "NO_COLOR",
                                color_scheme["TEXT_VALUE"].Value<string>()
                            };
                            notes.Add(n);
                        }
                    }
                    else if (color_scheme["DEFAULT_SCHEME"].Value<string>() == "DEFAULT")
                    {
                        var n = new List<string>
                        {
                            "NO_COLOR",
                            color_scheme["TEXT_VALUE"].Value<string>()
                        };
                        notes.Add(n);
                    }
                }
            }

            return notes;
        }
        internal static async Task<Dictionary<string, string>> ColorSchemes(JArray JSON)
        {
            ApplicationContext applicationContext = new ApplicationContext();
            Dictionary<string, string> scheme_mode = new Dictionary<string, string>
            {
                    {"TYPE","EMPTY"}
            };

            if( JSON.Count > 0)
            {
                
                foreach (var color_scheme in JSON)
                {

                    if (color_scheme["DEFAULT_SCHEME"].Value<string>() == "CUSTOM")
                    {
                        if (color_scheme["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "COLOR")
                        {
                            string value = color_scheme["COLOR_VALUE"].Value<string>().ToLowerInvariant();
                            var color = await (from cc in applicationContext.SysColorSchemeColoreds
                                               join cd in applicationContext.SysColorSchemeDetails
                                                    on cc.Id equals cd.SysColorRefId into cccd from cd in cccd.DefaultIfEmpty()
                                               where cc.HtmlColor.Contains(value) || cc.ColorName == value
                                               select new
                                               {
                                                   Color = cc,
                                                   ColorDetail = cd
                                               }).SingleOrDefaultAsync();
                            if (color != null)
                            {
                                scheme_mode = new Dictionary<string, string>
                                {
                                        {"TYPE","CUSTOM"},
                                        {"COLOR", color.Color.HtmlColor },
                                        {"DATA_TYPE", color.ColorDetail == null ? "DATA_TYPE_EMPTY" : color.ColorDetail.DataType }
                                };
                                if (color.Color.Prio) break;
                            }
                        }
                        else if (color_scheme["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "INDEXED")
                        {
                            string value = color_scheme["COLOR_INDEX"].Value<string>();
                            
                            var color = await (from ci in applicationContext.SysColorSchemeIndexeds
                                               join cd in applicationContext.SysColorSchemeIndexedDetails
                                                    on ci.Id equals cd.SysColorRefId into cicd from cd in cicd.DefaultIfEmpty()
                                               where ci.Indexed == Convert.ToInt32(value) 
                                               select new
                                               {
                                                   Color = ci,
                                                   ColorDetail = cd
                                               }).SingleOrDefaultAsync();
                            if (color != null)
                            {
                                scheme_mode = new Dictionary<string, string>
                            {
                                {"TYPE","CUSTOM"},
                                {"COLOR", color.Color.HtmlColor },
                                {"DATA_TYPE", color.ColorDetail == null ? "DATA_TYPE_EMPTY" : color.ColorDetail.DataType }
                            };
                                if (color.Color.Prio) break;
                            }
                        }
                        else if(color_scheme["COLOR_TYPE"].Value<string>().ToUpperInvariant() == "THEME")
                        {
                            scheme_mode = new Dictionary<string, string>
                            {
                                {"TYPE","CUSTOM"},
                                {"COLOR",  color_scheme["COLOR_THEME"].Value<string>() },
                                {"DATA_TYPE", "CONFIRMATION" }
                            };
                        }
                        else
                        {
                            scheme_mode = new Dictionary<string, string>
                            {
                                {"TYPE","CONFIRM"},
                                {"COLOR",  "NO_COLOR_EXIST" },
                                {"DATA_TYPE", "CONFIRMATION" }
                            };
                        }
                    }
                    else if (color_scheme["DEFAULT_SCHEME"].Value<string>() == "DEFAULT")
                    {
                        scheme_mode = new Dictionary<string, string>
                        {
                            {"TYPE","DEFAULT"}
                        };
                    }
                }
            }

            return scheme_mode;
        }
    }
}
