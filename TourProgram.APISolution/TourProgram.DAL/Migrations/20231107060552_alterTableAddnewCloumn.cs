using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class alterTableAddnewCloumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "EMPClaimProcessDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 35, 52, 35, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.CreateIndex(
                name: "IX_EMPClaimProcessDetails_StatusId",
                table: "EMPClaimProcessDetails",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_EMPClaimProcessDetails_ClaimStatusCategorys_StatusId",
                table: "EMPClaimProcessDetails",
                column: "StatusId",
                principalTable: "ClaimStatusCategorys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPClaimProcessDetails_ClaimStatusCategorys_StatusId",
                table: "EMPClaimProcessDetails");

            migrationBuilder.DropIndex(
                name: "IX_EMPClaimProcessDetails_StatusId",
                table: "EMPClaimProcessDetails");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "EMPClaimProcessDetails");

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
        }
    }
}
