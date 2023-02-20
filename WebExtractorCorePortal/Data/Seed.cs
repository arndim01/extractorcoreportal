
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Extentions;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Data
{
    public static class Seed
    {
        public static async Task INTIALIZE_DATABASE_DATA(IServiceProvider serviceProvider, IConfiguration Configuration, ApplicationDbContext context)
        {
            string ROOT = "";

            try
            {


                ROOT = AppDomain.CurrentDomain.BaseDirectory.Replace("bin", "").Replace("Debug", "").Replace("netcoreapp2.1", "") + "\\wwwroot";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }




            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

            }
            var poweruser = new ApplicationUser
            {
                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
                Email = Configuration.GetSection("AppSettings")["UserEmail"],
                FirstName = "Admin"
            };

            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    try
                    {
                        await UserManager.AddToRoleAsync(poweruser, "Admin");
                        await context.CUserDetails.AddAsync(new UserDetails { IdentityId = poweruser.Id });
                        await context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }


            //UPDATE CARRIER

            //string[] carrierCode = { "None", "ONEY", "CMA" };
            //string[] carrierName = { "None", "ONE Line", "CMA CGM" };
            //string[] carrierDescription = { "None", "One Line", "Cma Line" };
            //string[] carrierPath = { "None", "extract-icon/carrier-icon/one/logo.svg", "extract-icon/carrier-icon/cma/logo.svg" };
            //for (int i = 0; i < carrierCode.Count(); i++)
            //{

            //    try
            //    {


            //        var Carrier = new SysCarrier
            //        {
            //            CarrierCode = carrierCode[i],
            //            CarrierDescription = carrierDescription[i],
            //            CarrierName = carrierName[i],
            //            CarrierDirPath = carrierPath[i]
            //        };

            //        await context.SysCarriers.AddAsync(Carrier);
            //        await context.SaveChangesAsync();

            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }

            //}

            dynamic JSON_COLOR_INDEXED = JsonConvert.DeserializeObject(File.ReadAllText(ROOT + "/App_Data/RESOURCES/DOCUMENTS/convertcsv - indexed.json"));
            JArray JSON_ARRAY_COLOR_INDEXED = (JArray)JSON_COLOR_INDEXED;
            foreach (JToken JSON_TOKEN_COLOR_INDEXED in JSON_ARRAY_COLOR_INDEXED)
            {
                var sysColorSchemeIndexed = new SysColorSchemeIndexed
                {
                    HtmlColor = JSON_TOKEN_COLOR_INDEXED["C"].Value<string>().ToLowerInvariant(),
                    ColorName = JSON_TOKEN_COLOR_INDEXED["B"].Value<string>().ToLowerInvariant(),
                    Indexed = JSON_TOKEN_COLOR_INDEXED["A"].Value<int>(),
                    Prio = JSON_TOKEN_COLOR_INDEXED["D"].Value<char>() == 'Y' ? true : false
                };
                context.SysColorSchemeIndexeds.Add(sysColorSchemeIndexed);
                context.SaveChanges();
            }



            dynamic JSON_COLOR_INDEXED_DETAIL = JsonConvert.DeserializeObject(File.ReadAllText(ROOT + "/App_Data/RESOURCES/DOCUMENTS/convertcsv - indexed detail.json"));

            JArray JSON_ARRAY_COLOR_INDEXED_DETAIL = (JArray)JSON_COLOR_INDEXED_DETAIL;
            foreach (JToken JSON_TOKEN_COLOR_INDEXED_DETAIL in JSON_ARRAY_COLOR_INDEXED_DETAIL)
            {
                var sysColorSchemeIndexedDetail = new SysColorSchemeIndexedDetail
                {
                    DataType = JSON_TOKEN_COLOR_INDEXED_DETAIL["B"].Value<string>(),
                    SysCarrierRefId = JSON_TOKEN_COLOR_INDEXED_DETAIL["C"].Value<long>(),
                    SysColorRefId = JSON_TOKEN_COLOR_INDEXED_DETAIL["A"].Value<long>()
                };
                context.SysColorSchemeIndexedDetails.Add(sysColorSchemeIndexedDetail);
                context.SaveChanges();
            }

            dynamic JSON_COLOR_COLOR = JsonConvert.DeserializeObject(File.ReadAllText(ROOT + "/App_Data/RESOURCES/DOCUMENTS/convertcsv - color.json"));
            JArray JSON_ARRAY_COLOR_COLOR = (JArray)JSON_COLOR_COLOR;
            foreach (JToken JSON_TOKEN_COLOR_COLOR in JSON_ARRAY_COLOR_COLOR)
            {
                var sysColorSchemeColor = new SysColorSchemeColored
                {
                    HtmlColor = JSON_TOKEN_COLOR_COLOR["B"].Value<string>().ToLowerInvariant(),
                    ColorName = JSON_TOKEN_COLOR_COLOR["A"].Value<string>().ToLowerInvariant(),
                    IsKnown = JSON_TOKEN_COLOR_COLOR["C"].Value<char>() == 'Y' ? true : false,
                    Prio = JSON_TOKEN_COLOR_COLOR["D"].Value<char>() == 'Y' ? true : false
                };
                context.SysColorSchemeColoreds.Add(sysColorSchemeColor);
                context.SaveChanges();
            }

            dynamic JSON_COLOR_COLOR_DETAIL = JsonConvert.DeserializeObject(File.ReadAllText(ROOT + "/App_Data/RESOURCES/DOCUMENTS/convertcsv - color detail.json"));
            JArray JSON_ARRAY_COLOR_COLOR_DETAIL = (JArray)JSON_COLOR_COLOR_DETAIL;
            foreach (JToken JSON_TOKEN_COLOR_COLOR_DETAIL in JSON_ARRAY_COLOR_COLOR_DETAIL)
            {
                var sysColorSchemeColorDetail = new SysColorSchemeDetail
                {
                    DataType = JSON_TOKEN_COLOR_COLOR_DETAIL["B"].Value<string>(),
                    SysCarrierRefId = JSON_TOKEN_COLOR_COLOR_DETAIL["C"].Value<long>(),
                    SysColorRefId = JSON_TOKEN_COLOR_COLOR_DETAIL["A"].Value<long>()
                };
                context.SysColorSchemeDetails.Add(sysColorSchemeColorDetail);
                context.SaveChanges();
            }



            //dynamic JSON_UNLOC = JsonConvert.DeserializeObject(File.ReadAllText(ROOT + "/App_Data/RESOURCES/DOCUMENTS/UNLOC.json"));
            //JArray JSON_ARRAY_UNLOC = (JArray)JSON_UNLOC;
            //foreach(JToken JSON_TOKEN_UNLOC in JSON_ARRAY_UNLOC)
            //{
            //    var sysUnloc = new SysUnloc
            //    {
            //        Iso = JSON_TOKEN_UNLOC["ISO_Country"].Value<string>(),
            //        City = JSON_TOKEN_UNLOC["City"].Value<string>(),
            //        Country = JSON_TOKEN_UNLOC["Country"].Value<string>(),
            //        Full_code = JSON_TOKEN_UNLOC["Full_Code"].Value<string>(),
            //        State_code = JSON_TOKEN_UNLOC["State_Code"].Value<string>(),
            //        State = JSON_TOKEN_UNLOC["State"].Value<string>()
            //    };
            //    context.SysUnlocs.Add(sysUnloc);
            //    context.SaveChanges();
            //}

            //dynamic JSON_TRADELANE = JsonConvert.DeserializeObject(File.ReadAllText(ROOT + "/App_Data/RESOURCES/DOCUMENTS/unloc_trade.json"));
            //JArray JSON_ARRAY_TRADELANE = (JArray)JSON_TRADELANE;
            //List<SysUnlocTrade> sysUnlocTrades = new List<SysUnlocTrade>();
            //foreach(JToken JSON_TOKEN_TRADELANE in JSON_ARRAY_TRADELANE)
            //{
            //    long mid = JSON_TOKEN_TRADELANE["A"].Value<long>();
            //    string export = JSON_TOKEN_TRADELANE["C"].Value<string>() ?? "";
            //    string import = JSON_TOKEN_TRADELANE["D"].Value<string>() ?? "";


            //    var sysTrade = new SysUnlocTrade
            //    {
            //        UnlocRefId = mid,
            //        Export_code = export,
            //        Import_code = import
            //    };

            //    context.SysUnlocTrades.Add(sysTrade);
            //}
            ////context.SysUnlocTrades.AddRange(sysUnlocTrades);
            //context.SaveChanges();

            //dynamic JSON_GROUPCODE = JsonConvert.DeserializeObject(File.ReadAllText(ROOT + "/App_Data/RESOURCES/DOCUMENTS/group_code.json"));
            //JArray JSON_ARRAY_GROUPCODE = (JArray)JSON_GROUPCODE;
            //string admin = "4a3c3799-c1c3-4abf-968f-19c77dbd3f57";
            //foreach (JToken JSON_TOKEN_GROUPCODE in JSON_ARRAY_GROUPCODE)
            //{
            //    string name = JSON_TOKEN_GROUPCODE["FIELD2"].Value<string>();
            //    string key_code = JSON_TOKEN_GROUPCODE["FIELD2"].Value<string>().ToUpperInvariant().Replace(",", "").Replace(" ", "");
            //    string hashing = key_code.HashData();


            //    var findCity = await (from c in context.LibCities where c.Name_hash == hashing select c).FirstOrDefaultAsync();
            //    if (findCity == null)
            //    {
            //        var libCity = new LibCity
            //        {
            //            Name = name,
            //            Name_hash = key_code.HashData(),
            //            Created = DateTime.Now,
            //            CreatorRefId = admin,
            //            CarrierRefId = 2
            //        };
            //        context.LibCities.Add(libCity);

            //        var libCityDetail = new LibCityDetail
            //        {
            //            CityDetailRefId = libCity.Id,
            //            Approved = true,
            //            Created = DateTime.Now,
            //            CreatorRefId = admin,
            //            UnlocRefId = JSON_TOKEN_GROUPCODE["FIELD3"].Value<long>(),


            //        };
            //        context.LibCityDetails.Add(libCityDetail);
            //        context.SaveChanges();
            //    }
            //    else
            //    {
            //        long Mid = JSON_TOKEN_GROUPCODE["FIELD3"].Value<long>();
            //        var findDetails = await (from d in context.LibCityDetails where d.UnlocRefId == Mid && d.CityDetailRefId == findCity.Id select d).FirstOrDefaultAsync();
            //        if (findDetails == null)
            //        {
            //            var libCityDetail = new LibCityDetail
            //            {
            //                CityDetailRefId = findCity.Id,
            //                Approved = true,
            //                Created = DateTime.Now,
            //                CreatorRefId = admin,
            //                UnlocRefId = JSON_TOKEN_GROUPCODE["FIELD3"].Value<long>()
            //            };
            //            context.LibCityDetails.Add(libCityDetail);
            //            context.SaveChanges();
            //        }
            //    }
            //}

            //dynamic JSON_SURCHARGEKEY = JsonConvert.DeserializeObject(File.ReadAllText(ROOT + "/App_Data/RESOURCES/DOCUMENTS/surcharge_keywords.json"));
            //JArray JSON_ARRAY_SURCHARGEKEY = (JArray)JSON_SURCHARGEKEY;
            //foreach (JToken JSON_TOKEN_SURCHARGEKEY in JSON_ARRAY_SURCHARGEKEY)
            //{
            //    var surcharge = new SysSurchargeKeyword
            //    {
            //        Name = JSON_TOKEN_SURCHARGEKEY["A"].Value<string>(),
            //        Code = JSON_TOKEN_SURCHARGEKEY["B"].Value<string>()
            //    };
            //    context.SysSurchargeKeywords.Add(surcharge);
            //    context.SaveChanges();
            //}


        }
    }
}
