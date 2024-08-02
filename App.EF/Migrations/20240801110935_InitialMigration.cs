﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SystemBase");

            migrationBuilder.EnsureSchema(
                name: "ClinicManagement");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "LogActions",
                schema: "SystemBase",
                columns: table => new
                {
                    logActionToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    modelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oldData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    newData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogActions", x => x.logActionToken);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoleFunctions",
                schema: "SystemBase",
                columns: table => new
                {
                    systemRoleFunctionToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    systemRoleToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    functionsType = table.Column<int>(type: "int", nullable: false),
                    moduleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    functionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isHavePrivilege = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoleFunctions", x => x.systemRoleFunctionToken);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                schema: "SystemBase",
                columns: table => new
                {
                    systemRoleToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    systemRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    systemRoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    systemRoleUserType = table.Column<int>(type: "int", nullable: false),
                    systemRoleCanUseDefault = table.Column<bool>(type: "bit", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.systemRoleToken);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Users",
                columns: table => new
                {
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    userPhone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    userPhoneDialCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userLoginName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    userPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userType = table.Column<int>(type: "int", nullable: false),
                    systemRoleToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userToken);
                    table.ForeignKey(
                        name: "FK_Users_SystemRoles_systemRoleToken",
                        column: x => x.systemRoleToken,
                        principalSchema: "SystemBase",
                        principalTable: "SystemRoles",
                        principalColumn: "systemRoleToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                schema: "ClinicManagement",
                columns: table => new
                {
                    medicalHistoryToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientSugarMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: true),
                    patientSugarMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientSugarMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    patientBloodPressureMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: true),
                    patientBloodPressureMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientBloodPressureMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    patientThyroidSensitivityMeasurement_isMeasured = table.Column<bool>(type: "bit", nullable: true),
                    patientThyroidSensitivityMeasurement_measurementValue = table.Column<double>(type: "float", nullable: true),
                    patientThyroidSensitivityMeasurement_measurementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.medicalHistoryToken);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Users_userPatientToken",
                        column: x => x.userPatientToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalImprovements",
                schema: "ClinicManagement",
                columns: table => new
                {
                    nutritionalImprovementToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientHeightInCm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    patientWeightInKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    patientBmr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalImprovements", x => x.nutritionalImprovementToken);
                    table.ForeignKey(
                        name: "FK_NutritionalImprovements_Users_userPatientToken",
                        column: x => x.userPatientToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                schema: "ClinicManagement",
                columns: table => new
                {
                    operationToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    operationName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    operationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.operationToken);
                    table.ForeignKey(
                        name: "FK_Operations_Users_userPatientToken",
                        column: x => x.userPatientToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDoctors",
                schema: "Users",
                columns: table => new
                {
                    userDoctorToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDoctors", x => x.userDoctorToken);
                    table.ForeignKey(
                        name: "FK_UserDoctors_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEmployees",
                schema: "Users",
                columns: table => new
                {
                    userEmployeeToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmployees", x => x.userEmployeeToken);
                    table.ForeignKey(
                        name: "FK_UserEmployees_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken");
                });

            migrationBuilder.CreateTable(
                name: "UserPatients",
                schema: "Users",
                columns: table => new
                {
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    userPatientBloodType = table.Column<int>(type: "int", nullable: false),
                    userPatientChildrenCount = table.Column<int>(type: "int", nullable: false),
                    userPatientAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPatients", x => x.userPatientToken);
                    table.ForeignKey(
                        name: "FK_UserPatients_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken");
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "Users",
                columns: table => new
                {
                    userProfileToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhone4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCC4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userPhoneCCName4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userBirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    userToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.userProfileToken);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_userToken",
                        column: x => x.userToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken");
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                schema: "ClinicManagement",
                columns: table => new
                {
                    visitToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lastPeriodDate = table.Column<DateOnly>(type: "date", nullable: false),
                    expectedDateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    userPatientComplaining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberOfChildren = table.Column<int>(type: "int", nullable: false),
                    medications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    generalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fetalInformations_fetalHeartBeatPerMinute = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fetalInformations_fetalAgeInWeeks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fetalInformations_fetalAgeInMonths = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fetalInformations_fetalWeightInKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    userPatientToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fullCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    updatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.visitToken);
                    table.ForeignKey(
                        name: "FK_Visits_Users_userPatientToken",
                        column: x => x.userPatientToken,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "userToken",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_fullCode",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_userPatientToken",
                schema: "ClinicManagement",
                table: "MedicalHistories",
                column: "userPatientToken");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalImprovements_createdDate",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                column: "createdDate");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalImprovements_fullCode",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalImprovements_userPatientToken",
                schema: "ClinicManagement",
                table: "NutritionalImprovements",
                column: "userPatientToken");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_fullCode",
                schema: "ClinicManagement",
                table: "Operations",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_operationDate",
                schema: "ClinicManagement",
                table: "Operations",
                column: "operationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_operationName",
                schema: "ClinicManagement",
                table: "Operations",
                column: "operationName");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_userPatientToken",
                schema: "ClinicManagement",
                table: "Operations",
                column: "userPatientToken");

            migrationBuilder.CreateIndex(
                name: "IX_UserDoctors_userToken",
                schema: "Users",
                table: "UserDoctors",
                column: "userToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEmployees_userToken",
                schema: "Users",
                table: "UserEmployees",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserPatients_userToken",
                schema: "Users",
                table: "UserPatients",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_userToken",
                schema: "Users",
                table: "UserProfiles",
                column: "userToken",
                unique: true,
                filter: "[userToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_fullCode",
                schema: "Users",
                table: "Users",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_systemRoleToken",
                schema: "Users",
                table: "Users",
                column: "systemRoleToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userEmail",
                schema: "Users",
                table: "Users",
                column: "userEmail",
                unique: true,
                filter: "[userEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userLoginName",
                schema: "Users",
                table: "Users",
                column: "userLoginName",
                unique: true,
                filter: "[userLoginName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userPhone",
                schema: "Users",
                table: "Users",
                column: "userPhone",
                unique: true,
                filter: "[userPhone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userType",
                schema: "Users",
                table: "Users",
                column: "userType");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_fullCode",
                schema: "ClinicManagement",
                table: "Visits",
                column: "fullCode",
                unique: true,
                filter: "[fullCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_userPatientToken",
                schema: "ClinicManagement",
                table: "Visits",
                column: "userPatientToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogActions",
                schema: "SystemBase");

            migrationBuilder.DropTable(
                name: "MedicalHistories",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "NutritionalImprovements",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "Operations",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "SystemRoleFunctions",
                schema: "SystemBase");

            migrationBuilder.DropTable(
                name: "UserDoctors",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "UserEmployees",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "UserPatients",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Visits",
                schema: "ClinicManagement");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "SystemRoles",
                schema: "SystemBase");
        }
    }
}