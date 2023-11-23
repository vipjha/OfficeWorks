using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class EmployeeRelatedTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<long>(
                name: "EmpId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpProfiles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpId",
                table: "AspNetUsers",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UpdatedBy",
                table: "Employees",
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
                name: "IX_EmpProfiles_RoleId",
                table: "EmpProfiles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_UpdatedBy",
                table: "EmpProfiles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrgClaimLimits_CreatedBy",
                table: "OrgClaimLimits",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrgClaimLimits_UpdatedBy",
                table: "OrgClaimLimits",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmpId",
                table: "AspNetUsers",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employees_EmpId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EmpProfiles");

            migrationBuilder.DropTable(
                name: "OrgClaimLimits");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmpId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
