﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration
{
    //public class CorporateCustomerAccountCreationRequest
    //{
    //    public int? channelId { get; set; }
    //    public string? serviceChannelCode { get; set; }
    //    public int? serviceId { get; set; }
    //    public int? transmissionTime { get; set; }
    //    public int? businessUnitCodeId { get; set; }
    //    public string? custShortName { get; set; }
    //    public string? customerCategory { get; set; }
    //    public string? customerName { get; set; }
    //    public string? firstName { get; set; }
    //    public string? addressCity { get; set; }
    //    public int? addressCountryId { get; set; }
    //    public string? addressLine1 { get; set; }
    //    public string? addressLine2 { get; set; }
    //    public int? addressPropertyTypeId { get; set; }
    //    public string? addressState { get; set; }
    //    public string? addressTypeCd { get; set; }
    //    public int? addressTypeId { get; set; }
    //    public List<CorporateContact> contactsList { get; set; }
    //    public int? countryId { get; set; }
    //    public string? countryOfBirthCd { get; set; }
    //    public int? countryOfBirthId { get; set; }
    //    public int? countryOfResidenceId { get; set; }
    //    public string? custCountryCd { get; set; }
    //    public string? customerSegmentCd { get; set; }
    //    public string? customerTypeCd { get; set; }
    //    public CorporateIdentifications identificationsList { get; set; }
    //    public string? parentObjectCode { get; set; }
    //    public string? screenTypeCode { get; set; }
    //    public int? subTypeId { get; set; }
    //    public List<int?> fieldIdArray { get; set; }
    //    public List<object> fieldValueArr { get; set; }
    //    public string? industryCd { get; set; }
    //    public int? industryId { get; set; }
    //    public string? locale { get; set; }
    //    public int? mainBusinessUnitCd { get; set; }
    //    public int? mainBusinessUnitId { get; set; }
    //    public int? marketingCampaignId { get; set; }
    //    public string? nationalityCd { get; set; }
    //    public int? nationalityId { get; set; }
    //    public string? openingReasonCode { get; set; }
    //    public int? openingReasonId { get; set; }
    //    public string? operationCurrencyCd { get; set; }
    //    public int? operationCurrencyId { get; set; }
    //    public bool primaryAddress { get; set; }
    //    public string? primaryRelationshipOfficerCd { get; set; }
    //    public string? propertyTypeCd { get; set; }
    //    public string? residentCountryCd { get; set; }
    //    public bool residentFlag { get; set; }
    //    public string? riskCode { get; set; }
    //    public string? riskCountryCd { get; set; }
    //    public int? riskId { get; set; }
    //    public int? serviceLevel { get; set; }
    //    public int? serviceLevelId { get; set; }
    //    public string? sourceOfFundCd { get; set; }
    //    public int? sourceOfFundId { get; set; }
    //    public string? status { get; set; }
    //    public string? strDate { get; set; }
    //    public string? strFromDate { get; set; }
    //    public bool submitFlag { get; set; }
    //    public long? taxIdentificationNo { get; set; }
    //    public string? titleCd { get; set; }
    //    public int? titleId { get; set; }
    //    public string? organisationName { get; set; }
    //    public string? registrationNumber { get; set; }
    //    public string? strRegistrationDate { get; set; }
    //}

    //public class CorporateContact
    //{
    //    public object contactDetails { get; set; }
    //    public string? contactMode { get; set; }
    //    public string? contactModeCategoryCode { get; set; }
    //    public int? contactModeTypeId { get; set; }
    //    public string? status { get; set; }
    //}

    //public class CorporateIdentifications
    //{
    //    public string? cityOfIssue { get; set; }
    //    public string? countryOfIssue { get; set; }
    //    public int? countryOfIssueId { get; set; }
    //    public string? identityNumber { get; set; }
    //    public string? identityType { get; set; }
    //    public int? identityTypeId { get; set; }
    //    public string? strIssueDate { get; set; }
    //    public string? strExpiryDate { get; set; }
    //    public bool verifiedFlag { get; set; }
    //}

    public class CorporateCustomerAccountCreationRequest
    {
        public int? channelId { get; set; }
        public string? serviceChannelCode { get; set; }
        public int? serviceId { get; set; }
        public string? transmissionTime { get; set; }
        public int? businessUnitCodeId { get; set; }
        public string? custShortName { get; set; }
        public string? customerCategory { get; set; }
        public string? customerName { get; set; }
        public string? firstName { get; set; }
        public string? addressCity { get; set; }
        public int? addressCountryId { get; set; }
        public string? addressLine1 { get; set; }
        public string? addressLine2 { get; set; }
        public int? addressPropertyTypeId { get; set; }
        public string? addressState { get; set; }
        public string? addressTypeCd { get; set; }
        public int? addressTypeId { get; set; }
        public List<CorporateContact> contactsList { get; set; }
        public int? countryId { get; set; }
        public string? countryOfBirthCd { get; set; }
        public int? countryOfBirthId { get; set; }
        public int? countryOfResidenceId { get; set; }
        public string? custCountryCd { get; set; }
        public string? customerSegmentCd { get; set; }
        public string? customerTypeCd { get; set; }
        public CorporateIdentifications identificationsList { get; set; }
        public string? parentObjectCode { get; set; }
        public string? screenTypeCode { get; set; }
        public int? subTypeId { get; set; }
        public List<int?> fieldIdArray { get; set; }
        public List<object?> fieldValueArr { get; set; }
        public string? industryCd { get; set; }
        public int? industryId { get; set; }
        public string? locale { get; set; }
        public int? mainBusinessUnitCd { get; set; }
        public int? mainBusinessUnitId { get; set; }
        public int? marketingCampaignId { get; set; }
        public string? nationalityCd { get; set; }
        public int? nationalityId { get; set; }
        public string? openingReasonCode { get; set; }
        public int? openingReasonId { get; set; }
        public string? operationCurrencyCd { get; set; }
        public int? operationCurrencyId { get; set; }
        public bool? primaryAddress { get; set; }
        public string? primaryRelationshipOfficerCd { get; set; }
        public string? propertyTypeCd { get; set; }
        public string? residentCountryCd { get; set; }
        public bool? residentFlag { get; set; }
        public string? riskCode { get; set; }
        public string? riskCountryCd { get; set; }
        public int? riskId { get; set; }
        public int? serviceLevel { get; set; }
        public int? serviceLevelId { get; set; }
        public string? sourceOfFundCd { get; set; }
        public int? sourceOfFundId { get; set; }
        public string? status { get; set; }
        public string? strDate { get; set; }
        public string? strFromDate { get; set; }
        public bool? submitFlag { get; set; }
        public long taxIdentificationNo { get; set; }
        public string? titleCd { get; set; }
        public int? titleId { get; set; }
        public string? organisationName { get; set; }
        public string? registrationNumber { get; set; }
        public string? strRegistrationDate { get; set; }
    }

    public class CorporateContact
    {
        public string? contactDetails { get; set; }
        public string? contactMode { get; set; }
        public string? contactModeCategoryCode { get; set; }
        public int? contactModeTypeId { get; set; }
        public string? status { get; set; }
    }

    public class CorporateIdentifications
    {
        public string? cityOfIssue { get; set; }
        public string? countryOfIssue { get; set; }
        public int countryOfIssueId { get; set; }
        public string? identityNumber { get; set; }
        public string? identityType { get; set; }
        public int identityTypeId { get; set; }
        public string? strIssueDate { get; set; }
        public string? strExpiryDate { get; set; }
        public bool? verifiedFlag { get; set; }
    }
}
