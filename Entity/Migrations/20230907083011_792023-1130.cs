using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class _7920231130 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AllowanceType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowanceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowanceTypeNameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowanceType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AllowanceType_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AllowanceType_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AllowanceType_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bank_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Bank_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Bank_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyNameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyFooter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemeDarkColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemeLightColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Company_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Company_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Company_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Country_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Country_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Country_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gender_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Gender_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Gender_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GeneralRequestType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralRequestType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GeneralRequestType_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GeneralRequestType_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GeneralRequestType_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grade_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Grade_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Grade_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "JobDescription",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescription", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobDescription_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_JobDescription_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_JobDescription_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaritalStatus_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MaritalStatus_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MaritalStatus_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequiredNationalNo = table.Column<bool>(type: "bit", nullable: false),
                    IsAllowedSocialSecurityNo = table.Column<bool>(type: "bit", nullable: false),
                    IsPassportNumber = table.Column<bool>(type: "bit", nullable: false),
                    IsIqamaNO = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nationality_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Nationality_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Nationality_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Relationship_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Relationship_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Relationship_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ShiftType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftTypeNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShiftType_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ShiftType_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ShiftType_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TimeAttendanceStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAttendanceStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TimeAttendanceStatus_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TimeAttendanceStatus_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TimeAttendanceStatus_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BankBranch",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankID = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchNameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranch", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankBranch_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BankBranch_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BankBranch_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_bank-bankbranch",
                        column: x => x.BankID,
                        principalTable: "Bank",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThirdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForeignFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForeignSecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForeignThirdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ForeignLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForeignMotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    NationalityID = table.Column<int>(type: "int", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SocialSecurityNO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IqamaNO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaritalStatusID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    ManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FingerprintNo = table.Column<int>(type: "int", nullable: true),
                    JsonBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ERPId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescriptionID = table.Column<int>(type: "int", nullable: true),
                    GradeID = table.Column<int>(type: "int", nullable: true),
                    Leavebalance = table.Column<double>(type: "float", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Employee_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Employee_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_Employee-Country",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Employee-Gender",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Employee-Grade",
                        column: x => x.GradeID,
                        principalTable: "Grade",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_Employee-JobDescription",
                        column: x => x.JobDescriptionID,
                        principalTable: "JobDescription",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_Employee-MaritalStatus",
                        column: x => x.MaritalStatusID,
                        principalTable: "MaritalStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Employee-Nationality",
                        column: x => x.NationalityID,
                        principalTable: "Nationality",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShift",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ShiftTypeID = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelationshipID = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShift", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Relationship_RelationshipID",
                        column: x => x.RelationshipID,
                        principalTable: "Relationship",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EmployeeShift_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EmployeeShift_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EmployeeShift_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDependent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelationshipID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDependent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeDependent_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EmployeeDependent_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EmployeeDependent_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_Employee-EmployeeDependent",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Relationship-EmployeeDependent",
                        column: x => x.RelationshipID,
                        principalTable: "Relationship",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralRequest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralRequestTypeID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GeneralRequest_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GeneralRequest_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_GeneralRequest_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_GeneralRequest-Employee",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_GeneralRequest-GeneralRequestType",
                        column: x => x.GeneralRequestTypeID,
                        principalTable: "GeneralRequestType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    BasicSalary = table.Column<double>(type: "float", nullable: false),
                    BankID = table.Column<int>(type: "int", nullable: false),
                    BankBranchID = table.Column<int>(type: "int", nullable: false),
                    BankAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    BankSwift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalaryInfo_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SalaryInfo_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SalaryInfo_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_SalaryInfo-Bankbranch",
                        column: x => x.BankBranchID,
                        principalTable: "BankBranch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_SalaryInfo-Employee",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeAttendance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntranceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeAttendanceStatusID = table.Column<int>(type: "int", nullable: false),
                    Justification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreationUserID = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAttendance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TimeAttendance_User_CreationUserID",
                        column: x => x.CreationUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TimeAttendance_User_DeleteUserID",
                        column: x => x.DeleteUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TimeAttendance_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_Employee-TimeAttendance",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_TimeAttendance-TimeAttendanceStatus",
                        column: x => x.TimeAttendanceStatusID,
                        principalTable: "TimeAttendanceStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShiftToEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShiftToEmployee", x => new { x.EmployeeId, x.EmployeeShiftId });
                    table.ForeignKey(
                        name: "FK_EmployeeShiftToEmployee_EmployeeShift_EmployeeShiftId",
                        column: x => x.EmployeeShiftId,
                        principalTable: "EmployeeShift",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeShiftToEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTypeEmployeeShift",
                columns: table => new
                {
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypeEmployeeShift", x => new { x.EmployeeShiftId, x.ShiftTypeId });
                    table.ForeignKey(
                        name: "FK_ShiftTypeEmployeeShift_EmployeeShift_EmployeeShiftId",
                        column: x => x.EmployeeShiftId,
                        principalTable: "EmployeeShift",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftTypeEmployeeShift_ShiftType_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceType_CreationUserID",
                table: "AllowanceType",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceType_DeleteUserID",
                table: "AllowanceType",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AllowanceType_ModifyUserID",
                table: "AllowanceType",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_CreationUserID",
                table: "Bank",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_DeleteUserID",
                table: "Bank",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_ModifyUserID",
                table: "Bank",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranch_BankID",
                table: "BankBranch",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranch_CreationUserID",
                table: "BankBranch",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranch_DeleteUserID",
                table: "BankBranch",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranch_ModifyUserID",
                table: "BankBranch",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CreationUserID",
                table: "Company",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_DeleteUserID",
                table: "Company",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ModifyUserID",
                table: "Company",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CreationUserID",
                table: "Country",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_DeleteUserID",
                table: "Country",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ModifyUserID",
                table: "Country",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryID",
                table: "Employee",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CreationUserID",
                table: "Employee",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeleteUserID",
                table: "Employee",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderID",
                table: "Employee",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GradeID",
                table: "Employee",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobDescriptionID",
                table: "Employee",
                column: "JobDescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MaritalStatusID",
                table: "Employee",
                column: "MaritalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ModifyUserID",
                table: "Employee",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_NationalityID",
                table: "Employee",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependent_CreationUserID",
                table: "EmployeeDependent",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependent_DeleteUserID",
                table: "EmployeeDependent",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependent_EmployeeID",
                table: "EmployeeDependent",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependent_ModifyUserID",
                table: "EmployeeDependent",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDependent_RelationshipID",
                table: "EmployeeDependent",
                column: "RelationshipID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_CreationUserID",
                table: "EmployeeShift",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_DeleteUserID",
                table: "EmployeeShift",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_ModifyUserID",
                table: "EmployeeShift",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_RelationshipID",
                table: "EmployeeShift",
                column: "RelationshipID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShiftToEmployee_EmployeeShiftId",
                table: "EmployeeShiftToEmployee",
                column: "EmployeeShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Gender_CreationUserID",
                table: "Gender",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Gender_DeleteUserID",
                table: "Gender",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Gender_ModifyUserID",
                table: "Gender",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRequest_CreationUserID",
                table: "GeneralRequest",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRequest_DeleteUserID",
                table: "GeneralRequest",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRequest_EmployeeID",
                table: "GeneralRequest",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRequest_GeneralRequestTypeID",
                table: "GeneralRequest",
                column: "GeneralRequestTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRequest_ModifyUserID",
                table: "GeneralRequest",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRequestType_CreationUserID",
                table: "GeneralRequestType",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRequestType_DeleteUserID",
                table: "GeneralRequestType",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralRequestType_ModifyUserID",
                table: "GeneralRequestType",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_CreationUserID",
                table: "Grade",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_DeleteUserID",
                table: "Grade",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_ModifyUserID",
                table: "Grade",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescription_CreationUserID",
                table: "JobDescription",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescription_DeleteUserID",
                table: "JobDescription",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescription_ModifyUserID",
                table: "JobDescription",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatus_CreationUserID",
                table: "MaritalStatus",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatus_DeleteUserID",
                table: "MaritalStatus",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatus_ModifyUserID",
                table: "MaritalStatus",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Nationality_CreationUserID",
                table: "Nationality",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Nationality_DeleteUserID",
                table: "Nationality",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Nationality_ModifyUserID",
                table: "Nationality",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_CreationUserID",
                table: "Relationship",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_DeleteUserID",
                table: "Relationship",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_ModifyUserID",
                table: "Relationship",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryInfo_BankBranchID",
                table: "SalaryInfo",
                column: "BankBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryInfo_CreationUserID",
                table: "SalaryInfo",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryInfo_DeleteUserID",
                table: "SalaryInfo",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryInfo_EmployeeID",
                table: "SalaryInfo",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryInfo_ModifyUserID",
                table: "SalaryInfo",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftType_CreationUserID",
                table: "ShiftType",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftType_DeleteUserID",
                table: "ShiftType",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftType_ModifyUserID",
                table: "ShiftType",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypeEmployeeShift_ShiftTypeId",
                table: "ShiftTypeEmployeeShift",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendance_CreationUserID",
                table: "TimeAttendance",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendance_DeleteUserID",
                table: "TimeAttendance",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendance_EmployeeID",
                table: "TimeAttendance",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendance_ModifyUserID",
                table: "TimeAttendance",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendance_TimeAttendanceStatusID",
                table: "TimeAttendance",
                column: "TimeAttendanceStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendanceStatus_CreationUserID",
                table: "TimeAttendanceStatus",
                column: "CreationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendanceStatus_DeleteUserID",
                table: "TimeAttendanceStatus",
                column: "DeleteUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAttendanceStatus_ModifyUserID",
                table: "TimeAttendanceStatus",
                column: "ModifyUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowanceType");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "EmployeeDependent");

            migrationBuilder.DropTable(
                name: "EmployeeShiftToEmployee");

            migrationBuilder.DropTable(
                name: "GeneralRequest");

            migrationBuilder.DropTable(
                name: "SalaryInfo");

            migrationBuilder.DropTable(
                name: "ShiftTypeEmployeeShift");

            migrationBuilder.DropTable(
                name: "TimeAttendance");

            migrationBuilder.DropTable(
                name: "GeneralRequestType");

            migrationBuilder.DropTable(
                name: "BankBranch");

            migrationBuilder.DropTable(
                name: "EmployeeShift");

            migrationBuilder.DropTable(
                name: "ShiftType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "TimeAttendanceStatus");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "JobDescription");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
