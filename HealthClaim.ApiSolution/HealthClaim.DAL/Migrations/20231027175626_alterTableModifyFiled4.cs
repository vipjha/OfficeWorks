using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alterTableModifyFiled4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "EmpAdvanceTopUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalGSTNumber",
                table: "EmpAdvanceTopUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(33));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 591, DateTimeKind.Local).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9918));

            migrationBuilder.InsertData(
                table: "UplodDocType",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsBillable", "Name" },
                values: new object[] { 25L, new DateTime(2023, 10, 27, 23, 26, 25, 590, DateTimeKind.Local).AddTicks(9919), "PostHospitalTreatmentAdviseUpload", true, true, "PostHospitalTreatmentAdviseUpload" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "EmpAdvanceTopUp");

            migrationBuilder.DropColumn(
                name: "HospitalGSTNumber",
                table: "EmpAdvanceTopUp");

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
        }
    }
}
