using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class AlterTableOtpCode1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "OtpCode",
                table: "OtpCodeDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 40, 3, 466, DateTimeKind.Local).AddTicks(8339));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OtpCode",
                table: "OtpCodeDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 18, 6, 45, 268, DateTimeKind.Local).AddTicks(3189));
        }
    }
}
