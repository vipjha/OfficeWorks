using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class UpdateRequireAndNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UploadDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsBillable",
                table: "UploadDocTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "TourDetails",
                table: "TentativeTravelPlans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassOfCity",
                table: "TentativeTravelPlans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "TravelEstimateAmount",
                table: "EmpTourPlans",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "PaymentReferenceNo",
                table: "EmpTourPlans",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "PaidAmount",
                table: "EmpTourPlans",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsZ",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsY",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsX",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRoad",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRail",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDirectClaim",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAir",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedBy",
                table: "EmpTourPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "ApprovedAmount",
                table: "EmpTourPlans",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "AdvanceRequired",
                table: "EmpTourPlans",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "AccomodationEstimate",
                table: "EmpTourPlans",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdvanceRequired",
                table: "EmpTourPlans",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ClaimStatusCategorys",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TourDetails",
                table: "ActualTravelPlans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassOfCity",
                table: "ActualTravelPlans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ClaimStatusCategorys",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9827), "Claim Initiated", true, "Claim Initiated", 1 },
                    { 2L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9837), "Approved", true, "Approved", 1 },
                    { 3L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9845), "HR Processing", true, "HR Processing", 1 },
                    { 4L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9851), "Finance processing", true, "Finance processing", 1 },
                    { 5L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9858), "Rejected", true, "Rejected", 1 }
                });

            migrationBuilder.InsertData(
                table: "ClaimTypes",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9696), true, "Travel Claim" },
                    { 2L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(9710), true, "Accommodation Claim" }
                });

            migrationBuilder.InsertData(
                table: "UploadDocTypes",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsBillable", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(8630), true, true, "Travel" },
                    { 2L, new DateTime(2023, 11, 5, 22, 14, 37, 648, DateTimeKind.Local).AddTicks(8667), true, true, "Accommodation" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "IsAdvanceRequired",
                table: "EmpTourPlans");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "UploadDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsBillable",
                table: "UploadDocTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TourDetails",
                table: "TentativeTravelPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassOfCity",
                table: "TentativeTravelPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TravelEstimateAmount",
                table: "EmpTourPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PaymentReferenceNo",
                table: "EmpTourPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PaidAmount",
                table: "EmpTourPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsZ",
                table: "EmpTourPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsY",
                table: "EmpTourPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsX",
                table: "EmpTourPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRoad",
                table: "EmpTourPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRail",
                table: "EmpTourPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDirectClaim",
                table: "EmpTourPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAir",
                table: "EmpTourPlans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedBy",
                table: "EmpTourPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ApprovedAmount",
                table: "EmpTourPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AdvanceRequired",
                table: "EmpTourPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "AccomodationEstimate",
                table: "EmpTourPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ClaimStatusCategorys",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TourDetails",
                table: "ActualTravelPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassOfCity",
                table: "ActualTravelPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
