using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alterTable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "HospitalAccountDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalGSTNumber",
                table: "HospitalAccountDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8124));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 21, 23, 52, 543, DateTimeKind.Local).AddTicks(8084));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "HospitalAccountDetails");

            migrationBuilder.DropColumn(
                name: "HospitalGSTNumber",
                table: "HospitalAccountDetails");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(336));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(544));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(584));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(585));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 20, 25, 31, 765, DateTimeKind.Local).AddTicks(619));
        }
    }
}
