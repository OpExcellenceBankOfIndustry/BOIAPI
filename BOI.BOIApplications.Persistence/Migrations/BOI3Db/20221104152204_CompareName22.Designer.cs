﻿// <auto-generated />
using System;
using BOI.BOIApplications.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    [DbContext(typeof(BOI3DbContext))]
    [Migration("20221104152204_CompareName22")]
    partial class CompareName22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.AccountOpeningModels.AOCompanyBOIDiscover", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AOCompanyBOIDiscovers");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.AccountOpeningModels.AOEmployeesRelationship", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AOEmployeesRelationships");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.AccountOpeningModels.AOJobTitle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AOJobTitles");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.BusinessCACResponse", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<string>("activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("branchAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("businessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("headOfficeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isConsent")
                        .HasColumnType("bit");

                    b.Property<string>("jtbTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("lastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("lga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objectives")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("parentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("registrationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("registrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("requestedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("requestedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("searchTerm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("taxOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeOfEntity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("websiteEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("BusinessCACResponses");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.BusinessTINResponse", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<string>("activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("branchAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("businessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("headOfficeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isConsent")
                        .HasColumnType("bit");

                    b.Property<string>("jtbTin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("lastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("lga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objectives")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("parentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("registrationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("registrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("requestedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("requestedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("searchTerm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("taxOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeOfEntity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("websiteEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("BusinessTINResponses");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.CustomerBVNResponse", b =>
                {
                    b.Property<int>("BVNId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BVNId"), 1L, 1);

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<string>("businessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("bvnImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("dataValidation")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("dateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("enrollmentBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enrollmentInstitution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageHeaderN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isConsent")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("lastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("requestedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("requestedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("selfieValidation")
                        .HasColumnType("bit");

                    b.Property<bool>("shouldRetrivedNin")
                        .HasColumnType("bit");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BVNId");

                    b.ToTable("CustomerBVNResponses");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.CustomerDriversLicenseResponse", b =>
                {
                    b.Property<int>("NDLId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NDLId"), 1L, 1);

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("NDLImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<string>("businessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("dataValidation")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("dateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("expiredDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageHeaderN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isConsent")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("issuedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("lastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("notifyWhenIdExpire")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("requestedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("requestedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("selfieValidation")
                        .HasColumnType("bit");

                    b.Property<string>("stateOfIssuance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NDLId");

                    b.ToTable("CustomerDriversLicenseResponses");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.CustomerINTLPassportResponse", b =>
                {
                    b.Property<int>("INPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("INPId"), 1L, 1);

                    b.Property<byte[]>("INPImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<string>("businessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("dataValidation")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("dateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("expiredDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageHeaderN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isConsent")
                        .HasColumnType("bit");

                    b.Property<string>("issuedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("issuedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("lastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("notifyWhenIdExpire")
                        .HasColumnType("bit");

                    b.Property<string>("reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("requestedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("requestedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("selfieValidation")
                        .HasColumnType("bit");

                    b.Property<string>("signature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("signatureHeaderN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("signatureImageN")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("stateOfIssuance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("INPId");

                    b.ToTable("CustomerINTLPassportResponses");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.CustomerNINResponse", b =>
                {
                    b.Property<int>("NINId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NINId"), 1L, 1);

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<string>("addressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birthCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birthLGA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birthState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("businessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("dataValidation")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("dateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageHeaderN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isConsent")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("lastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ninImageN")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("nokState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("religion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("requestedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("requestedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("selfieValidation")
                        .HasColumnType("bit");

                    b.Property<string>("signature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("signatureHeaderN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("signatureImageN")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NINId");

                    b.ToTable("CustomerNINResponses");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.CustomerPVCResponse", b =>
                {
                    b.Property<int>("PVCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PVCId"), 1L, 1);

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<string>("businessId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("dataValidation")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("dateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isConsent")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("lastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("requestedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("requestedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("selfieValidation")
                        .HasColumnType("bit");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PVCId");

                    b.ToTable("CustomerPVCResponses");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.keyPersonnel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("BusinessCACResponseid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BusinessTINResponseid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("requestedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("BusinessCACResponseid");

                    b.HasIndex("BusinessTINResponseid");

                    b.ToTable("keyPersonnelDetails");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.keyPersonnel", b =>
                {
                    b.HasOne("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.BusinessCACResponse", null)
                        .WithMany("keyPersonnel")
                        .HasForeignKey("BusinessCACResponseid");

                    b.HasOne("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.BusinessTINResponse", null)
                        .WithMany("keyPersonnel")
                        .HasForeignKey("BusinessTINResponseid");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.BusinessCACResponse", b =>
                {
                    b.Navigation("keyPersonnel");
                });

            modelBuilder.Entity("BOI.BOIApplications.Domain.Entities.ThirdPartyAPI.BusinessTINResponse", b =>
                {
                    b.Navigation("keyPersonnel");
                });
#pragma warning restore 612, 618
        }
    }
}