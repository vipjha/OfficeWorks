using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class _updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(7187), "Pending Approval", "Pending Approval" });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(7191), "Finance Processing", "Finance Processing" });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(7168), "Advance" });

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(7170), "Advance Claim" });

            migrationBuilder.InsertData(
                table: "ClaimTypes",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name" },
                values: new object[] { 3L, new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(7171), true, "Claim" });

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 12, 45, 14, 188, DateTimeKind.Local).AddTicks(7004));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(1201), "Claim Initiated", "Claim Initiated" });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(1204), "HR Processing", "HR Processing" });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.InsertData(
                table: "ClaimStatusCategorys",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name" },
                values: new object[] { 4L, new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(1206), "Finance processing", true, "Finance processing" });

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(1176), "Travel Claim" });

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(1178), "Accommodation Claim" });

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(930));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 11, 39, 31, 911, DateTimeKind.Local).AddTicks(945));
        }
    }
}
