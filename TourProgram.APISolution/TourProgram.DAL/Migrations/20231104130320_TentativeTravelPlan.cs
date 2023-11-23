using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class TentativeTravelPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDirectClaim",
                table: "EmpTourPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "PaidAmount",
                table: "EmpTourPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PaymentReferenceNo",
                table: "EmpTourPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ActualTravelPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassOfCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualTravelPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualTravelPlans_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TentativeTravelPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassOfCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TentativeTravelPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TentativeTravelPlans_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualTravelPlans_EmpTourPlanId",
                table: "ActualTravelPlans",
                column: "EmpTourPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TentativeTravelPlans_EmpTourPlanId",
                table: "TentativeTravelPlans",
                column: "EmpTourPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualTravelPlans");

            migrationBuilder.DropTable(
                name: "TentativeTravelPlans");

            migrationBuilder.DropColumn(
                name: "IsDirectClaim",
                table: "EmpTourPlans");

            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "EmpTourPlans");

            migrationBuilder.DropColumn(
                name: "PaymentReferenceNo",
                table: "EmpTourPlans");
        }
    }
}
