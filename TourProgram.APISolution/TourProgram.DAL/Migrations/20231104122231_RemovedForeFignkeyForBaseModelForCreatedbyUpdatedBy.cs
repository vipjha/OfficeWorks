using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class RemovedForeFignkeyForBaseModelForCreatedbyUpdatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_CreatedBy",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_UpdatedBy",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpProfiles_Employees_CreatedBy",
                table: "EmpProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpProfiles_Employees_ReportingOfficerId",
                table: "EmpProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpProfiles_Employees_UpdatedBy",
                table: "EmpProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpTourPlans_Employees_CreatedBy",
                table: "EmpTourPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpTourPlans_Employees_UpdatedBy",
                table: "EmpTourPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgClaimLimits_Employees_CreatedBy",
                table: "OrgClaimLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgClaimLimits_Employees_UpdatedBy",
                table: "OrgClaimLimits");

            migrationBuilder.DropIndex(
                name: "IX_OrgClaimLimits_CreatedBy",
                table: "OrgClaimLimits");

            migrationBuilder.DropIndex(
                name: "IX_OrgClaimLimits_UpdatedBy",
                table: "OrgClaimLimits");

            migrationBuilder.DropIndex(
                name: "IX_EmpTourPlans_CreatedBy",
                table: "EmpTourPlans");

            migrationBuilder.DropIndex(
                name: "IX_EmpTourPlans_UpdatedBy",
                table: "EmpTourPlans");

            migrationBuilder.DropIndex(
                name: "IX_EmpProfiles_CreatedBy",
                table: "EmpProfiles");

            migrationBuilder.DropIndex(
                name: "IX_EmpProfiles_ReportingOfficerId",
                table: "EmpProfiles");

            migrationBuilder.DropIndex(
                name: "IX_EmpProfiles_UpdatedBy",
                table: "EmpProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UpdatedBy",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrgClaimLimits_CreatedBy",
                table: "OrgClaimLimits",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrgClaimLimits_UpdatedBy",
                table: "OrgClaimLimits",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpTourPlans_CreatedBy",
                table: "EmpTourPlans",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpTourPlans_UpdatedBy",
                table: "EmpTourPlans",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_CreatedBy",
                table: "EmpProfiles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_ReportingOfficerId",
                table: "EmpProfiles",
                column: "ReportingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_UpdatedBy",
                table: "EmpProfiles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UpdatedBy",
                table: "Employees",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_CreatedBy",
                table: "Employees",
                column: "CreatedBy",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_UpdatedBy",
                table: "Employees",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpProfiles_Employees_CreatedBy",
                table: "EmpProfiles",
                column: "CreatedBy",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpProfiles_Employees_ReportingOfficerId",
                table: "EmpProfiles",
                column: "ReportingOfficerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpProfiles_Employees_UpdatedBy",
                table: "EmpProfiles",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpTourPlans_Employees_CreatedBy",
                table: "EmpTourPlans",
                column: "CreatedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpTourPlans_Employees_UpdatedBy",
                table: "EmpTourPlans",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgClaimLimits_Employees_CreatedBy",
                table: "OrgClaimLimits",
                column: "CreatedBy",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgClaimLimits_Employees_UpdatedBy",
                table: "OrgClaimLimits",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
