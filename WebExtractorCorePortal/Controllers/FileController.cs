using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ONEConverter.Builder;
using ONEConverter.Interfaces;
using WebExtractorCorePortal.Helpers;
using WebExtractorCorePortal.Interfaces;
using WebExtractorCorePortal.Models;

namespace WebExtractorCorePortal.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ClaimsPrincipal _caller;
        private readonly IHostingEnvironment _env;
        private readonly IFileRepo _fileRepo;
        private readonly IAmendmentRepo _amdRepo;
        private readonly ICarrierRepo _carrierRepo;
        private readonly IContractRepo _contractRepo;
        private readonly IWorkflowRepo _workflowRepo;
        private readonly IExtractorRepo _extractorRepo;

        public FileController(IHostingEnvironment env, IHttpContextAccessor httpContextAccessor, 
            IFileRepo fileRepo, IContractRepo contractRepo, ICarrierRepo carrierRepo,
            IAmendmentRepo amdRepo, IWorkflowRepo workflowRepo, IExtractorRepo extractorRepo)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _env = env;
            _amdRepo = amdRepo;
            _fileRepo = fileRepo;
            _carrierRepo = carrierRepo;
            _contractRepo = contractRepo;
            _workflowRepo = workflowRepo;
            _extractorRepo = extractorRepo;
            
        }
        [HttpPost("upload")]
        [DisableRequestSizeLimit]
        [RequestFormLimits(BufferBodyLengthLimit = Int32.MaxValue, ValueLengthLimit = Int32.MaxValue, 
            MultipartBodyLengthLimit = Int32.MaxValue, MultipartBoundaryLengthLimit = Int32.MaxValue, 
            MultipartHeadersLengthLimit = Int32.MaxValue)]
        public async Task< IActionResult > Upload(IFormFile file)
        {
            if (file == null || file.Length == 0) return new BadRequestResult();
            var temporaryFolderName = "App_Data/UPLOAD/TEMP";
            var ROOT = _env.WebRootPath;

            try
            {
                var userId = _caller.Claims.Single(c => c.Type == "id");
                var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                var fileExtension = Path.GetExtension(fileContent.FileName.ToString().Trim('"'));
                string source_code = await Generate.String.GUI();
                var source = new Source
                {
                    SourceName = source_code + fileExtension,
                    SourcePath = temporaryFolderName + "/" + source_code + fileExtension,
                    Size = 1,
                    SourceType = fileExtension,
                    Created = DateTime.Now,
                    CreatorRefId = userId.Value
                };
                await _fileRepo.AddFileAsync(source);
                var physicalPath = Path.Combine(ROOT, temporaryFolderName, source.SourceName);
                using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return new OkObjectResult(source);
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpPost("assign")]
        public async Task<IActionResult> Assign([FromBody] ContractAssign contractAssign)
        {
            if (String.IsNullOrWhiteSpace(contractAssign.FileName)) return new BadRequestResult();
            try
            {
                string ROOT = _env.WebRootPath;
                dynamic ss = null;
                var userId = _caller.Claims.Single(c => c.Type == "id");
                var source_query = await _fileRepo.FindSourceByFileNameAsync(contractAssign.FileName);
                if (source_query != null)
                {

                    string WORKFLOW_PATH = "";

                    try
                    {
                        //EXTRACTION LOGIC
                        XmlDocument doc = new XmlDocument();
                        
                        string workflowFolderName = "App_Data\\WORKFLOW";
                        WORKFLOW_PATH = Path.Combine(ROOT, workflowFolderName, source_query.SourceName);
                        Directory.CreateDirectory(WORKFLOW_PATH);
                        var physicalPath = Path.Combine(ROOT, source_query.SourcePath);
                        doc.Load(@physicalPath);
                        string XML_JSON = JsonConvert.SerializeXmlNode(doc);
                        if( contractAssign.Carrier == 2)
                        {
                            IOneBuild<List<dynamic>> commodity = new CommodityBuilder<List<dynamic>>();
                            IOneBuild<List<dynamic>> city = new CityBuilder<List<dynamic>>();
                            IOneBuild<List<dynamic>> rates = new RatesBuilder<List<dynamic>>();
                            IOneBuild<List<dynamic>> arbs = new ArbsBuilder<List<dynamic>>();
                            IOneBuild<List<dynamic>> groupratesnotes = new GroupRateBuilder<List<dynamic>>();
                            IOneBuild<List<dynamic>> grouparbsnotes = new GroupArbsBuilder<List<dynamic>>();
                            
                            await commodity.CompileDataTable(XML_JSON, contractAssign.ContractId, contractAssign.AmendmentId);
                            await city.CompileDataTable(XML_JSON, contractAssign.ContractId, contractAssign.AmendmentId);
                            await rates.CompileDataTable(XML_JSON, contractAssign.ContractId, contractAssign.AmendmentId);
                            await arbs.CompileDataTable(XML_JSON, contractAssign.ContractId, contractAssign.AmendmentId);
                            await groupratesnotes.CompileDataTable(XML_JSON, contractAssign.ContractId, contractAssign.AmendmentId);
                            await grouparbsnotes.CompileDataTable(XML_JSON, contractAssign.ContractId, contractAssign.AmendmentId);
                            
                            System.IO.File.WriteAllText(WORKFLOW_PATH + "/commodity.json", JsonConvert.SerializeObject(commodity));
                            System.IO.File.WriteAllText(WORKFLOW_PATH + "/city.json", JsonConvert.SerializeObject(city));
                            System.IO.File.WriteAllText(WORKFLOW_PATH + "/rates.json", JsonConvert.SerializeObject(rates));
                            System.IO.File.WriteAllText(WORKFLOW_PATH + "/arbs.json", JsonConvert.SerializeObject(arbs));
                            System.IO.File.WriteAllText(WORKFLOW_PATH + "/groupratesnotes.json", JsonConvert.SerializeObject(groupratesnotes));
                            System.IO.File.WriteAllText(WORKFLOW_PATH + "/grouparbsnotes.json", JsonConvert.SerializeObject(grouparbsnotes));
                            
                        }
                    }
                    catch(Exception e)
                    {
                        return new BadRequestObjectResult(e);
                    }

                    var fileGUID = Path.GetFileNameWithoutExtension(source_query.SourcePath);
                    var contract_query = await _contractRepo.FindContractByIdAsync(contractAssign.ContractId);
                    var carrier_query = await _carrierRepo.FindCarrierByIdAsync(contractAssign.Carrier);
                    long carrierId = carrier_query == null ? 1 : carrier_query.Id;
                    if (contract_query == null)
                    {

                        var contract = new Contract
                        {
                            ContractId = contractAssign.ContractId,
                            Created = DateTime.Now,
                            CreatorRefId = userId.Value,
                            CarrierRefId = carrierId
                        };
                        await _contractRepo.AddContractAsync(contract);
                        var amendment = new Amendment
                        {
                            HashId = fileGUID,
                            SourceId = source_query.Id,
                            AmendmentId = contractAssign.AmendmentId,
                            WorkflowPath = WORKFLOW_PATH,
                            AmendmentType = contractAssign.AmendmentType,
                            ContractEff = contractAssign.EffectiveDate,
                            ContractExp = contractAssign.ExpirationDate,
                            ContractRefId = contract.Id,
                            CreatedDate = DateTime.Now
                        };
                        await _amdRepo.AddAmendmentAsync(amendment);
                        var startflow = new StartedWorkflow
                        {
                            Date = DateTime.Now,
                            AmendmendId = amendment.Id,
                            CreatorRefId = userId.Value,
                            Activate = false
                        };
                        await _workflowRepo.AddStartWorkflow(startflow);
                        await _extractorRepo.CreateLoadLogs(amendment.Id);
                    }
                    else
                    {
                        var amendment = new Amendment
                        {
                            HashId = fileGUID,
                            SourceId = source_query.Id,
                            AmendmentId = contractAssign.AmendmentId,
                            WorkflowPath = WORKFLOW_PATH,
                            AmendmentType = contractAssign.AmendmentType,
                            ContractEff = contractAssign.EffectiveDate,
                            ContractExp = contractAssign.ExpirationDate,
                            ContractRefId = contract_query.Id,
                            CreatedDate = DateTime.Now
                        };
                        await _amdRepo.AddAmendmentAsync(amendment);

                        var startflow = new StartedWorkflow
                        {
                            Date = DateTime.Now,
                            AmendmendId = amendment.Id,
                            CreatorRefId = userId.Value
                        };

                        await _workflowRepo.AddStartWorkflow(startflow);
                        await _extractorRepo.CreateLoadLogs(amendment.Id);
                    }
                    return Content("Contract Assigned");
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                var fileList = await _contractRepo.GetAllContractAssign();
                if( fileList != null)
                {
                    return new OkObjectResult(fileList);
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {

                return new BadRequestObjectResult("Internal Server Error. Please Contact Administrator.");
            }
        }

    }
}