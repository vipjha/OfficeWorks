using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class EmpTourPlanAddedNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpTourPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    PurposeOfTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TantetiveDateOfDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfDays = table.Column<int>(type: "int", nullable: false),
                    IsRoad = table.Column<bool>(type: "bit", nullable: false),
                    IsRail = table.Column<bool>(type: "bit", nullable: false),
                    IsAir = table.Column<bool>(type: "bit", nullable: false),
                    ClassOfCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelEstimateAmount = table.Column<double>(type: "float", nullable: false),
                    AccomodationEstimate = table.Column<double>(type: "float", nullable: false),
                    AdvanceRequired = table.Column<double>(type: "float", nullable: false),
                    ApprovedAmount = table.Column<double>(type: "float", nullable: false),
                    IsX = table.Column<bool>(type: "bit", nullable: false),
                    IsY = table.Column<bool>(type: "bit", nullable: false),
                    IsZ = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpTourPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpTourPlans_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpTourPlans_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpTourPlans_CreatedBy",
                table: "EmpTourPlans",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpTourPlans_UpdatedBy",
                table: "EmpTourPlans",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpTourPlans");
        }
    }
}
