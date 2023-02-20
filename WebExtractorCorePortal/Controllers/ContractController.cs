using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;
using WebExtractorCorePortal.Extentions;
using System.Linq;
using WebExtractorCorePortal.Helpers;

namespace WebExtractorCorePortal.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
        private readonly IContractRepo _contractRepo;
        private readonly IAmendmentRepo _amendmentRepo;
        private readonly ICarrierRepo _carrierRepo;
        //TEST MODEL
        private readonly IExtractorRepo _extractorRepo; 
        public ContractController(IHostingEnvironment env, 
            IContractRepo contractRepo, IAmendmentRepo amendmentRepo, 
            IExtractorRepo extractorRepo, ICarrierRepo carrierRepo )
        {
            _env = env;
            _contractRepo = contractRepo;
            _amendmentRepo = amendmentRepo;
            _extractorRepo = extractorRepo;
            _carrierRepo = carrierRepo;
        }
        [HttpGet("commodity/{hashid}")]
        public async Task<IActionResult> LoadCommodityJson(string hashid)
        {
            if (String.IsNullOrWhiteSpace(hashid)) return new BadRequestResult();
            try
            {
                var car = await _carrierRepo.FindCarrierByAmdHashId(hashid);
                if (car != null)
                {
                    var amd = await _amendmentRepo.FindHashId(hashid);
                    if (amd != null)
                    {
                        ContractIssues contractIssues = new ContractIssues();
                        int issuesfound = 0;
                        dynamic jsonObject = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(amd.WorkflowPath + "/commodity.json"));
                        foreach (var item in jsonObject["Details"])
                        {
                            var comm = new CommodityDetails
                            {
                                Id = item[6],
                                HashValue = item[0],
                                MainValue = item[1],
                                Code = item[1],
                                Description = item[2],
                                Bdescription = item[2],
                                Exclusions = item[3],
                                Nac = item[4]
                            };
                            RateCommodity libcommodity = await _extractorRepo.FindLibCommodityByHashValue(item[0], car.Id);
                            if( libcommodity != null)
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
                                    Exclusion = libcommodity.Exclusion,
                                    AmendmentRefId = amd.Id
                                };
                                await _extractorRepo.AddCommodityAsync(commodity);
                            }
                            else
                            {
                                //Capture error message
                                var commodity = new RateCommodity
                                {
                                    GenId = item[6],
                                    Main_value = item[1],
                                    Main_value_hash = item[0],
                                    Code = item[1],
                                    Description = item[2],
                                    Brief_description = item[2],
                                    Exclusion = item[3],
                                    Nac = item[4],
                                    Confirmation = true,
                                    AmendmentRefId = amd.Id
                                };
                                await _extractorRepo.AddCommodityAsync(commodity);
                                issuesfound++;
                            }
                        }

                        contractIssues.ErrorFound = (issuesfound > 0);
                        contractIssues.TotalErrorFound = issuesfound;
                        return new OkObjectResult(contractIssues);
                    }
                    else
                    {
                        return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
                    }
                }
                else
                {
                    return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
                }
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpGet("city/{hashid}")]
        public async Task<IActionResult> LoadCityJson(string hashid)
        {
            if (String.IsNullOrWhiteSpace(hashid)) return new BadRequestResult();
            try
            {
                var car = await _carrierRepo.FindCarrierByAmdHashId(hashid);
                if(car != null)
                {
                    var amd = await _amendmentRepo.FindHashId(hashid);
                    if (amd != null)
                    {
                        ContractIssues contractIssues = new ContractIssues();
                        int issuesfound = 0;
                        dynamic jsonObject = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(amd.WorkflowPath + "/city.json"));
                        foreach (var item in jsonObject["Details"])
                        {
                            LibCity unlocs = await _extractorRepo.FindLibCityByHashName(item[0], car.Id);
                            if (unlocs != null)
                            {
                                var city = new RateCity
                                {
                                    GenId = item[2],
                                    HashName = unlocs.Name_hash,
                                    Name = unlocs.Name,
                                    AmendmentRefId = amd.Id,
                                    CityRefId = unlocs.Id,
                               
                                };
                                await _extractorRepo.AddCityAsync(city);
                            }
                            else
                            {
                                var city = new RateCity
                                {
                                    GenId = item[2],
                                    HashName = item[0],
                                    Name = item[0],
                                    AmendmentRefId = amd.Id,
                                    Confirmation = true
                                };
                                await _extractorRepo.AddCityAsync(city);
                                issuesfound++;
                            }
                            contractIssues.ErrorFound = (issuesfound > 0);
                            contractIssues.TotalErrorFound = issuesfound;
                        }
                        return new OkObjectResult(contractIssues);
                    }
                    else
                    {
                        return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
                    }
                }
                else
                {
                    return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
                }
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
          
        }
        [HttpGet("arbsnotes/{hashid}")]
        public async Task<IActionResult> LoadArbsNotesJson(string hashid)
        {
            if (String.IsNullOrWhiteSpace(hashid)) return new BadRequestResult();
            try
            {
                var amd = await _amendmentRepo.FindHashId(hashid);
                if(amd != null)
                {
                    dynamic jsonObject = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(amd.WorkflowPath + "/grouparbsnotes.json"));
                    foreach(var item in jsonObject["Details"])
                    {
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(item[0])))
                        {
                            string rnotesValue = Convert.ToString(item[0]);
                            string hashvalue = rnotesValue.HashData();
                            foreach(var n in item[3])
                            {
                                if( Convert.ToString(item[3]) == "Origin")
                                {
                                    await _extractorRepo.InsertSpecificNotes(0, Convert.ToInt32(item[1]), rnotesValue, Convert.ToString(n), RateNoteType.Specific, TabType.OARBS);
                                }
                                else if( Convert.ToString(item[3]) == "Destination")
                                {
                                    await _extractorRepo.InsertSpecificNotes(0, Convert.ToInt32(item[1]), rnotesValue, Convert.ToString(n), RateNoteType.Specific, TabType.DARBS);
                                }
                            }
                        }
                    }
                    return new OkObjectResult("");
                }
                else
                {
                    return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
                }
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
            
        }
        [HttpGet("notes/{hashid}")]
        public async Task<IActionResult> LoadNotesJson(string hashid)
        {
            if (String.IsNullOrWhiteSpace(hashid)) return new BadRequestResult();
            var amd = await _amendmentRepo.FindHashId(hashid);
            if(amd != null)
            {
                dynamic jsonObject = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(amd.WorkflowPath + "/groupratesnotes.json"));
                foreach(var item in jsonObject["Details"])
                {
                    try
                    {
                        List<LineNotes> lineNotes = new List<LineNotes>();
                        foreach (var subline in item[3])
                        {
                            if (!String.IsNullOrWhiteSpace(Convert.ToString(subline[0])))
                            {
                                string rnotesValue = Convert.ToString(subline[0]);
                                string hashvalue = rnotesValue.HashData();
                                var matchNotes = lineNotes.Where(n => n.HashValue == hashvalue ).FirstOrDefault();
                                //if( matchNotes == null)
                                //{
                                    foreach( var n in subline[2])
                                    {
                                       await _extractorRepo.InsertSpecificNotes(Convert.ToInt32(item[1]), Convert.ToInt32(subline[1]), rnotesValue, Convert.ToString(n) , RateNoteType.Specific, TabType.RATES);
                                    }
                                //}
                            }
                        }
                        string notesValue = Convert.ToString(item[0]);
                        await _extractorRepo.InsertGeneralNotes(Convert.ToInt32(item[1]), notesValue, RateNoteType.General, TabType.RATES );
                    }
                    catch (Exception e)
                    {
                        return new BadRequestObjectResult(e);
                    }
                }
                return new OkObjectResult("");

            }
            else
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpGet("rates/{hashid}")]
        public async Task<IActionResult> LoadRatesJson(string hashid)
        {
            if (String.IsNullOrWhiteSpace(hashid)) return new BadRequestResult();
            try
            {
                var amd = await _amendmentRepo.FindHashId(hashid);
                if(amd != null)
                {
                    dynamic jsonObject = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(amd.WorkflowPath + "/rates.json"));
                    foreach(var item in jsonObject["Details"])
                    {


                        RateScope rateScope = new RateScope
                        {
                            TradeName = item[20],
                            IsMarked = false
                        };

                        await _extractorRepo.InsertScope(rateScope);


                        RateNote rateNote = new RateNote
                        {
                            ImportService = item[11],
                            ExportService = item[12],
                            ImportMode = "",
                            ExportMode = "",
                            AnalystNotes = "",
                            ContractNotes = "",
                            DataEntryNotes = "",
                            RateType = "FCL"
                        };

                        await _extractorRepo.InsertRateNote(rateNote);


                        Rate rate = new Rate
                        {
                            EffectiveDate = item[0],
                            ExpirationDate = item[1],
                            TabType = TabType.RATES,
                            ArbsConst = "O-D",
                            RateNoteRefId = rateNote.Id,
                            RateTrade = rateScope.Id,
                            AmendmentRefId = amd.Id,
                            OriginValue = ( Convert.ToString(item[3]) != null ? Convert.ToString(item[3]).HashData() : item[3]  ),
                            OriginViaValue = ( Convert.ToString(item[4]) != null ? Convert.ToString(item[4]).HashData(): item[4] ),
                            DestinationValue = (Convert.ToString(item[5]) != null ? Convert.ToString(item[5]).HashData(): item[5] ),
                            DestinationViaValue = ( Convert.ToString(item[6]) != null ? Convert.ToString(item[6]).HashData(): item[6] ),
                            CommodityHash = ( Convert.ToString(item[2]) != null ? Convert.ToString(item[2]).HashData(): item[2] ),
                            GroupId = Convert.ToInt32(item[22]),
                            TableId = Convert.ToInt32(item[23]),
                            GenId = item[24],
                            MarkedType = item[21]
                        };

                        await _extractorRepo.InsertRate(rate);

                        
                        RateBR rateBR = new RateBR
                        {

                        };



                    }
                    return new OkObjectResult("");
                }
                else
                {
                    return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
                }
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        //[HttpGet("rates/{hashid}")]
        //public async Task<IActionResult> GetRates(string hashid)
        //{

        //    try
        //    {
        //        if( String.IsNullOrWhiteSpace(hashid) )
        //        {
        //            return new BadRequestResult();
        //        }
        //        var amd = await _amendmentRepo.FindHashId(hashid);
        //        if( amd != null)
        //        {
        //            dynamic jsonObject = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(amd.WorkflowPath + "/rates.json"));
        //            List<RatesDetails> ratesDetails = new List<RatesDetails>();
        //            foreach(var item in jsonObject["Details"])
        //            {
        //                /* 
        //                 *
        //                 * DATABASE JSON DATA
        //                 *
        //                 */
                        

        //                var rates = new RatesDetails
        //                {
        //                    Id = item[24],
        //                    Commodity = item[2],
        //                    Origin = item[3],
        //                    Destination = item[5],
        //                    Service = item[11] + "/" + item[12],
        //                    Scope = item[20]
        //                };
        //                ratesDetails.Add(rates);
        //            }
        //            return new OkObjectResult(ratesDetails);
        //        }
        //        else
        //        {
        //            return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
        //        }
        //    }
        //    catch
        //    {
        //        return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
        //    }
        //}
        [HttpGet("notes/{id}/{groupid}")]
        public async Task<IActionResult> GetNotes(string id, long groupid)
        {

            try
            {
                if (String.IsNullOrWhiteSpace(id) || groupid == 0)
                {
                    return new BadRequestResult();
                }
                var getnotes = await _extractorRepo.GetNotes(id, groupid);
                var getGeneral = getnotes.AsEnumerable().Where(f => f.RateNoteType == RateNoteType.General).FirstOrDefault();
                var getSpecific = getnotes.AsEnumerable().Where(f => f.RateNoteType == RateNoteType.Specific).ToList();
                return new OkObjectResult(JsonConvert.DeserializeObject( JsonConvert.SerializeObject( new { general = getGeneral, specific = getSpecific  } )) );

            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpGet("notesvalue/{hash}")]
        public async Task<IActionResult> GetNotesValue(string hash)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(hash)) return new BadRequestResult();
                var hashValue = await _extractorRepo.GetNotesValue(hash);
                return new OkObjectResult(hashValue);

            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpGet("templatevalues")]
        public async Task<IActionResult> GetTemplateValues()
        {
            try
            {
                var templatevalues = JsonConvert.SerializeObject(new { RConstruct = Constants.Construct(), RService = Constants.RateService(), AService = Constants.ArbService(), RMode = Constants.RateMode(), AMode = Constants.ArbsMode(), Container = Constants.ContainerType(), Currency = Constants.Currency(), Basis = Constants.Basis()  });
                return new OkObjectResult(JsonConvert.DeserializeObject(templatevalues));
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
    }
}