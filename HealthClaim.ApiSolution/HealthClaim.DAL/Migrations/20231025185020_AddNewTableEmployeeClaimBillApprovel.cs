using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class AddNewTableEmployeeClaimBillApprovel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeClaimBillApprovel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpClaimBilId = table.Column<long>(type: "bigint", nullable: false),
                    MedicineApprove = table.Column<double>(type: "float", nullable: false),
                    ConsultationApprove = table.Column<double>(type: "float", nullable: false),
                    InvestigationApprove = table.Column<double>(type: "float", nullable: false),
                    RoomRentApprove = table.Column<double>(type: "float", nullable: false),
                    OtherApprove = table.Column<double>(type: "float", nullable: true),
                    ProcedureApprove = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClaimBillApprovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBillApprovel_EmployeeClaimBills_EmpClaimBilId",
                        column: x => x.EmpClaimBilId,
                        principalTable: "EmployeeClaimBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBillApprovel_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBillApprovel_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 23L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1307));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 26, 0, 20, 19, 230, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBillApprovel_CreatedBy",
                table: "EmployeeClaimBillApprovel",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBillApprovel_EmpClaimBilId",
                table: "EmployeeClaimBillApprovel",
                column: "EmpClaimBilId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBillApprovel_UpdatedBy",
                table: "EmployeeClaimBillApprovel",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeClaimBillApprovel");

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
    }
}
