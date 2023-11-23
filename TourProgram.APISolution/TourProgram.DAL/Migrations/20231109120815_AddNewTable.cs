using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class AddNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtpCodeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtpCode = table.Column<int>(type: "int", nullable: false),
                    Senttime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedByEmpId = table.Column<int>(type: "int", nullable: false),
                    IsOtpVerify = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpCodeDetails", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(5829));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 17, 38, 15, 87, DateTimeKind.Local).AddTicks(5841));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtpCodeDetails");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3203));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3206));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3179));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 16, 49, 41, 111, DateTimeKind.Local).AddTicks(3021));
        }
    }
}
