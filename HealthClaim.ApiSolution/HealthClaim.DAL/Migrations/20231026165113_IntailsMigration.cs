using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class IntailsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeavingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpRelations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRelations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UplodDocType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBillable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UplodDocType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimStatusCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatusCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimStatusCategory_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpAccountDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IfscCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAccountDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAccountDetails_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAccountDetails_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAccountDetails_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSpecailDisease = table.Column<bool>(type: "bit", nullable: true),
                    HospitalTotalBill = table.Column<double>(type: "float", nullable: true),
                    ClaimRequetsDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClaimAmount = table.Column<double>(type: "float", nullable: true),
                    ClaimApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClaimApprovedAmount = table.Column<double>(type: "float", nullable: true),
                    ApprovedById = table.Column<long>(type: "bigint", nullable: true),
                    IsTaxable = table.Column<bool>(type: "bit", nullable: true),
                    IsTaxableByHr = table.Column<bool>(type: "bit", nullable: true),
                    IsPostHospitalization = table.Column<bool>(type: "bit", nullable: true),
                    PaymentAgainstExtraAdvance = table.Column<double>(type: "float", nullable: true),
                    PaymentRefNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeClaims_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaims_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeClaims_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    OrgPrimaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgUnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WrapperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostAssignedInWrapperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostAssignedInOrgUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkingAbbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpLavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true),
                    ApplicabelDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportingOfficerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpProfiles_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpProfiles_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpProfiles_Employees_ReportingOfficerId",
                        column: x => x.ReportingOfficerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpProfiles_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrgClaimLimits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    ApplicableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicableYear = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgClaimLimits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgClaimLimits_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrgClaimLimits_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpFamilys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationId = table.Column<long>(type: "bigint", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFamilys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpFamilys_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpFamilys_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpFamilys_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpFamilys_EmpRelations_RelationId",
                        column: x => x.RelationId,
                        principalTable: "EmpRelations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UploadTypeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    UploadTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadTypeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadTypeDetails_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadTypeDetails_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadTypeDetails_UplodDocType_UploadTypeId",
                        column: x => x.UploadTypeId,
                        principalTable: "UplodDocType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimClarification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpClaimId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Clarification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimClarification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimClarification_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimClarification_EmployeeClaims_EmpClaimId",
                        column: x => x.EmpClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimClarification_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClaimClarification_Employees_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClaimClarification_Employees_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClaimClarification_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorReviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    AddmisionAdviseComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DischargeSummaryComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationReportComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSpecialDisease = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxable = table.Column<bool>(type: "bit", nullable: true),
                    Comment_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReviews_EmployeeClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorReviews_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorReviews_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpClaimProcessDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpClaimProcessDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_EmployeeClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_Employees_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_Employees_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeClaimBills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpClaimId = table.Column<long>(type: "bigint", nullable: false),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    HospitalCompleteBill = table.Column<double>(type: "float", nullable: false),
                    MedicineBill = table.Column<double>(type: "float", nullable: false),
                    ConsultationBill = table.Column<double>(type: "float", nullable: false),
                    InvestigationBill = table.Column<double>(type: "float", nullable: false),
                    RoomRentBill = table.Column<double>(type: "float", nullable: false),
                    OthersBill = table.Column<double>(type: "float", nullable: true),
                    Procedure = table.Column<double>(type: "float", nullable: true),
                    MedicineClaim = table.Column<double>(type: "float", nullable: false),
                    ConsultationClaim = table.Column<double>(type: "float", nullable: false),
                    InvestigationClaim = table.Column<double>(type: "float", nullable: false),
                    RoomRentClaim = table.Column<double>(type: "float", nullable: false),
                    OtherClaim = table.Column<double>(type: "float", nullable: true),
                    ProcedureClaim = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClaimBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_ClaimStatusCategory_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ClaimStatusCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_EmployeeClaims_EmpClaimId",
                        column: x => x.EmpClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpPreHospitalization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpClaimId = table.Column<long>(type: "bigint", nullable: false),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    MedicineAmount = table.Column<double>(type: "float", nullable: false),
                    ConsultationAmount = table.Column<double>(type: "float", nullable: false),
                    InvestigationAmount = table.Column<double>(type: "float", nullable: false),
                    ProcedureAmount = table.Column<double>(type: "float", nullable: false),
                    OtherAmount = table.Column<double>(type: "float", nullable: true),
                    MedicineClaimAmount = table.Column<double>(type: "float", nullable: false),
                    ConsultationClaimAmount = table.Column<double>(type: "float", nullable: false),
                    InvestigationClaimAmount = table.Column<double>(type: "float", nullable: false),
                    ProcedureClaimAmount = table.Column<double>(type: "float", nullable: false),
                    OtherClaimAmount = table.Column<double>(type: "float", nullable: true),
                    MedicineClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultationClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvestigationClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcedureClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherClaimDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPreHospitalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPreHospitalization_EmployeeClaims_EmpId",
                        column: x => x.EmpId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpPreHospitalization_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPreHospitalization_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpAdvances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmplId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    RequestSubmittedById = table.Column<long>(type: "bigint", nullable: false),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    Claim_TypeId = table.Column<long>(type: "bigint", nullable: false),
                    RequestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvanceRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvanceAmount = table.Column<double>(type: "float", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikelyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedAmount = table.Column<double>(type: "float", nullable: true),
                    ApprovedById = table.Column<long>(type: "bigint", nullable: true),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalRegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateofDischarge = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedAmount = table.Column<double>(type: "float", nullable: false),
                    FinalHospitalBill = table.Column<double>(type: "float", nullable: false),
                    IsPreHospitalizationExpenses = table.Column<bool>(type: "bit", nullable: false),
                    Declaration = table.Column<bool>(type: "bit", nullable: true),
                    Digonosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHospitialEmpanpanelled = table.Column<bool>(type: "bit", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAdvances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAdvances_ClaimTypes_Claim_TypeId",
                        column: x => x.Claim_TypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAdvances_EmpFamilys_PatientId",
                        column: x => x.PatientId,
                        principalTable: "EmpFamilys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAdvances_EmployeeClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_EmplId",
                        column: x => x.EmplId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_RequestSubmittedById",
                        column: x => x.RequestSubmittedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpFamilyITRs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyId = table.Column<long>(type: "bigint", nullable: false),
                    DocType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountingYear = table.Column<long>(type: "bigint", nullable: false),
                    AnnualIncome = table.Column<double>(type: "float", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFamilyITRs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpFamilyITRs_EmpFamilys_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "EmpFamilys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpFamilyITRs_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpFamilyITRs_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpFamilyPANs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyId = table.Column<long>(type: "bigint", nullable: false),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFamilyPANs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpFamilyPANs_EmpFamilys_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "EmpFamilys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpFamilyPANs_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpFamilyPANs_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdvanceUploadClarificationforTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvanceUploadTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Clarification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceUploadClarificationforTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_Employees_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_Employees_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_UploadTypeDetails_AdvanceUploadTypeId",
                        column: x => x.AdvanceUploadTypeId,
                        principalTable: "UploadTypeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvanceUploadTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadDocuments_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadDocuments_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadDocuments_UploadTypeDetails_AdvanceUploadTypeId",
                        column: x => x.AdvanceUploadTypeId,
                        principalTable: "UploadTypeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpClaimNotInMainBills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimBillId = table.Column<long>(type: "bigint", nullable: false),
                    BillType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AmountClaim = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpClaimNotInMainBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMainBills_EmployeeClaimBills_ClaimBillId",
                        column: x => x.ClaimBillId,
                        principalTable: "EmployeeClaimBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMainBills_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMainBills_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeClaimBillApprovel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimBillId = table.Column<long>(type: "bigint", nullable: false),
                    MedicineAmount = table.Column<double>(type: "float", nullable: false),
                    ConsultationAmount = table.Column<double>(type: "float", nullable: false),
                    InvestigationAmount = table.Column<double>(type: "float", nullable: false),
                    RoomRentAmount = table.Column<double>(type: "float", nullable: false),
                    OtherAmount = table.Column<double>(type: "float", nullable: true),
                    ProcedureAmount = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClaimBillApprovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBillApprovel_EmployeeClaimBills_ClaimBillId",
                        column: x => x.ClaimBillId,
                        principalTable: "EmployeeClaimBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBillApprovel_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBillApprovel_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpPreHospitalizationApprovel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpPreHospitalzationId = table.Column<long>(type: "bigint", nullable: false),
                    MedicineAmount = table.Column<double>(type: "float", nullable: false),
                    ConsultationAmount = table.Column<double>(type: "float", nullable: false),
                    InvestigationAmount = table.Column<double>(type: "float", nullable: false),
                    ProcedureAmount = table.Column<double>(type: "float", nullable: false),
                    OtherAmount = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPreHospitalizationApprovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpPreHospitalizationApprovel_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPreHospitalizationApprovel_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpPreHospitalizationApprovel_EmpPreHospitalization_EmpPreHospitalzationId",
                        column: x => x.EmpPreHospitalzationId,
                        principalTable: "EmpPreHospitalization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpAdvanceTopUp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpAdvanceId = table.Column<long>(type: "bigint", nullable: false),
                    ReviseEstimentedAmount = table.Column<double>(type: "float", nullable: false),
                    TopRequiredAmount = table.Column<double>(type: "float", nullable: false),
                    TopApprovedAmount = table.Column<double>(type: "float", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedById = table.Column<long>(type: "bigint", nullable: true),
                    PayTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IfscCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAdvanceTopUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUp_EmpAdvances_EmpAdvanceId",
                        column: x => x.EmpAdvanceId,
                        principalTable: "EmpAdvances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUp_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUp_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUp_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HospitalAccountDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpAdvanceId = table.Column<long>(type: "bigint", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IfscCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalGSTNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalAccountDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalAccountDetails_EmpAdvances_EmpAdvanceId",
                        column: x => x.EmpAdvanceId,
                        principalTable: "EmpAdvances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalAccountDetails_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HospitalAccountDetails_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpClaimNotInMainBillApprovel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpClaimNotInMainBillId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpClaimNotInMainBillApprovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMainBillApprovel_EmpClaimNotInMainBills_EmpClaimNotInMainBillId",
                        column: x => x.EmpClaimNotInMainBillId,
                        principalTable: "EmpClaimNotInMainBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMainBillApprovel_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMainBillApprovel_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpAdvanceTopUpUpload",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpAdvanceTopUpId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAdvanceTopUpUpload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUpUpload_EmpAdvanceTopUp_EmpAdvanceTopUpId",
                        column: x => x.EmpAdvanceTopUpId,
                        principalTable: "EmpAdvanceTopUp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUpUpload_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUpUpload_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpClaimStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    EmpAdvanceTopId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpClaimStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_ClaimStatusCategory_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ClaimStatusCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_EmpAdvanceTopUp_EmpAdvanceTopId",
                        column: x => x.EmpAdvanceTopId,
                        principalTable: "EmpAdvanceTopUp",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_EmployeeClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ClaimTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4287), "Advance", true, "Advance" },
                    { 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4308), "AdvanceClaim", true, "Advance Claim" },
                    { 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4311), "DirectClaim", true, "Direct Claim" },
                    { 4L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4313), "Top Up Amount", true, "Top Up Amount" }
                });

            migrationBuilder.InsertData(
                table: "EmpRelations",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4604), "Father", true, "Father" },
                    { 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4608), "Mother", true, "Mother" },
                    { 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4610), "Son", true, "Son" },
                    { 4L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4612), "Daughter", true, "Daughter" },
                    { 6L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4614), "Spouse", true, "Spouse" },
                    { 7L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4616), "Self", true, "Self" }
                });

            migrationBuilder.InsertData(
                table: "UplodDocType",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsBillable", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4664), "Medicine", true, true, "Medicine" },
                    { 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4669), "Medicine not in Final bill", true, true, "Medicine not in Final bill" },
                    { 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4671), "Consultation", true, true, "Consultation" },
                    { 4L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4673), "Room Rent", true, true, "Room Rent" },
                    { 5L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4675), "Investigation", true, true, "Investigation" },
                    { 6L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4677), "Other", true, true, "Other" },
                    { 7L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4679), "ConsultationNotFinalBill", true, true, "ConsultationNotFinalBill" },
                    { 8L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4681), "InvestigationNotFinalBill", true, true, "InvestigationNotFinalBill" },
                    { 9L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4685), "OtherBillNotFinalBill", true, true, "OtherBillNotFinalBill" },
                    { 10L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4688), "AdmissionAdviceUpload", true, true, "AdmissionAdviceUpload" },
                    { 11L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4690), "DischargeSummary", true, true, "DischargeSummary" },
                    { 12L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4692), "InvestigationReports", true, true, "InvestigationReports" },
                    { 13L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4695), "FinalHospitalBill", true, true, "FinalHospitalBill" },
                    { 14L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4697), "Diagnosis", true, true, "Diagnosis" },
                    { 15L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4699), "PreHospitalizationExpensesMedicine", true, true, "PreHospitalizationExpensesMedicine" },
                    { 16L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4701), "PreHospitalizationExpensesConsultation", true, true, "PreHospitalizationExpensesConsultation" },
                    { 17L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4703), "PreHospitalizationExpensesInvestigation", true, true, "PreHospitalizationExpensesInvestigation" },
                    { 18L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4705), "PreHospitalizationExpensesOther", true, true, "PreHospitalizationExpensesOther" },
                    { 19L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4707), "EstimateAmount", true, true, "EstimateAmount" },
                    { 20L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4726), "ReviseEstimateFile", true, true, "ReviseEstimateFile" },
                    { 21L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4742), "HospitalRegstrationDetailsFile", true, true, "HospitalRegstrationDetailsFile" },
                    { 22L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4744), "HospitalIncomeTaxFile", true, true, "HospitalIncomeTaxFile" }
                });

            migrationBuilder.InsertData(
                table: "ClaimStatusCategory",
                columns: new[] { "Id", "ClaimTypeId", "CreatedDate", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4796), "Claim Initiated", true, "Claim Initiated" },
                    { 2L, 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4801), "Approved", true, "Approved" },
                    { 3L, 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4804), "HR Processing", true, "HR Processing" },
                    { 4L, 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4807), "Finance processing", true, "Finance processing" },
                    { 5L, 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4809), "Under Doctor Processing", true, "Under Doctor Processing" },
                    { 6L, 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4811), "Rejected", true, "Rejected" },
                    { 7L, 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4813), "Claim Initiated", true, "Claim Initiated" },
                    { 8L, 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4816), "Approved", true, "Approved" },
                    { 9L, 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4818), "HR Processing", true, "HR Processing" },
                    { 10L, 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4820), "Finance processing", true, "Finance processing" },
                    { 12L, 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4822), "Under Doctor Processing", true, "Under Doctor Processing" },
                    { 13L, 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4825), "Rejected", true, "Rejected" },
                    { 14L, 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4827), "Claim Initiated", true, "Claim Initiated" },
                    { 15L, 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4829), "Approved", true, "Approved" },
                    { 16L, 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4831), "HR Processing", true, "HR Processing" },
                    { 17L, 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4834), "Finance processing", true, "Finance processing" },
                    { 18L, 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4836), "Under Doctor Processing", true, "Under Doctor Processing" },
                    { 19L, 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4838), "Rejected", true, "Rejected" },
                    { 20L, 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4840), "Top Up Initiated", true, "Top Up Initiated" },
                    { 21L, 1L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4843), "Bill Passing", true, "Bill Passing" },
                    { 22L, 2L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4845), "Bill Passing", true, "Bill Passing" },
                    { 23L, 3L, new DateTime(2023, 10, 26, 22, 21, 12, 992, DateTimeKind.Local).AddTicks(4847), "Bill Passing", true, "Bill Passing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_AdvanceUploadTypeId",
                table: "AdvanceUploadClarificationforTypes",
                column: "AdvanceUploadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_CreatedBy",
                table: "AdvanceUploadClarificationforTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_RecipientId",
                table: "AdvanceUploadClarificationforTypes",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_SenderId",
                table: "AdvanceUploadClarificationforTypes",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_UpdatedBy",
                table: "AdvanceUploadClarificationforTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpId",
                table: "AspNetUsers",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimClarification_ClaimTypeId",
                table: "ClaimClarification",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimClarification_CreatedBy",
                table: "ClaimClarification",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimClarification_EmpClaimId",
                table: "ClaimClarification",
                column: "EmpClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimClarification_RecipientId",
                table: "ClaimClarification",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimClarification_SenderId",
                table: "ClaimClarification",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimClarification_UpdatedBy",
                table: "ClaimClarification",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusCategory_ClaimTypeId",
                table: "ClaimStatusCategory",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReviews_ClaimId",
                table: "DoctorReviews",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReviews_CreatedBy",
                table: "DoctorReviews",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReviews_UpdatedBy",
                table: "DoctorReviews",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAccountDetails_CreatedBy",
                table: "EmpAccountDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAccountDetails_EmpId",
                table: "EmpAccountDetails",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAccountDetails_UpdatedBy",
                table: "EmpAccountDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_ApprovedById",
                table: "EmpAdvances",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_Claim_TypeId",
                table: "EmpAdvances",
                column: "Claim_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_ClaimId",
                table: "EmpAdvances",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_CreatedBy",
                table: "EmpAdvances",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_EmplId",
                table: "EmpAdvances",
                column: "EmplId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_PatientId",
                table: "EmpAdvances",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_RequestSubmittedById",
                table: "EmpAdvances",
                column: "RequestSubmittedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_UpdatedBy",
                table: "EmpAdvances",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUp_ApprovedById",
                table: "EmpAdvanceTopUp",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUp_CreatedBy",
                table: "EmpAdvanceTopUp",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUp_EmpAdvanceId",
                table: "EmpAdvanceTopUp",
                column: "EmpAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUp_UpdatedBy",
                table: "EmpAdvanceTopUp",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUpUpload_CreatedBy",
                table: "EmpAdvanceTopUpUpload",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUpUpload_EmpAdvanceTopUpId",
                table: "EmpAdvanceTopUpUpload",
                column: "EmpAdvanceTopUpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUpUpload_UpdatedBy",
                table: "EmpAdvanceTopUpUpload",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMainBillApprovel_CreatedBy",
                table: "EmpClaimNotInMainBillApprovel",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMainBillApprovel_EmpClaimNotInMainBillId",
                table: "EmpClaimNotInMainBillApprovel",
                column: "EmpClaimNotInMainBillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMainBillApprovel_UpdatedBy",
                table: "EmpClaimNotInMainBillApprovel",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMainBills_ClaimBillId",
                table: "EmpClaimNotInMainBills",
                column: "ClaimBillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMainBills_CreatedBy",
                table: "EmpClaimNotInMainBills",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMainBills_UpdatedBy",
                table: "EmpClaimNotInMainBills",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_ClaimId",
                table: "EmpClaimProcessDetails",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_ClaimTypeId",
                table: "EmpClaimProcessDetails",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_CreatedBy",
                table: "EmpClaimProcessDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_RecipientId",
                table: "EmpClaimProcessDetails",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_SenderId",
                table: "EmpClaimProcessDetails",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_ClaimId",
                table: "EmpClaimStatus",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_ClaimTypeId",
                table: "EmpClaimStatus",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_CreatedBy",
                table: "EmpClaimStatus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_EmpAdvanceTopId",
                table: "EmpClaimStatus",
                column: "EmpAdvanceTopId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_StatusId",
                table: "EmpClaimStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_UpdatedBy",
                table: "EmpClaimStatus",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyITRs_CreatedBy",
                table: "EmpFamilyITRs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyITRs_FamilyId",
                table: "EmpFamilyITRs",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyITRs_UpdatedBy",
                table: "EmpFamilyITRs",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyPANs_CreatedBy",
                table: "EmpFamilyPANs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyPANs_FamilyId",
                table: "EmpFamilyPANs",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyPANs_UpdatedBy",
                table: "EmpFamilyPANs",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilys_CreatedBy",
                table: "EmpFamilys",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilys_EmpId",
                table: "EmpFamilys",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilys_RelationId",
                table: "EmpFamilys",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilys_UpdatedBy",
                table: "EmpFamilys",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBillApprovel_ClaimBillId",
                table: "EmployeeClaimBillApprovel",
                column: "ClaimBillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBillApprovel_CreatedBy",
                table: "EmployeeClaimBillApprovel",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBillApprovel_UpdatedBy",
                table: "EmployeeClaimBillApprovel",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_CreatedBy",
                table: "EmployeeClaimBills",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_EmpClaimId",
                table: "EmployeeClaimBills",
                column: "EmpClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_EmpId",
                table: "EmployeeClaimBills",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_StatusId",
                table: "EmployeeClaimBills",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_UpdatedBy",
                table: "EmployeeClaimBills",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaims_ApprovedById",
                table: "EmployeeClaims",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaims_CreatedBy",
                table: "EmployeeClaims",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaims_UpdatedBy",
                table: "EmployeeClaims",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UpdatedBy",
                table: "Employees",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPreHospitalization_CreatedBy",
                table: "EmpPreHospitalization",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPreHospitalization_EmpId",
                table: "EmpPreHospitalization",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPreHospitalization_UpdatedBy",
                table: "EmpPreHospitalization",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPreHospitalizationApprovel_CreatedBy",
                table: "EmpPreHospitalizationApprovel",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPreHospitalizationApprovel_EmpPreHospitalzationId",
                table: "EmpPreHospitalizationApprovel",
                column: "EmpPreHospitalzationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpPreHospitalizationApprovel_UpdatedBy",
                table: "EmpPreHospitalizationApprovel",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_CreatedBy",
                table: "EmpProfiles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_EmpId",
                table: "EmpProfiles",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_ReportingOfficerId",
                table: "EmpProfiles",
                column: "ReportingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_UpdatedBy",
                table: "EmpProfiles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAccountDetails_CreatedBy",
                table: "HospitalAccountDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAccountDetails_EmpAdvanceId",
                table: "HospitalAccountDetails",
                column: "EmpAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAccountDetails_UpdatedBy",
                table: "HospitalAccountDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrgClaimLimits_CreatedBy",
                table: "OrgClaimLimits",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrgClaimLimits_UpdatedBy",
                table: "OrgClaimLimits",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_AdvanceUploadTypeId",
                table: "UploadDocuments",
                column: "AdvanceUploadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_CreatedBy",
                table: "UploadDocuments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_UpdatedBy",
                table: "UploadDocuments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadTypeDetails_CreatedBy",
                table: "UploadTypeDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadTypeDetails_UpdatedBy",
                table: "UploadTypeDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadTypeDetails_UploadTypeId",
                table: "UploadTypeDetails",
                column: "UploadTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvanceUploadClarificationforTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClaimClarification");

            migrationBuilder.DropTable(
                name: "DoctorReviews");

            migrationBuilder.DropTable(
                name: "EmpAccountDetails");

            migrationBuilder.DropTable(
                name: "EmpAdvanceTopUpUpload");

            migrationBuilder.DropTable(
                name: "EmpClaimNotInMainBillApprovel");

            migrationBuilder.DropTable(
                name: "EmpClaimProcessDetails");

            migrationBuilder.DropTable(
                name: "EmpClaimStatus");

            migrationBuilder.DropTable(
                name: "EmpFamilyITRs");

            migrationBuilder.DropTable(
                name: "EmpFamilyPANs");

            migrationBuilder.DropTable(
                name: "EmployeeClaimBillApprovel");

            migrationBuilder.DropTable(
                name: "EmpPreHospitalizationApprovel");

            migrationBuilder.DropTable(
                name: "EmpProfiles");

            migrationBuilder.DropTable(
                name: "HospitalAccountDetails");

            migrationBuilder.DropTable(
                name: "OrgClaimLimits");

            migrationBuilder.DropTable(
                name: "UploadDocuments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EmpClaimNotInMainBills");

            migrationBuilder.DropTable(
                name: "EmpAdvanceTopUp");

            migrationBuilder.DropTable(
                name: "EmpPreHospitalization");

            migrationBuilder.DropTable(
                name: "UploadTypeDetails");

            migrationBuilder.DropTable(
                name: "EmployeeClaimBills");

            migrationBuilder.DropTable(
                name: "EmpAdvances");

            migrationBuilder.DropTable(
                name: "UplodDocType");

            migrationBuilder.DropTable(
                name: "ClaimStatusCategory");

            migrationBuilder.DropTable(
                name: "EmpFamilys");

            migrationBuilder.DropTable(
                name: "EmployeeClaims");

            migrationBuilder.DropTable(
                name: "ClaimTypes");

            migrationBuilder.DropTable(
                name: "EmpRelations");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
