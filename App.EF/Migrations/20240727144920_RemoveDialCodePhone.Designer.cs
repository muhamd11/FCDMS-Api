﻿// <auto-generated />
using System;
using App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240727144920_RemoveDialCodePhone")]
    partial class RemoveDialCodePhone
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Core.Models.ClinicModules.OperationsModules.Operation", b =>
                {
                    b.Property<Guid>("operationToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("operationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("operationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("operationToken");

                    b.HasIndex("fullCode")
                        .IsUnique()
                        .HasFilter("[fullCode] IS NOT NULL");

                    b.HasIndex("operationDate");

                    b.HasIndex("operationName");

                    b.HasIndex("userToken");

                    b.ToTable("Operations", "ClinicManagement");
                });

            modelBuilder.Entity("App.Core.Models.SystemBase.Roles.SystemRole", b =>
                {
                    b.Property<Guid>("systemRoleToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("systemRoleCanUseDefault")
                        .HasColumnType("bit");

                    b.Property<string>("systemRoleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("systemRoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("systemRoleUserType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("systemRoleToken");

                    b.ToTable("SystemRoles", "SystemBase");
                });

            modelBuilder.Entity("App.Core.Models.SystemBase._01._2_SystemRoleFunctions.SystemRoleFunction", b =>
                {
                    b.Property<Guid>("systemRoleFunctionToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("functionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("functionsType")
                        .HasColumnType("int");

                    b.Property<bool>("isHavePrivilege")
                        .HasColumnType("bit");

                    b.Property<string>("moduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("systemRoleToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("systemRoleFunctionToken");

                    b.ToTable("SystemRoleFunctions", "SystemBase");
                });

            modelBuilder.Entity("App.Core.Models.Users.User", b =>
                {
                    b.Property<Guid>("userToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("createdDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("fullCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("systemRoleToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("updatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userLoginName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userPhoneCC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCCName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneDialCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userType")
                        .HasColumnType("int");

                    b.HasKey("userToken");

                    b.HasIndex("fullCode")
                        .IsUnique()
                        .HasFilter("[fullCode] IS NOT NULL");

                    b.HasIndex("systemRoleToken");

                    b.HasIndex("userEmail")
                        .IsUnique();

                    b.HasIndex("userLoginName")
                        .IsUnique();

                    b.HasIndex("userPhone")
                        .IsUnique();

                    b.HasIndex("userType");

                    b.ToTable("Users", "Users");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule.LogActionsModel.LogAction", b =>
                {
                    b.Property<Guid>("logActionToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("actionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("actionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("newData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("oldData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("logActionToken");

                    b.ToTable("LogActions", "SystemBase");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee.UserEmployee", b =>
                {
                    b.Property<Guid>("userEmployeeToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userEmployeeToken");

                    b.HasIndex("userToken")
                        .IsUnique()
                        .HasFilter("[userToken] IS NOT NULL");

                    b.ToTable("UserEmployees", "Users");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor.UserDoctor", b =>
                {
                    b.Property<Guid>("userDoctorToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userDoctorToken");

                    b.HasIndex("userToken")
                        .IsUnique();

                    b.ToTable("UserDoctors", "Users");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01_1_UserTypes.UserProfile", b =>
                {
                    b.Property<Guid>("userProfileToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("userBirthDate")
                        .HasColumnType("date");

                    b.Property<string>("userContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCCName_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCCName_3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCCName_4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCC_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCC_3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhoneCC_4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone_2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone_3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPhone_4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userProfileToken");

                    b.HasIndex("userToken")
                        .IsUnique()
                        .HasFilter("[userToken] IS NOT NULL");

                    b.ToTable("UserProfiles", "Users");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData.UserPatient", b =>
                {
                    b.Property<Guid>("userPatientToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("userPatientAge")
                        .HasColumnType("int");

                    b.Property<int>("userPatientBloodType")
                        .HasColumnType("int");

                    b.Property<int>("userPatientChildrenCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("userToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userPatientToken");

                    b.HasIndex("userToken")
                        .IsUnique()
                        .HasFilter("[userToken] IS NOT NULL");

                    b.ToTable("UserPatients", "Users");
                });

            modelBuilder.Entity("App.Core.Models.ClinicModules.OperationsModules.Operation", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithMany("operationsData")
                        .HasForeignKey("userToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.Users.User", b =>
                {
                    b.HasOne("App.Core.Models.SystemBase.Roles.SystemRole", "roleData")
                        .WithMany("usersData")
                        .HasForeignKey("systemRoleToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roleData");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee.UserEmployee", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithOne("userEmployeeData")
                        .HasForeignKey("App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee.UserEmployee", "userToken");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor.UserDoctor", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithOne("userDoctorData")
                        .HasForeignKey("App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor.UserDoctor", "userToken")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01_1_UserTypes.UserProfile", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithOne("userProfileData")
                        .HasForeignKey("App.Core.Models.UsersModule._01_1_UserTypes.UserProfile", "userToken");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData.UserPatient", b =>
                {
                    b.HasOne("App.Core.Models.Users.User", "userData")
                        .WithOne("userPatientData")
                        .HasForeignKey("App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData.UserPatient", "userToken");

                    b.Navigation("userData");
                });

            modelBuilder.Entity("App.Core.Models.SystemBase.Roles.SystemRole", b =>
                {
                    b.Navigation("usersData");
                });

            modelBuilder.Entity("App.Core.Models.Users.User", b =>
                {
                    b.Navigation("operationsData");

                    b.Navigation("userDoctorData");

                    b.Navigation("userEmployeeData");

                    b.Navigation("userPatientData");

                    b.Navigation("userProfileData");
                });
#pragma warning restore 612, 618
        }
    }
}
