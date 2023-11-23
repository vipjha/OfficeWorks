using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alterTableModifyFiled3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimClarification_EmployeeClaims_EmpClaimId",
                table: "ClaimClarification");

            migrationBuilder.RenameColumn(
                name: "EmpClaimId",
                table: "ClaimClarification",
                newName: "EmpAdvanceId");

            migrationBuilder.RenameColumn(
                name: "Clarification",
                table: "ClaimClarification",
                newName: "ClarificationValue");

            migrationBuilder.RenameIndex(
                name: "IX_ClaimClarification_EmpClaimId",
                table: "ClaimClarification",
                newName: "IX_ClaimClarification_EmpAdvanceId");

            migrationBuilder.AddColumn<string>(
                name: "ClarificationKey",
                table: "ClaimClarification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 22, 2, 24, 434, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimClarification_EmpAdvances_EmpAdvanceId",
                table: "ClaimClarification",
                column: "EmpAdvanceId",
                principalTable: "EmpAdvances",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimClarification_EmpAdvances_EmpAdvanceId",
                table: "ClaimClarification");

            migrationBuilder.DropColumn(
                name: "ClarificationKey",
                table: "ClaimClarification");

            migrationBuilder.RenameColumn(
                name: "EmpAdvanceId",
                table: "ClaimClarification",
                newName: "EmpClaimId");

            migrationBuilder.RenameColumn(
                name: "ClarificationValue",
                table: "ClaimClarification",
                newName: "Clarification");

            migrationBuilder.RenameIndex(
                name: "IX_ClaimClarification_EmpAdvanceId",
                table: "ClaimClarification",
                newName: "IX_ClaimClarification_EmpClaimId");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7339));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 21, 18, 44, 355, DateTimeKind.Local).AddTicks(7406));

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimClarification_EmployeeClaims_EmpClaimId",
                table: "ClaimClarification",
                column: "EmpClaimId",
                principalTable: "EmployeeClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
