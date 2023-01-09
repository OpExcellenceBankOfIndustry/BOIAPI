using AutoMapper;
using BOI.BOIApplications.Application.Contracts.ThirdPartyAPI;
using BOI.BOIApplications.Domain.DTO;
using BOI.BOIApplications.Domain.Entities;
using BOI.BOIApplications.Domain.Entities.MicroCreditModels;
using BOI.BOIApplications.Domain.Entities.ThirdPartyAPI;
using BOI.BOIApplications.Domain.Enums;
using BOI.BOIApplications.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.AccountOpening.Services.ThirdPartyAPI
{
    public class ThirdPartyAPIRepository : IThirdPartyAPIRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly BOI3DbContext _dbContext;
        private readonly ThirdPartyAPISettings _thirdPartySettings;

        private readonly IRestClient _client;

        public ThirdPartyAPIRepository(IMapper mapper, IConfiguration configuration, BOI3DbContext dbContext, IRestClient client, IOptions<ThirdPartyAPISettings> options)
        {
            _mapper = mapper;
            _configuration = configuration;
            _dbContext = dbContext;
            _client = client;
            _thirdPartySettings = options.Value;
        }

        public async Task<List<BankL>> FetchBankList()
        {
            try
            {
                var resp = new ThirdPartyAPIResponse<List<BankListResponse>>();
                //var allBanks2 = await _dbContext.BankList.OrderBy(e => e.name).ToListAsync();
                var allBanks = await _dbContext.BankList.Select(x => new BankL() { id = x.code, name = x.name.Trim() }).OrderBy(e => e.name).ToListAsync();


                if (allBanks.Any())
                {
                    return allBanks;
                }
                else
                {
                    var bankList = _thirdPartySettings.Endpoints["BankList"];
                    _client.BaseUrl = new Uri(_thirdPartySettings.BaseURL);
                    _client.AddDefaultHeader("token", _thirdPartySettings.token);

                    RestRequest request = new RestRequest(bankList, Method.GET);
                    request.RequestFormat = DataFormat.Json;

                    IRestResponse response = await _client.ExecuteAsync(request);
                    if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                    {
                       resp = JsonConvert.DeserializeObject<ThirdPartyAPIResponse<List<BankListResponse>>>(response.Content);
                        

                        //var mapResp = resp.Data.Select(x => _mapper.Map<BankList>(x));
                        var mapResp = resp.Data.Select(x => new BankList
                        {
                            bankId = x.Id,
                            code = x.code,
                            name = x.name,
                            slug = x.slug,
                            type = x.type,
                            active = x.active,
                            country = x.country,
                            currency = x.currency
                        });

                        _dbContext.BankList.AddRange(mapResp);
                       
                        await _dbContext.SaveChangesAsync();
                        var allBanks2 = await _dbContext.BankList.Select(x => new BankL() { id = x.code, name = x.name.Trim() }).OrderBy(e => e.name).ToListAsync();

                        return allBanks2;
                    }
                    else
                    {

                    }
                }
                        return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<BankAccountVerificationResponse> BankAccountVerification(BankAccountVerificationRequestView reqt)
        {
            try
            {
                if ((!string.IsNullOrWhiteSpace(reqt.accountNumber)) && (!string.IsNullOrWhiteSpace(reqt.bankCode)))
                {                    
                        var req = new BankAccountVerificationRequest();
                        req.accountNumber = reqt.accountNumber;
                        req.bankCode = reqt.bankCode;
                        req.isSubjectConsent = true;
                        var verification = _thirdPartySettings.Endpoints["AccountVerification"];


                        var resp = new BankAccountVerificationResponse();
                        _client.BaseUrl = new Uri(_thirdPartySettings.BaseURL);
                        _client.AddDefaultHeader("token", _thirdPartySettings.token);

                        RestRequest request = new RestRequest(verification, Method.POST);
                        request.RequestFormat = DataFormat.Json;

                        request.AddJsonBody(req);                    

                        IRestResponse response = await _client.ExecuteAsync(request);
                        if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                        {
                            resp = JsonConvert.DeserializeObject<BankAccountVerificationResponse>(response.Content);                           

                            return resp;
                        }
                        else
                        {
                            return null;
                        }   
                }               
                        return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PersonalIdentificationResponse> FetchPersonalIdentification(BonitaPersonalIdentificationRequest request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request.idNumber) && !string.IsNullOrEmpty(request.Type))
                {
                    //Type value must be within (BVN,NIN,PVC,INP,NDL)
                    if (request.Type == "BVN") 
                    {                        
                        var resp = _mapper.Map<PersonalIdentificationRequest>(request);
                        var action = await FetchCustomerBVN(resp);
                        return action;
                    }
                    else if (request.Type == "NIN") 
                    {
                        var resp = _mapper.Map<PersonalIdentificationRequest>(request);
                        var action = await FetchCustomerNIN(resp);
                        return action;
                    }
                    else if (request.Type == "PVC") 
                    {
                        var resp = _mapper.Map<PersonalIdentificationRequest>(request);
                        var action = await FetchCustomerPVC(resp);
                        
                        return action;
                    }
                    else if (request.Type == "INP") 
                    {
                        var resp = _mapper.Map<PersonalIdentificationRequest>(request);
                        var action = await FetchCustomerINP(resp);
                        return action;
                    }
                    else if (request.Type == "NDL") 
                    {
                        var resp = _mapper.Map<PersonalIdentificationRequest>(request);
                        var action = await FetchCustomerNDL(resp);
                        return action;
                    }
                    else
                    {
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "Type value must be within (BVN,NIN,PVC,INP,NDL). Kindly review and enter correct details.",
                        };

                    }
                    var bvnExist = _dbContext.CustomerBVNResponses.Where(x => x.idNumber == request.idNumber).FirstOrDefault();
                    if (bvnExist != null)
                    {
                        var nameFromYouVerify = bvnExist.firstName + " " + bvnExist.middleName + " " + bvnExist.lastName;
                        var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                        var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                        var dateMatch = CompareDateOfBirth(request.dateOfBirth, bvnExist.dateOfBirth);
                        if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                        {
                            Matched = true,
                            Message = "Both Full Name and Date of Birth matched.",
                        };
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                        };

                    }
                    else
                    {
                        var req = new GeneralRequest();
                        req.id = request.idNumber;
                        req.isSubjectConsent = true;
                        var bvn = _thirdPartySettings.Endpoints["BVN"];
                        var feedback = await ExcuteThirdPartyAPI(req, bvn);
                        if (feedback != null)
                        {
                            var resp = _mapper.Map<CustomerBVNResponse>(feedback);

                            if (resp != null)
                            {
                                //string convert = resp.image.Replace("data:image/jpg;base64,", String.Empty);                                
                                if (resp.image != null)
                                {
                                    var imageParts = resp.image.Split(',').ToList<string>();
                                    //Exclude the header from base64 by taking second element in List.
                                    var bvnImage = Convert.FromBase64String(imageParts[1]);
                                    resp.imageHeaderN = imageParts[0];
                                    resp.bvnImage = bvnImage;
                                }
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.CustomerBVNResponses.Add(resp);
                                await _dbContext.SaveChangesAsync();

                                var nameFromYouVerify = resp.firstName + " " + resp.middleName + " " + resp.lastName;
                                var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                                var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                                var dateMatch = CompareDateOfBirth(request.dateOfBirth, resp.dateOfBirth);
                                if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                                {
                                    Matched = true,
                                    Message = "Both Full Name and Date of Birth matched.",
                                };
                                return new PersonalIdentificationResponse
                                {
                                    Matched = false,
                                    Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                                };
                            }
                        }
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };
                    }
                }
                return new PersonalIdentificationResponse
                {
                    Matched = false,
                    Message = "BVN Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<PersonalIdentificationResponse> FetchCustomerBVN(PersonalIdentificationRequest request)
        {
            try
            {
                if(request.idNumber != null)
                {
                    var bvnExist = _dbContext.CustomerBVNResponses.Where(x => x.idNumber == request.idNumber).FirstOrDefault();
                    if (bvnExist != null)
                    {
                        var nameFromYouVerify = bvnExist.firstName + " "+ bvnExist.middleName + " " + bvnExist.lastName;
                        var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;
                        
                        var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                        var dateMatch = CompareDateOfBirth(request.dateOfBirth, bvnExist.dateOfBirth);
                        if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                        {
                            Matched = true,
                            Message = "Both Full Name and Date of Birth matched.",
                        };
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                        };
                        
                    }
                    else
                    {
                        var req = new GeneralRequest();
                        req.id = request.idNumber;
                        req.isSubjectConsent = true;
                        var bvn = _thirdPartySettings.Endpoints["BVN"];
                        var feedback = await ExcuteThirdPartyAPI(req, bvn);
                        if (feedback != null)
                        {
                            var resp = _mapper.Map<CustomerBVNResponse>(feedback);

                            if(resp != null)
                            {
                                //string convert = resp.image.Replace("data:image/jpg;base64,", String.Empty);                                
                                if(resp.image != null)
                                {
                                    var imageParts = resp.image.Split(',').ToList<string>();
                                    //Exclude the header from base64 by taking second element in List.
                                    var bvnImage = Convert.FromBase64String(imageParts[1]);
                                    resp.imageHeaderN = imageParts[0];
                                    resp.bvnImage = bvnImage;
                                }
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.CustomerBVNResponses.Add(resp);
                                await _dbContext.SaveChangesAsync();

                                var nameFromYouVerify = resp.firstName + " " + resp.middleName + " " + resp.lastName;
                                var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                                var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                                var dateMatch = CompareDateOfBirth(request.dateOfBirth, resp.dateOfBirth);
                                if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                                {
                                    Matched = true,
                                    Message = "Both Full Name and Date of Birth matched.",
                                };
                                return new PersonalIdentificationResponse
                                {
                                    Matched = false,
                                    Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                                };
                            }
                        }
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };
                    }
                }
                return new PersonalIdentificationResponse
                {
                    Matched = false,
                    Message = "BVN Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        public async Task<PersonalIdentificationResponse> FetchCustomerNIN(PersonalIdentificationRequest request)
        {
            try
            {
                if (request.idNumber != null)
                {
                    var ninExist = _dbContext.CustomerNINResponses.Where(x => x.idNumber == request.idNumber).FirstOrDefault();
                    if (ninExist != null)
                    {
                        var nameFromYouVerify = ninExist.firstName + " " + ninExist.middleName + " " + ninExist.lastName;
                        var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                        var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                        var dateMatch = CompareDateOfBirth(request.dateOfBirth, ninExist.dateOfBirth);
                        if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                        {
                            Matched = true,
                            Message = "Both Full Name and Date of Birth matched.",
                        };
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                        };
                    }
                    else
                    {
                        var req = new GeneralRequest();
                        req.id = request.idNumber;
                        req.isSubjectConsent = true;

                        var nin = _thirdPartySettings.Endpoints["NIN"];
                        var feedback = await ExcuteThirdPartyAPI(req, nin);
                        if (feedback != null)
                        {
                            var resp = _mapper.Map<CustomerNINResponse>(feedback);
                            if(resp != null)
                            {
                                if (resp.image != null)
                                {
                                    var imageParts = resp.image.Split(',').ToList<string>();
                                
                                    //Exclude the header from base64 by taking second element in List.
                                    var ninImage = Convert.FromBase64String(imageParts[1]);
                                    resp.imageHeaderN = imageParts[0];
                                    resp.ninImageN = ninImage;
                                }

                                if (resp.signature != null)
                                {
                                    var signatureParts = resp.signature.Split(',').ToList<string>();
                                    var sigImage = Convert.FromBase64String(signatureParts[1]);
                                    resp.signatureHeaderN = signatureParts[0];
                                    resp.signatureImageN = sigImage;

                                }

                                resp.town = feedback.address.town;
                                resp.lga = feedback.address.lga;
                                resp.state = feedback.address.state;
                                resp.addressLine = feedback.address.addressLine;
                                resp.Success = true;
                                resp.Message = "Successful";

                                _dbContext.CustomerNINResponses.Add(resp);
                                await _dbContext.SaveChangesAsync(); 
                                
                                var nameFromYouVerify = resp.firstName + " " + resp.middleName + " " + resp.lastName;
                                var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                                var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                                var dateMatch = CompareDateOfBirth(request.dateOfBirth, resp.dateOfBirth);
                                if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                                {
                                    Matched = true,
                                    Message = "Both Full Name and Date of Birth matched.",
                                };
                                return new PersonalIdentificationResponse
                                {
                                    Matched = false,
                                    Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                                };
                            }
                        }
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };

                    }
                }
                return new PersonalIdentificationResponse
                {
                    Matched = false,
                    Message = "NIN Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PersonalIdentificationResponse> FetchCustomerPVC(PersonalIdentificationRequest request)
        {
            try
            {
                if (request.idNumber != null)
                {
                    var pvcExist = _dbContext.CustomerPVCResponses.Where(x => x.idNumber == request.idNumber).FirstOrDefault();
                    if (pvcExist != null)
                    {
                        var nameFromYouVerify = pvcExist.firstName + " " + pvcExist.middleName + " " + pvcExist.lastName;
                        var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                        var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                        var dateMatch = CompareDateOfBirth(request.dateOfBirth, pvcExist.dateOfBirth);
                        if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                        {
                            Matched = true,
                            Message = "Both Full Name and Date of Birth matched.",
                        };
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                        };
                    }
                    else
                    {
                        var req = new GeneralRequestPVC();
                        req.id = request.idNumber;                       
                        req.isSubjectConsent = true;
                        var pvc = _thirdPartySettings.Endpoints["PVC"];
                        var feedback = await ExcuteThirdPartyPVC(req, pvc);
                        if (feedback != null)
                        {
                            var resp = _mapper.Map<CustomerPVCResponse>(feedback);
                            if (resp != null)
                            {
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.CustomerPVCResponses.Add(resp);
                                await _dbContext.SaveChangesAsync();
                                var nameFromYouVerify = resp.firstName + " " + resp.middleName + " " + resp.lastName;
                                var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                                var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                                var dateMatch = CompareDateOfBirth(request.dateOfBirth, resp.dateOfBirth);
                                if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                                {
                                    Matched = true,
                                    Message = "Both Full Name and Date of Birth matched.",
                                };
                                return new PersonalIdentificationResponse
                                {
                                    Matched = false,
                                    Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                                };
                            }
                        }

                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };
                    }
                }
                return new PersonalIdentificationResponse
                {
                    Matched = false,
                    Message = "PVC Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PersonalIdentificationResponse> FetchCustomerINP(PersonalIdentificationRequest request)
        {
            try
            {
                if (request.idNumber != null && request.lastName != null)
                {
                    var inpExist = _dbContext.CustomerINTLPassportResponses.Where(x => x.idNumber == request.idNumber).FirstOrDefault();
                    if (inpExist != null)
                    {
                        var nameFromYouVerify = inpExist.firstName + " " + inpExist.middleName + " " + inpExist.lastName;
                        var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                        var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                        var dateMatch = CompareDateOfBirth(request.dateOfBirth, inpExist.dateOfBirth);
                        if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                        {
                            Matched = true,
                            Message = "Both Full Name and Date of Birth matched.",
                        };
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                        };
                    }
                    else
                    {
                        var req = new GeneralRequest();
                        req.id = request.idNumber;
                        req.isSubjectConsent = true;
                        req.lastName = request.lastName;
                        var inp = _thirdPartySettings.Endpoints["INP"];
                        var feedback = await ExcuteThirdPartyAPI(req, inp);
                        if (feedback != null) 
                        { 
                            var resp = _mapper.Map<CustomerINTLPassportResponse>(feedback);                        
                            if(resp != null)
                            {
                                if (resp.image != null)
                                {
                                    var imageParts = resp.image.Split(',').ToList<string>();

                                    //Exclude the header from base64 by taking second element in List.
                                    var inpImage = Convert.FromBase64String(imageParts[1]);
                                    resp.imageHeaderN = imageParts[0];
                                    resp.INPImage = inpImage;
                                }

                                if (resp.signature != null)
                                {
                                    var signatureParts = resp.signature.Split(',').ToList<string>();
                                    var sigImage = Convert.FromBase64String(signatureParts[1]);
                                    resp.signatureHeaderN = signatureParts[0];
                                    resp.signatureImageN = sigImage;

                                }
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.CustomerINTLPassportResponses.Add(resp);
                                await _dbContext.SaveChangesAsync();
                                var nameFromYouVerify = resp.firstName + " " + resp.middleName + " " + resp.lastName;
                                var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                                var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                                var dateMatch = CompareDateOfBirth(request.dateOfBirth, resp.dateOfBirth);
                                if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                                {
                                    Matched = true,
                                    Message = "Both Full Name and Date of Birth matched.",
                                };
                                return new PersonalIdentificationResponse
                                {
                                    Matched = false,
                                    Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                                };
                            }
                        }
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };
                    }
                }
                return new PersonalIdentificationResponse
                {
                    Matched = false,
                    Message = "Passport Number Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PersonalIdentificationResponse> FetchCustomerNDL(PersonalIdentificationRequest request)
        {
            try
            {
                if (request.idNumber != null)
                {
                    var ndlExist = _dbContext.CustomerDriversLicenseResponses.Where(x => x.idNumber == request.idNumber).FirstOrDefault();
                    if (ndlExist != null)
                    {
                        var nameFromYouVerify = ndlExist.firstName + " " + ndlExist.middleName + " " + ndlExist.lastName;
                        var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                        var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                        var dateMatch = CompareDateOfBirth(request.dateOfBirth, ndlExist.dateOfBirth);
                        if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                        {
                            Matched = true,
                            Message = "Both Full Name and Date of Birth matched.",
                        };
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                        };
                    }
                    else
                    {
                        var req = new GeneralRequest();
                        req.id = request.idNumber;
                        req.isSubjectConsent = true;
                        var ndl = _thirdPartySettings.Endpoints["NDL"];
                        var feedback = await ExcuteThirdPartyAPI(req, ndl);
                        if (feedback != null) 
                        {                         
                           var resp = _mapper.Map<CustomerDriversLicenseResponse>(feedback);
                           if(resp != null)
                            {
                                if (resp.image != null)
                                {
                                    var imageParts = resp.image.Split(',').ToList<string>();

                                    //Exclude the header from base64 by taking second element in List.
                                    var ndlImage = Convert.FromBase64String(imageParts[1]);
                                    resp.imageHeaderN = imageParts[0];
                                    resp.NDLImage = ndlImage;
                                }
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.CustomerDriversLicenseResponses.Add(resp);
                                await _dbContext.SaveChangesAsync();
                                var nameFromYouVerify = resp.firstName + " " + resp.middleName + " " + resp.lastName;
                                var nameToCheck = request.firstName + " " + request.middleName + " " + request.lastName;

                                var nameMatch = ComparePersonalName(nameToCheck, nameFromYouVerify);
                                var dateMatch = CompareDateOfBirth(request.dateOfBirth, resp.dateOfBirth);
                                if ((await nameMatch) && (await dateMatch)) return new PersonalIdentificationResponse
                                {
                                    Matched = true,
                                    Message = "Both Full Name and Date of Birth matched.",
                                };
                                return new PersonalIdentificationResponse
                                {
                                    Matched = false,
                                    Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                                };
                            }
                        }
                        return new PersonalIdentificationResponse
                        {
                            Matched = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };
                    }
                }
                return new PersonalIdentificationResponse
                {
                    Matched = false,
                    Message = "NDL Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<CompanyIdentificationResponse> FetchBusinessCAC(CompanyIdentificationRequest model)
        {
            try
            {
                if (model.idNumber != null)
                {
                    var cacExist = _dbContext.BusinessCACResponses.Where(x => x.registrationNumber == model.idNumber).FirstOrDefault();
                   
                    if (cacExist != null)
                    {
                        //var keyPerson = _dbContext.keyPersonnelDetails.Where(x => x.typeNumber == model.idNumber && x.type == "CAC").ToList();
                        //cacExist.keyPersonnel = keyPerson;
                        //return cacExist;

                        var nameMatch = await CompareCompanyName(model.CompanyName.Trim(), cacExist.name.Trim());
                        if ( nameMatch)  return new CompanyIdentificationResponse
                        {
                            Matched = true,
                            Message = "Both Company Name matched %100.",
                        };
                        return new CompanyIdentificationResponse
                        {
                            Matched = false,
                            Message = "Either Company Name did not match. Kindly review and enter correct details.",
                        };
                    }
                    else
                    {
                        var req = new BusinessRequestCAC();
                        req.registrationNumber = model.idNumber;
                        req.countryCode = "NG";
                        req.isConsent = true;
                        var cac = _thirdPartySettings.Endpoints["CAC"];
                        var feedback = await ExcuteThirdPartyBusinessAPICAC(req, cac);
                        if (feedback != null)
                        {
                            var resp = _mapper.Map<BusinessCACResponse>(feedback);                                                                   
                            if (resp != null)
                            {
                                foreach (var item in resp.keyPersonnel)
                                {
                                    item.requestedDate = DateTimeOffset.Now;
                                    item.type = "CAC";
                                    item.typeNumber = resp.registrationNumber;
                                    item.CompanyName = resp.name;
                                }
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.BusinessCACResponses.Add(resp);                            
                                await _dbContext.SaveChangesAsync();

                                var nameMatch = await CompareCompanyName(model.CompanyName.Trim(), resp.name.Trim());
                                if (nameMatch) return new CompanyIdentificationResponse
                                {
                                    Matched = true,
                                    Message = "Both Full Name and Date of Birth matched.",
                                };
                                return new CompanyIdentificationResponse
                                {
                                    Matched = false,
                                    Message = "Full Name OR Date of Birth did not match. Kindly review and enter correct details.",
                                };                                
                            }
                        }
                        return new CompanyIdentificationResponse
                        {
                            Matched = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };
                    }
                }
                return new CompanyIdentificationResponse
                {
                    Matched = false,
                    Message = "CAC Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BusinessTINResponse> FetchBusinessTIN(string TIN)
        {
            try
            {
                if (TIN != null)
                {
                    var tinExist = _dbContext.BusinessTINResponses.Where(x => x.tin == TIN).FirstOrDefault();
                    if (tinExist != null)
                    {
                        var keyPerson = _dbContext.keyPersonnelDetails.Where(x => x.typeNumber == TIN && x.type == "TIN").ToList();
                        tinExist.keyPersonnel = keyPerson;

                        return tinExist;
                    }
                    else
                    {
                        var req = new BusinessRequestTIN();
                        req.type = "tin";
                        req.value = TIN;
                        req.isConsent = true;
                        var tin = _thirdPartySettings.Endpoints["BVS"];
                        var feedback = await ExcuteThirdPartyBusinessAPITIN(req, tin);
                        if (feedback != null)
                        {
                            var resp = _mapper.Map<BusinessTINResponse>(feedback);

                            if (resp != null)
                            {
                                foreach (var item in resp.keyPersonnel)
                                {
                                    item.requestedDate = DateTimeOffset.Now;
                                    item.type = "TIN";
                                    item.typeNumber = resp.tin;
                                    item.CompanyName = resp.name;

                                }
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.BusinessTINResponses.Add(resp);
                                await _dbContext.SaveChangesAsync();
                                return resp;
                            }
                        }
                        return null;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //FOR PWC
        public async Task<BVNIndividualResponse> FetchCustomerBVN(string BVN)
        {
            try
            {
                if (!string.IsNullOrEmpty(BVN))
                {
                    var bvnDetails = _dbContext.CustomerBVNResponses.Where(x => x.idNumber == BVN).FirstOrDefault();
                    if (bvnDetails != null)
                    {                       
                        return new BVNIndividualResponse
                        {
                            Bvn = bvnDetails.idNumber,
                            FirstName = bvnDetails.firstName,
                            MiddleName = bvnDetails.middleName,
                            LastName = bvnDetails.lastName,
                            DateOfBirth = bvnDetails.dateOfBirth,
                            Gender = bvnDetails.gender,
                            isAvailable = true,
                            Message = "Successful"
                        };
                        
                    }
                    else
                    {
                        var req = new ThirdPartyAPIRequest();
                        req.id = BVN;
                        req.isSubjectConsent = true;
                        var bvn = _thirdPartySettings.Endpoints["BVN"];
                        var feedback = await ExcuteThirdPartyAPIBVN(req, bvn);
                        if (feedback != null)
                        {
                            var resp = _mapper.Map<CustomerBVNResponse>(feedback);

                            if (resp != null)
                            {
                                //string convert = resp.image.Replace("data:image/jpg;base64,", String.Empty);                                
                                if (resp.image != null)
                                {
                                    var imageParts = resp.image.Split(',').ToList<string>();
                                    //Exclude the header from base64 by taking second element in List.
                                    var bvnImage = Convert.FromBase64String(imageParts[1]);
                                    resp.imageHeaderN = imageParts[0];
                                    resp.bvnImage = bvnImage;
                                }
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.CustomerBVNResponses.Add(resp);
                                await _dbContext.SaveChangesAsync();

                                return new BVNIndividualResponse
                                {
                                    Bvn = resp.idNumber,
                                    FirstName = resp.firstName,
                                    MiddleName = resp.middleName,
                                    LastName = resp.lastName,
                                    DateOfBirth = resp.dateOfBirth,
                                    Gender = resp.gender,
                                    isAvailable = true,
                                    Message = "Successful"
                                };
                            }
                        }
                        return new BVNIndividualResponse
                        {
                            isAvailable = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };
                    }
                }
                return new BVNIndividualResponse
                {
                    isAvailable = false,
                    Message = "BVN Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CACCorporateResponse> FetchBusinessCAC(string CAC)
        {
            try
            {
                if (!string.IsNullOrEmpty(CAC))
                {
                    var cacDetails = _dbContext.BusinessCACResponses.Where(x => x.registrationNumber == CAC).FirstOrDefault();

                    if (cacDetails != null)
                    {
                        return new CACCorporateResponse
                        {
                            RCNumber = cacDetails.registrationNumber,
                            CompanyName = cacDetails.name,
                            EmailAddress = cacDetails.email,
                            Address = cacDetails.address,
                            IndustryType = cacDetails.typeOfEntity,
                            RegistrationDate = cacDetails.registrationDate,
                            isAvailable = true,
                            Message = "Successful",
                        };                       
                    }
                    else
                    {
                        var req = new BusinessRequestCAC();
                        req.registrationNumber = CAC;
                        req.countryCode = "NG";
                        req.isConsent = true;
                        var cac = _thirdPartySettings.Endpoints["CAC"];
                        var feedback = await ExcuteThirdPartyBusinessAPICAC(req, cac);
                        if (feedback != null)
                        {
                            var resp = _mapper.Map<BusinessCACResponse>(feedback);
                            if (resp != null)
                            {
                                foreach (var item in resp.keyPersonnel)
                                {
                                    item.requestedDate = DateTimeOffset.Now;
                                    item.type = "CAC";
                                    item.typeNumber = resp.registrationNumber;
                                    item.CompanyName = resp.name;
                                }
                                resp.Success = true;
                                resp.Message = "Successful";
                                _dbContext.BusinessCACResponses.Add(resp);
                                await _dbContext.SaveChangesAsync();

                                return new CACCorporateResponse
                                {
                                    RCNumber = resp.registrationNumber,
                                    CompanyName = resp.name,
                                    EmailAddress = resp.email,
                                    Address = resp.address,
                                    IndustryType = resp.typeOfEntity,
                                    RegistrationDate = resp.registrationDate,
                                    isAvailable = true,
                                    Message = "Successful",
                                };

                            }
                        }
                        return new CACCorporateResponse
                        {
                            isAvailable = false,
                            Message = "You Verify end-point did not return any value. No Record found for this number.",
                        };
                    }
                }
                return new CACCorporateResponse
                {
                    isAvailable = false,
                    Message = "CAC Detail is empty. Kindly review and enter correct details.",
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public async Task<GeneralResponse> ExcuteThirdPartyAPIBVN(ThirdPartyAPIRequest generalRequest, string endPoint)
        {
            try
            {
                var resp = new ThirdPartyAPIResponse<GeneralResponse>();
                _client.BaseUrl = new Uri(_thirdPartySettings.BaseURL);
                _client.AddDefaultHeader("token", _thirdPartySettings.token);

                RestRequest request = new RestRequest(endPoint, Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(generalRequest);
               

                IRestResponse response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    resp = JsonConvert.DeserializeObject<ThirdPartyAPIResponse<GeneralResponse>>(response.Content);
                    resp.Data.requestedDate = DateTimeOffset.Now;
                    
                    return resp.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<GeneralResponse> ExcuteThirdPartyAPI(GeneralRequest generalRequest, string endPoint)
        {
            try
            {
                var resp = new ThirdPartyAPIResponse<GeneralResponse>();
                _client.BaseUrl = new Uri(_thirdPartySettings.BaseURL);
                _client.AddDefaultHeader("token", _thirdPartySettings.token);

                RestRequest request = new RestRequest(endPoint, Method.POST);
                request.RequestFormat = DataFormat.Json;
                if (generalRequest.lastName != null)
                {
                    request.AddJsonBody(generalRequest);
                }
                else
                {
                    var req = _mapper.Map<ThirdPartyAPIRequest>(generalRequest);
                    request.AddJsonBody(req);
                }

                IRestResponse response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    resp = JsonConvert.DeserializeObject<ThirdPartyAPIResponse<GeneralResponse>>(response.Content);
                    resp.Data.requestedDate = DateTimeOffset.Now;

                    return resp.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<GeneralResponse> ExcuteThirdPartyPVC(GeneralRequestPVC generalRequest, string endPoint)
        {
            try
            {
                var resp = new ThirdPartyAPIResponse<GeneralResponse>();
                _client.BaseUrl = new Uri(_thirdPartySettings.BaseURL);
                _client.AddDefaultHeader("token", _thirdPartySettings.token);

                RestRequest request = new RestRequest(endPoint, Method.POST);
                request.RequestFormat = DataFormat.Json;
                var req = _mapper.Map<ThirdPartyAPIRequest>(generalRequest);
                request.AddJsonBody(req);

                IRestResponse response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    resp = JsonConvert.DeserializeObject<ThirdPartyAPIResponse<GeneralResponse>>(response.Content);
                    resp.Data.requestedDate = DateTimeOffset.Now;

                    return resp.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<BusinessResponseBase> ExcuteThirdPartyBusinessAPICAC(BusinessRequestCAC businessRequest, string endPoint)
        {
            try
            {
                var resp = new ThirdPartyAPIResponse<BusinessResponseBase>();
                _client.BaseUrl = new Uri(_thirdPartySettings.BaseURL);
                _client.AddDefaultHeader("token", _thirdPartySettings.token);

                RestRequest request = new RestRequest(endPoint, Method.POST);
                request.RequestFormat = DataFormat.Json;
                if (businessRequest != null)
                {
                    request.AddJsonBody(businessRequest);
                }
                IRestResponse response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    resp = JsonConvert.DeserializeObject<ThirdPartyAPIResponse<BusinessResponseBase>>(response.Content);
                    resp.Data.requestedDate = DateTimeOffset.Now.ToLocalTime();
                    return resp.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BusinessResponseBase> ExcuteThirdPartyBusinessAPITIN(BusinessRequestTIN businessRequest, string endPoint)
        {
            try
            {
                var resp = new ThirdPartyAPIResponse<BusinessResponseBase>();
                _client.BaseUrl = new Uri(_thirdPartySettings.BaseURL);
                _client.AddDefaultHeader("token", _thirdPartySettings.token);

                RestRequest request = new RestRequest(endPoint, Method.POST);
                request.RequestFormat = DataFormat.Json;
                if (businessRequest != null)
                {
                    request.AddJsonBody(businessRequest);
                }

                IRestResponse response = await _client.ExecuteAsync(request);
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    resp = JsonConvert.DeserializeObject<ThirdPartyAPIResponse<BusinessResponseBase>>(response.Content);
                    resp.Data.requestedDate = DateTimeOffset.Now.ToLocalTime();

                    return resp.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<bool> CompareCompanyName(string nameToCheck, string nameFromYouVerify)
        {
            var bonita = nameToCheck.ToUpper().Replace(' ', '-');
            var youVerify = nameFromYouVerify.ToUpper().Replace(' ','-');

            if (bonita == youVerify) return Task.FromResult(true);
            return Task.FromResult(false);        
        }
        public Task<bool> ComparePersonalName(string nameToCheck, string nameFromYouVerify)
        {
            var bonita = nameToCheck.ToUpper();
            var youVerify = nameFromYouVerify.ToUpper();

            string[] separators = { ",", ".", "!", "?", ";", ":", " ", "-", "_", "&", "#", "@", "%", "$", "*", "/", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] Flex = bonita.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] Neft = youVerify.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            foreach (var i in Flex)
            {
                foreach (var j in Neft)
                {
                    if (i == j) count++;                    
                }
            }
            if (count >= 2) return Task.FromResult(true);
           
            return Task.FromResult(false);
        }

        public Task<bool> CompareDateOfBirth(DateTimeOffset dateToCheck, DateTimeOffset dateFromYouVerify)
        {
            if (dateToCheck == dateFromYouVerify) return Task.FromResult(true);
            return Task.FromResult(false);
        }
        public Task<CryptResponse> EncryptViaAes(string word)
        {

            CryptResponse response;
            try
            {
                string? key = _thirdPartySettings.EncryptionKey;
                byte[] clearBytes = Encoding.Unicode.GetBytes(word);
                string encryptedWord = string.Empty;
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x65, 0x64, 0x65, 0x76, 0x2e, 0x6d, 0x4d });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        encryptedWord = Convert.ToBase64String(ms.ToArray());
                    }
                }
                response = new CryptResponse
                {
                    status = true,
                    message = encryptedWord
                };

            }
            catch (Exception ex)
            {
                //sex.LogError();
                response = new CryptResponse
                {
                    status = false,
                    message = ex.Message.ToString()
                };

            }
            return Task.FromResult(response);
        }

        public Task<CryptResponse> DecryptViaAes(string encryptedWord)
        {

            CryptResponse response;
            try
            {
                string? key = _thirdPartySettings.EncryptionKey;
                string decryptedWord = string.Empty;
                byte[] cipherBytes = Convert.FromBase64String(encryptedWord);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x65, 0x64, 0x65, 0x76, 0x2e, 0x6d, 0x4d });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        decryptedWord = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                response = new CryptResponse
                {
                    status = true,
                    message = decryptedWord
                };
            }
            catch (Exception ex)
            {
                //ex.LogError();
                response = new CryptResponse
                {
                    status = false,
                    message = ex.Message.ToString()
                };

            }
            return Task.FromResult(response);
        }
    }
}
