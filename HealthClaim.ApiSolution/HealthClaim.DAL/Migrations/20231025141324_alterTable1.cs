using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alterTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IPostHospitalization",
                table: "EmployeeClaims",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "OthersBill",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "ConsultationClaim",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InvestigationClaim",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MedicineClaim",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OtherClaim",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Procedure",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProcedureClaim",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RoomRentClaim",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AmountCliam",
                table: "EmpClaimNotInMailBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 19, 43, 23, 596, DateTimeKind.Local).AddTicks(9231));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPostHospitalization",
                table: "EmployeeClaims");

            migrationBuilder.DropColumn(
                name: "ConsultationClaim",
                table: "EmployeeClaimBills");

            migrationBuilder.DropColumn(
                name: "InvestigationClaim",
                table: "EmployeeClaimBills");

            migrationBuilder.DropColumn(
                name: "MedicineClaim",
                table: "EmployeeClaimBills");

            migrationBuilder.DropColumn(
                name: "OtherClaim",
                table: "EmployeeClaimBills");

            migrationBuilder.DropColumn(
                name: "Procedure",
                table: "EmployeeClaimBills");

            migrationBuilder.DropColumn(
                name: "ProcedureClaim",
                table: "EmployeeClaimBills");

            migrationBuilder.DropColumn(
                name: "RoomRentClaim",
                table: "EmployeeClaimBills");

            migrationBuilder.DropColumn(
                name: "AmountCliam",
                table: "EmpClaimNotInMailBills");

            migrationBuilder.AlterColumn<double>(
                name: "OthersBill",
                table: "EmployeeClaimBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4202));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4210));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 25, 18, 49, 33, 944, DateTimeKind.Local).AddTicks(4088));
        }
    }
}
