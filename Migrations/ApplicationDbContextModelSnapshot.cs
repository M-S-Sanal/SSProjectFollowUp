﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSProjectFollowUp.Data;

#nullable disable

namespace SSProjectFollowUp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.BusinessCase", b =>
                {
                    b.Property<int>("BId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BId"));

                    b.Property<double>("BaseLine")
                        .HasColumnType("float");

                    b.Property<double>("BaseLineTarget")
                        .HasColumnType("float");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("BudgetInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalculationExplanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefinitionOfSuccess")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.HasKey("BId");

                    b.HasIndex("PId");

                    b.ToTable("BusinessCases");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.Company", b =>
                {
                    b.Property<int>("CompId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LockDate")
                        .HasColumnType("Date")
                        .HasColumnName("LockDate");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("Date")
                        .HasColumnName("StartDate");

                    b.Property<int>("UserCapacity")
                        .HasColumnType("int");

                    b.HasKey("CompId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.CompanyCross", b =>
                {
                    b.Property<int>("CrossId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrossId"));

                    b.Property<int>("CompId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("CrossId");

                    b.HasIndex("CompId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SectionId");

                    b.ToTable("CompanyCrosses");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.FileLevel", b =>
                {
                    b.Property<int>("PFLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PFLevel"));

                    b.Property<int?>("CompId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.Property<int>("FValue")
                        .HasColumnType("int");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime2(0)")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UpdaterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PFLevel");

                    b.HasIndex("CompId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SectionId");

                    b.HasIndex("UpdaterId");

                    b.ToTable("FileLevels");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.Project", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PId"));

                    b.Property<int?>("CompId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DateTime2(0)")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreaterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PLevel")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime2(0)")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UpdaterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PId");

                    b.HasIndex("CompId");

                    b.HasIndex("CreaterId");

                    b.HasIndex("PLevel");

                    b.HasIndex("UpdaterId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ProjectFile", b =>
                {
                    b.Property<int>("PFId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PFId"));

                    b.Property<int?>("BId")
                        .HasColumnType("int");

                    b.Property<int?>("CompId")
                        .HasColumnType("int");

                    b.Property<string>("CreaterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FExtention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FNo")
                        .HasColumnType("int");

                    b.Property<string>("FUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PFLevel")
                        .HasColumnType("int");

                    b.Property<int?>("PId")
                        .HasColumnType("int");

                    b.Property<int?>("PSId")
                        .HasColumnType("int");

                    b.Property<int?>("PSRId")
                        .HasColumnType("int");

                    b.HasKey("PFId");

                    b.HasIndex("BId");

                    b.HasIndex("CompId");

                    b.HasIndex("CreaterId");

                    b.HasIndex("PFLevel");

                    b.HasIndex("PId");

                    b.HasIndex("PSId");

                    b.HasIndex("PSRId");

                    b.ToTable("ProjectFiles");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ProjectItem", b =>
                {
                    b.Property<int>("PSId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PSId"));

                    b.Property<int?>("CompId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<string>("CreaterId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(6);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("Date")
                        .HasColumnName("DueDate")
                        .HasColumnOrder(3);

                    b.Property<string>("InCharge")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(4);

                    b.Property<string>("OrderColumn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PId")
                        .HasColumnType("int")
                        .HasColumnOrder(10);

                    b.Property<int>("PLevel")
                        .HasColumnType("int")
                        .HasColumnOrder(11);

                    b.Property<int?>("PSSId")
                        .HasColumnType("int");

                    b.Property<int?>("ProPlevel")
                        .HasColumnType("int")
                        .HasColumnOrder(9);

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("Date")
                        .HasColumnName("StartDate")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(7);

                    b.Property<string>("UpdaterId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(8);

                    b.HasKey("PSId");

                    b.HasIndex("CompId");

                    b.HasIndex("CreaterId");

                    b.HasIndex("InCharge");

                    b.HasIndex("PId");

                    b.HasIndex("PLevel");

                    b.HasIndex("UpdaterId");

                    b.ToTable("ProjectItems");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ProjectItemResult", b =>
                {
                    b.Property<int>("PSRId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PSRId"));

                    b.Property<int?>("CompId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreaterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PLevel")
                        .HasColumnType("int");

                    b.Property<int?>("PSId")
                        .HasColumnType("int");

                    b.Property<string>("PSRComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PSRResult")
                        .HasColumnType("int");

                    b.HasKey("PSRId");

                    b.HasIndex("CompId");

                    b.HasIndex("CreaterId");

                    b.HasIndex("PLevel");

                    b.HasIndex("PSId");

                    b.ToTable("ProjectItemResults");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ProjectLevel", b =>
                {
                    b.Property<int>("PLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PLevel"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("DateTime2(0)")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("CreaterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime2(0)")
                        .HasColumnName("UpdatedAt");

                    b.Property<string>("UpdaterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("PLevel");

                    b.HasIndex("CompId");

                    b.HasIndex("CreaterId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SectionId");

                    b.HasIndex("UpdaterId");

                    b.ToTable("ProjectLevels");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.UserApproval", b =>
                {
                    b.Property<int>("UAId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UAId"));

                    b.Property<string>("ApplicantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ApprovedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToCompAdminId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ToCompId")
                        .HasColumnType("int");

                    b.Property<string>("ToUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToUserMail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UAId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("UserApprovals");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int?>("CompId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.HasIndex("CompId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SectionId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.BusinessCase", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.CompanyCross", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSProjectFollowUp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("SSProjectFollowUp.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");

                    b.Navigation("Company");

                    b.Navigation("Department");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.FileLevel", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId");

                    b.HasOne("SSProjectFollowUp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("SSProjectFollowUp.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdaterId");

                    b.Navigation("Company");

                    b.Navigation("Department");

                    b.Navigation("Section");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.Project", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId");

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSProjectFollowUp.Models.ProjectLevel", "ProjectLevel")
                        .WithMany()
                        .HasForeignKey("PLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdaterId");

                    b.Navigation("Company");

                    b.Navigation("CreatedBy");

                    b.Navigation("ProjectLevel");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ProjectFile", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.BusinessCase", "BusinessCase")
                        .WithMany()
                        .HasForeignKey("BId");

                    b.HasOne("SSProjectFollowUp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId");

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreaterId");

                    b.HasOne("SSProjectFollowUp.Models.FileLevel", "FileLevel")
                        .WithMany()
                        .HasForeignKey("PFLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSProjectFollowUp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("PId");

                    b.HasOne("SSProjectFollowUp.Models.ProjectItem", "ProjectItem")
                        .WithMany()
                        .HasForeignKey("PSId");

                    b.HasOne("SSProjectFollowUp.Models.ProjectItemResult", "ProjectItemResult")
                        .WithMany()
                        .HasForeignKey("PSRId");

                    b.Navigation("BusinessCase");

                    b.Navigation("Company");

                    b.Navigation("CreatedBy");

                    b.Navigation("FileLevel");

                    b.Navigation("Project");

                    b.Navigation("ProjectItem");

                    b.Navigation("ProjectItemResult");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ProjectItem", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId");

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreaterId");

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "InChargeUser")
                        .WithMany()
                        .HasForeignKey("InCharge");

                    b.HasOne("SSProjectFollowUp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("PId");

                    b.HasOne("SSProjectFollowUp.Models.ProjectLevel", "ProjectLevel")
                        .WithMany()
                        .HasForeignKey("PLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdaterId");

                    b.Navigation("Company");

                    b.Navigation("CreatedBy");

                    b.Navigation("InChargeUser");

                    b.Navigation("Project");

                    b.Navigation("ProjectLevel");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ProjectItemResult", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId");

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreaterId");

                    b.HasOne("SSProjectFollowUp.Models.ProjectLevel", "ProjectLevel")
                        .WithMany()
                        .HasForeignKey("PLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSProjectFollowUp.Models.ProjectItem", "ProjectItem")
                        .WithMany()
                        .HasForeignKey("PSId");

                    b.Navigation("Company");

                    b.Navigation("CreatedBy");

                    b.Navigation("ProjectItem");

                    b.Navigation("ProjectLevel");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ProjectLevel", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId");

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreaterId");

                    b.HasOne("SSProjectFollowUp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("SSProjectFollowUp.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");

                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdaterId");

                    b.Navigation("Company");

                    b.Navigation("CreatedBy");

                    b.Navigation("Department");

                    b.Navigation("Section");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.UserApproval", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.ApplicationUser", "ApplicantUser")
                        .WithMany()
                        .HasForeignKey("ApplicantId");

                    b.Navigation("ApplicantUser");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ApplicationUser", b =>
                {
                    b.HasOne("SSProjectFollowUp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompId");

                    b.HasOne("SSProjectFollowUp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("SSProjectFollowUp.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");

                    b.Navigation("Company");

                    b.Navigation("Department");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ApplicationRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("SSProjectFollowUp.Models.ApplicationUser", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
