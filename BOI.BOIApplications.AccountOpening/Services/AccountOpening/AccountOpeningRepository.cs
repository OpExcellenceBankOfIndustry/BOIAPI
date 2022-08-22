using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.AccountDetailsOfOwner;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.CompanyInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DetailsOfNextOfKin;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformCoop;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformInd;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RegulatoryInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RelatedPartyInform;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.SoleProprietorship;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Enums;
using BOI.BOIApplications.Persistence;
using Microsoft.AspNetCore.Http;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using BOI.BOIApplications.Application.Features.API.AccountOpening.Command.DocumentTable;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace BOI.BOIApplications.AccountOpening.Services.AccountOpening
{
    public class AccountOpeningRepository : IAccountOpeningRepository
    {
        private readonly ILogger<AccountOpeningRepository> _logger;
        private readonly IMapper _mapper;
        private readonly BOIDbContext _dbc;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostEnv;
        private const string ATTACHEMENT_FOLDER = "ATTATCHEMENT_UPLOAD_FOLDER";
        public AccountOpeningRepository(ILogger<AccountOpeningRepository> logger,IHostingEnvironment hostEnv, IMapper mapper, IHttpContextAccessor contextAccessor, IConfiguration configuration, BOIDbContext dbc)
        {
            _logger = logger;
            _mapper = mapper;
            _dbc = dbc;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _hostEnv = hostEnv;
        }
        
        public async Task<CompanyInformCommandResponse> AddCompanyInform(CompanyInformViewModel companyInform)
        {
            try
            {
                if (companyInform != null)
                {
                    _logger.LogInformation("<====Start Company Information Process.====> ");
                    var sRequest = _mapper.Map<AOCompanyInformation>(companyInform);

                    sRequest.RefNumber = Guid.NewGuid().ToString();
                    var filePath = sRequest.RefNumber + "_" + companyInform.CompanyName.Replace(" ", "_");
                    sRequest.FilePath = filePath;
                    if (companyInform.ProofOfCompanyAddress != null)
                    {
                        var resp = await SaveDocuments(companyInform.ProofOfCompanyAddress, sRequest.CompanyName, filePath, sRequest.UserEmail, "Company Information", "Proof Of Company Address");
                    }
                    var matches = await _dbc.AOCompanyInformations.AddAsync(sRequest);
                    await _dbc.SaveChangesAsync();
                    _logger.LogInformation("<====End Company Information Process.====> ");
                    return new CompanyInformCommandResponse
                    {
                        RefNumber = sRequest.RefNumber,
                        Message = "Company Information saved successfully",
                        Success = true,
                    };

                }
                else
                {
                    return new CompanyInformCommandResponse
                    {
                        RefNumber = "",
                        Message = "Company Information not saved successfully",
                        Success = false,
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while processing Company Information");
                throw;
            }         

        }
        public async Task<string> AddRegulatoryInform(RegulatoryInformViewModel regulatoryInform)
        {
            try
            {
               
                _logger.LogInformation("<====Start Regulatory Information Process.====> ");
                var status = "";
                if (regulatoryInform != null)
                {
                    var sRequest = _mapper.Map<AORegulatoryInformation>(regulatoryInform);
                    var compInfo = _dbc.AOCompanyInformations.Where(x => x.RefNumber == regulatoryInform.RefNumber).FirstOrDefault();
                    if (compInfo != null)
                    {
                        if (regulatoryInform.CertificateOfIncorporationRegistration != null)
                        {
                            var resp = await SaveDocuments(regulatoryInform.CertificateOfIncorporationRegistration, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Regulatory Information", "Certificate Of Incorporation Registration");
                        }
                        if (regulatoryInform.FormCO2AllotmentOfShares != null)
                        {
                            var resp = await SaveDocuments(regulatoryInform.FormCO2AllotmentOfShares, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Regulatory Information", "Form CO2 Allotment Of Shares");
                        }
                        if (regulatoryInform.FormCO7ParticularsOfDirectors != null)
                        {
                            var resp = await SaveDocuments(regulatoryInform.FormCO7ParticularsOfDirectors, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Regulatory Information", "Form CO7 Particulars Of Directors");
                        }
                        if (regulatoryInform.Memart != null)
                        {
                            var resp = await SaveDocuments(regulatoryInform.Memart, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Regulatory Information", "MEMART");
                        }
                        if (regulatoryInform.BoardResolution != null)
                        {
                            var resp = await SaveDocuments(regulatoryInform.BoardResolution, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Regulatory Information", "Board Resolution");
                        }
                    }

                    var matches = await _dbc.AORegulatoryInformation.AddAsync(sRequest);
                    await _dbc.SaveChangesAsync();
                    _logger.LogInformation("End Regulatory Information Process. ");
                    status = "Regulatory Information saved successfully";
                }
                else
                {
                    status = "Regulatory Information not saved successfully";
                }

                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while processing Regulatory Information");
                throw;
            }

        }
        public async Task<string> AddRelatedPartyInform(RelatedPartyInformViewModel relatedPartyInform)
        {
            try
            {
                var status = "";
                _logger.LogInformation("<====Start Related Party Information Process.====> ");
                if (relatedPartyInform != null)
                {
                    var sRequest = _mapper.Map<AORelatedPartyInformation>(relatedPartyInform);
                    var matches = await _dbc.AORelatedPartyInformation.AddAsync(sRequest);
                    await _dbc.SaveChangesAsync();
                    _logger.LogInformation("<====End Related Party Information Process.====> ");
                    status = "Related Party Information saved successfully";
                }
                else
                {
                    status = "Related Party Information not saved successfully";
                }

                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while processing Related Party Information");
                throw;
            }
        }
        public async Task<string> AddAccountDetailsOfOwner(List<AccountDetailsOfOwnerViewModel> accountDetailsOfOwner)
        {
            try
            {
                var status = "";
                _logger.LogInformation("<====Start Account Details Of Owner Process.====> ");
                if (accountDetailsOfOwner != null)
                {
                    var sRequest = accountDetailsOfOwner.Select(x => _mapper.Map<AOAccountDetailsOfOwner>(x)).ToList();
                    await _dbc.BulkInsertAsync(sRequest);
                    await _dbc.SaveChangesAsync();
                    _logger.LogInformation("<====End Account Details Of Owner Process.====> ");
                    status = "Account Details Of Owner saved successfully";
                }
                else
                {
                    status = "Account Details Of Owner not saved successfully";
                }

                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while processing End Account Details Of Owner");
                throw;
            }

        }
        public async Task<string> AddDetailsOfNextOfKin(List<DetailsOfNextOfKinViewModel> detailsOfNextOfKin)
        {
            try
            {
                var status = "";
                _logger.LogInformation("<====Start Details Of Next Of Kin Process.====> ");
                if (detailsOfNextOfKin != null)
                {
                    var sRequest = detailsOfNextOfKin.Select(x => _mapper.Map<AODetailsOfNextOfKin>(x)).ToList();
                    await _dbc.BulkInsertAsync(sRequest);
                    await _dbc.SaveChangesAsync();
                    _logger.LogInformation("<====End Details Of Next Of Kin Process.====> ");
                    status = "Details Of Next Of Kin saved successfully";
                }
                else
                {
                    status = "Details Of Next Of Kin not saved successfully";
                }
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while processing Details Of Next Of Kin");
                throw;
            }
        }
        public async Task<string> AddSoleProprietorship(SoleProprietorshipViewModel soleProprietorship)
        {
            try
            {
                var status = "";
                _logger.LogInformation("<====Start Sole Proprietorship Information Process.====> ");
                if (soleProprietorship != null)
                {
                    var sRequest = _mapper.Map<AOSoleProprietorship>(soleProprietorship);
                    var compInfo = _dbc.AOCompanyInformations.Where(x => x.RefNumber == soleProprietorship.RefNumber).FirstOrDefault();

                    if (compInfo != null)
                    {
                        if (soleProprietorship.ProofOfAddress != null)
                        {
                            var resp = await SaveDocuments(soleProprietorship.ProofOfAddress, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Sole Proprietorship Information", "Proof Of Address");
                        }
                        if (soleProprietorship.IdentificationFile != null)
                        {
                            var resp = await SaveDocuments(soleProprietorship.IdentificationFile, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Sole Proprietorship Information", "Identification- File");
                        }
                        if (soleProprietorship.PassportPhotograph != null)
                        {
                            var resp = await SaveDocuments(soleProprietorship.PassportPhotograph, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Sole Proprietorship Information", "Passport Photograph");
                        }
                        if (soleProprietorship.UploadCV != null)
                        {
                            var resp = await SaveDocuments(soleProprietorship.UploadCV, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Sole Proprietorship Information", "Upload CV");
                        }
                    }
                    var matches = await _dbc.AOSoleProprietorship.AddAsync(sRequest);
                    await _dbc.SaveChangesAsync();
                    _logger.LogInformation("<====End Sole Proprietorship Information Process.====> ");
                    status = "Sole Proprietorship saved successfully";
                }
                else
                {
                    status = "Sole Proprietorship not saved successfully";
                }

                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while processing Sole Proprietorship Information");
                throw;
            }

        }
        public async Task<string> AddOwnershipInformCoop(OwnershipInformCoopViewModel ownershipInformCoop)
        {
            try
            {
                _logger.LogInformation("Start Processing Cooperate Ownership Information ");
                Log.Information("<====Start Processing Cooperate Ownership Information====>");
                var status = "";
                if (ownershipInformCoop != null)
                {

                    var sRequest = _mapper.Map<AOOwnershipInformationCooperate>(ownershipInformCoop);
                    var compInfo = _dbc.AOCompanyInformations.Where(x => x.RefNumber == ownershipInformCoop.RefNumber).FirstOrDefault();
                    if (compInfo != null)
                    {
                        if (ownershipInformCoop.CertificateOfIncorporationRegistration != null)
                        {
                            var resp = await SaveDocuments(ownershipInformCoop.CertificateOfIncorporationRegistration, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Ownership Information Cooperate", "Certificate Of Incorporation Registration");
                        }
                    }

                    var matches = await _dbc.AOOwnershipInformationCooperate.AddAsync(sRequest);

                    await _dbc.SaveChangesAsync();
                    _logger.LogInformation("End Cooperate Ownership Information Process. ");
                    Log.Information("<====End Cooperate Ownership Information Process====>");
                    status = "Ownership Information Cooperate saved successfully";
                }
                else
                {
                    status = "Ownership Information Cooperate not saved successfully";
                }

                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while processing Cooperate Ownership Information");
                Log.Error(ex, "<===Error Occured while processing Cooperate Ownership Information====>");
                throw;
            }

        }
        public async Task<string> AddOwnershipInformInd(OwnershipInformIndViewModel ownershipInformInd)
        {
            try
            {
                _logger.LogInformation("Start Processing Individual Ownership Information ");
                var status = "";
                if (ownershipInformInd != null)
                {
                    var sRequest = _mapper.Map<AOOwnershipInformationIndividual>(ownershipInformInd);
                    var compInfo = _dbc.AOCompanyInformations.Where(x => x.RefNumber == ownershipInformInd.RefNumber).FirstOrDefault();

                    if (compInfo != null)
                    {
                        if (sRequest.ProofOfAddress != null)
                        {
                            var resp = await SaveDocuments(ownershipInformInd.ProofOfAddress, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Ownership Information Individual", "Proof Of Address");
                        }
                        if (ownershipInformInd.IdentificationFile != null)
                        {
                            var resp = await SaveDocuments(ownershipInformInd.IdentificationFile, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Ownership Information Individual", "Identification- File");
                        }
                        if (ownershipInformInd.PassportPhotograph != null)
                        {
                            var resp = await SaveDocuments(ownershipInformInd.PassportPhotograph, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Ownership Information Individual", "Passport Photograph");
                        }
                        if (ownershipInformInd.UploadCV != null)
                        {
                            var resp = await SaveDocuments(ownershipInformInd.UploadCV, compInfo.CompanyName, compInfo.FilePath, sRequest.UserEmail, "Ownership Information Individual", "Upload CV");
                        }
                    }
                    var matches = await _dbc.AOOwnershipInformationIndividual.AddAsync(sRequest);
                    await _dbc.SaveChangesAsync();
                    _logger.LogInformation("End Individual Ownership Information Process.");
                    status = "Ownership Information Individual saved successfully";
                }
                else
                {
                    status = "Ownership Information Individual not saved successfully";
                }

                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while processing Individual Ownership Information");
                throw;
            }

        }
        public async Task<DocumentTableResponse> SaveDocuments([FromForm]IFormFile file,string fileDesc, string filePath, string userEmail , string fileCategory, string fileSubject)
        {
            try
            {
                if (file != null)
                {
                    //UPLOAD FILE PART
                    var WebRoot = _hostEnv.WebRootPath;
                    var baseFolderPath = Path.Combine(WebRoot, ATTACHEMENT_FOLDER);
                    var baseURL = _configuration["BaseSettings:BaseURL"];
                    string[] allowExt = new string[12] { ".jpg", ".jpeg", ".doc", ".pdf", ".png", ".gif", ".docx", ".xlsx", ".csv", ".xls", ".pptx", ".pptm" };
                    var allPath = new List<string>();
                    string extension = Path.GetExtension(file.FileName);

                    if (!allowExt.Contains(extension))
                    {
                        return new DocumentTableResponse
                        {
                            Status = false,
                            FileMessage = "Wrong file extension",
                        };
                    }
                    else
                    {
                        var fileName = file.FileName.Replace(" ", "_");
                        var attachementPath = baseFolderPath + "/" + filePath;
                        DirectoryInfo dir = new DirectoryInfo(attachementPath);
                        if (!dir.Exists) dir.Create();
                        var url = baseURL + "ATTATCHEMENT_UPLOAD_FOLDER/" + filePath + "/" + fileName;
                        var fileLocation = baseFolderPath + "/" + filePath + "/" + fileName;

                        using (var stream = new FileStream(fileLocation, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var attachment = new AODocumentTable()
                        {
                            FileSubject = fileSubject,
                            FileCategory = fileCategory,
                            FileDesc = fileDesc,
                            FileName = fileName,
                            FileExt = extension,
                            FilePath = fileLocation,
                            FileUploadedDate = DateTime.Now,
                            UploadedBy = userEmail,
                            UploadStatus = UploadStatus.Successed,
                            FileNameUrl = url,
                            Isdeleted = false
                        };
                        _dbc.AODocumentTable.Add(attachment);
                        await _dbc.SaveChangesAsync();
                        return new DocumentTableResponse
                        {
                            Status = true,
                            FileMessage = "Document was saved successfully",
                            FileLocation = fileLocation,
                        };
                    }
                }
                return new DocumentTableResponse
                {
                    Status = false,
                    FileMessage = "Document was not saved successfully",
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured while saving a document");
                throw;
            }
        }
    }
}
