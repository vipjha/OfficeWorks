using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class updateseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2565));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.InsertData(
                table: "ClaimStatusCategory",
                columns: new[] { "Id", "ClaimTypeId", "CreatedDate", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 21L, 1L, new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2579), "Bill Passing", true, "Bill Passing" },
                    { 22L, 2L, new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2580), "Bill Passing", true, "Bill Passing" },
                    { 23L, 3L, new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2581), "Bill Passing", true, "Bill Passing" }
                });

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2426));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 16, 12, 32, 351, DateTimeKind.Local).AddTicks(2463));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 22, 13, 54, 19, 635, DateTimeKind.Local).AddTicks(7346));
        }
    }
}
