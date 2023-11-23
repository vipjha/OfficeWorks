using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class EmpProcessTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ClaimStatusCategorys");

            migrationBuilder.CreateTable(
                name: "EMPClaimProcessDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourId = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPClaimProcessDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMPClaimProcessDetails_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMPClaimProcessDetails_EmpTourPlans_EmpTourId",
                        column: x => x.EmpTourId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 6, 13, 24, 3, 57, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.CreateIndex(
                name: "IX_EMPClaimProcessDetails_ClaimTypeId",
                table: "EMPClaimProcessDetails",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPClaimProcessDetails_EmpTourId",
                table: "EMPClaimProcessDetails",
                column: "EmpTourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPClaimProcessDetails");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ClaimStatusCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Type" },
                values: new object[] { new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9827), 1 });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "Type" },
                values: new object[] { new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9837), 1 });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "Type" },
                values: new object[] { new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9845), 1 });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedDate", "Type" },
                values: new object[] { new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9851), 1 });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedDate", "Type" },
                values: new object[] { new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9858), 1 });

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9696));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(8667));
        }
    }
}
