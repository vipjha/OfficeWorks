using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class UploadDocumentClaimTypeGradeDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLiquidation",
                table: "EmpTourPlans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdvanceLiquidated",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LiquiDationBy",
                table: "EmpTourPlans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClaimStatusCategorys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatusCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    X = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Y = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Z = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadDocTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBillable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadDocTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadTypeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_UploadTypeDetails_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadTypeDetails_UploadDocTypes_UploadTypeId",
                        column: x => x.UploadTypeId,
                        principalTable: "UploadDocTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadTypeDetailsId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_UploadDocuments_UploadTypeDetails_UploadTypeDetailsId",
                        column: x => x.UploadTypeDetailsId,
                        principalTable: "UploadTypeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_UploadTypeDetailsId",
                table: "UploadDocuments",
                column: "UploadTypeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadTypeDetails_EmpTourPlanId",
                table: "UploadTypeDetails",
                column: "EmpTourPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadTypeDetails_UploadTypeId",
                table: "UploadTypeDetails",
                column: "UploadTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimStatusCategorys");

            migrationBuilder.DropTable(
                name: "ClaimTypes");

            migrationBuilder.DropTable(
                name: "GradeDetails");

            migrationBuilder.DropTable(
                name: "UploadDocuments");

            migrationBuilder.DropTable(
                name: "UploadTypeDetails");

            migrationBuilder.DropTable(
                name: "UploadDocTypes");

            migrationBuilder.DropColumn(
                name: "DateOfLiquidation",
                table: "EmpTourPlans");

            migrationBuilder.DropColumn(
                name: "IsAdvanceLiquidated",
                table: "EmpTourPlans");

            migrationBuilder.DropColumn(
                name: "LiquiDationBy",
                table: "EmpTourPlans");
        }
    }
}
