using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class ApprovedDateNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "EmpTourPlans",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "FinanceDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsLiquidation = table.Column<bool>(type: "bit", nullable: false),
                    SapReferenceNoPaymentApproval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SapReferenceDatePaymentApproval = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SapReferenceNoLiquidation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SapReferenceDateLiquidation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SapReferenceNoPaymentProcessing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SapReferenceDatePaymentProcessing = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LiquidationAmount = table.Column<double>(type: "float", nullable: true),
                    ApprovedAmount = table.Column<double>(type: "float", nullable: true),
                    PaidAmount = table.Column<double>(type: "float", nullable: true),
                    UTRNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UTRProcessDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinanceDetails_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinanceDetails_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(5081));

            //migrationBuilder.InsertData(
            //    table: "GradeDetails",
            //    columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "Lavel", "UpdatedBy", "UpdatedDate", "X", "Y", "Z" },
            //    values: new object[,]
            //    {
            //        { 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "MD", null, null, "Ashoka Hotel Suite", "90% of the rate of Ashoka Hotel Suite", "80% of the rate of Ashoka Hotel Suite" },
            //        { 2L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Director", null, null, "Ashoka Hotel Suite", "90% of the rate of Ashoka Hotel Suite", "80% of the rate of Ashoka Hotel Suite" },
            //        { 3L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "ED", null, null, "10000", "9000", "7500" },
            //        { 4L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "GGM", null, null, "10000", "9000", "7500" },
            //        { 5L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "GM", null, null, "10000", "9000", "7500" },
            //        { 6L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "AGM", null, null, "75000", "6000", "5000" },
            //        { 7L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "JGM", null, null, "75000", "6000", "5000" },
            //        { 8L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "DGM", null, null, "6000", "5000", "4000" },
            //        { 9L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Jr.Mgr", null, null, "3000", "2500", "2000" },
            //        { 10L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mgr", null, null, "3000", "2500", "2000" },
            //        { 11L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sr.Exe", null, null, "2200", "2000", "1000" },
            //        { 12L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Exe", null, null, "2200", "2000", "1000" },
            //        { 13L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "N5", null, null, "1500", " 1300", "800" },
            //        { 14L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "N6", null, null, "1500", "1300", "800" },
            //        { 15L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "N7", null, null, "1500", "1300", "800" },
            //        { 16L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "N1", null, null, "1000", "800", "500" },
            //        { 17L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "N2", null, null, "1000", "800", "500" },
            //        { 18L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "N3", null, null, "1000", "800", "500" },
            //        { 19L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "N4", null, null, "1000", "800", "500" }
            //    });

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 13, 3, 33, 796, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.CreateIndex(
                name: "IX_FinanceDetails_ClaimTypeId",
                table: "FinanceDetails",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceDetails_EmpTourPlanId",
                table: "FinanceDetails",
                column: "EmpTourPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceDetails");

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "GradeDetails",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovedDate",
                table: "EmpTourPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 7, 15, 0, 34, 338, DateTimeKind.Local).AddTicks(8490));
        }
    }
}
