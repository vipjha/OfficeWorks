using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alteree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "EmpProfiles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 375, DateTimeKind.Local).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 375, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 375, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 375, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(158));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 28, 12, 9, 0, 376, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_RoleId",
                table: "EmpProfiles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpProfiles_AspNetRoles_RoleId",
                table: "EmpProfiles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpProfiles_AspNetRoles_RoleId",
                table: "EmpProfiles");

            migrationBuilder.DropIndex(
                name: "IX_EmpProfiles_RoleId",
                table: "EmpProfiles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "EmpProfiles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(360));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(365));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(465));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(466));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(477));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 24L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 25L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 27, 23, 56, 1, 675, DateTimeKind.Local).AddTicks(512));
        }
    }
}
