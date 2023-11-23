using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourProgram.DAL.Migrations
{
    public partial class TransportionAndAccomondationUploads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccomodationDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfCheckIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfCheckOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassOfCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFreeAccomodation = table.Column<bool>(type: "bit", nullable: false),
                    BilledAmount = table.Column<double>(type: "float", nullable: false),
                    ClaimedAmount = table.Column<double>(type: "float", nullable: false),
                    ApprovedAmount = table.Column<double>(type: "float", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomodationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccomodationDetails_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimClarifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
                    TransportationClarification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccomodationClarification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DAClarification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveClarification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReciverId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimClarifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimClarifications_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DADetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfWorkIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfWorkIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfWorkOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfWorkOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAPercentageAdmissible = table.Column<double>(type: "float", nullable: false),
                    DAAmount = table.Column<double>(type: "float", nullable: false),
                    DAApprovedAmount = table.Column<double>(type: "float", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DADetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DADetails_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfLeaveIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfLeaveIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfLeaveOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfLeaveOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDADeductable = table.Column<bool>(type: "bit", nullable: false),
                    DADeductableAmount = table.Column<double>(type: "float", nullable: false),
                    DADeductableApprovedAmount = table.Column<double>(type: "float", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveDetails_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportationDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTourPlanId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfTravelSource = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfTravelSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeOfTravel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfTravelDestination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfTravelDestiNation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BilledAmount = table.Column<double>(type: "float", nullable: false),
                    ClaimedAmount = table.Column<double>(type: "float", nullable: false),
                    ApprovedAmount = table.Column<double>(type: "float", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationDetails_EmpTourPlans_EmpTourPlanId",
                        column: x => x.EmpTourPlanId,
                        principalTable: "EmpTourPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccomodationUploads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccomodationDetailsId = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomodationUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccomodationUploads_AccomodationDetails_AccomodationDetailsId",
                        column: x => x.AccomodationDetailsId,
                        principalTable: "AccomodationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportationUploads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportationDetailsId = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationUploads_TransportationDetails_TransportationDetailsId",
                        column: x => x.TransportationDetailsId,
                        principalTable: "TransportationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategorys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "UploadDocTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 9, 14, 48, 4, 220, DateTimeKind.Local).AddTicks(4544));

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationDetails_EmpTourPlanId",
                table: "AccomodationDetails",
                column: "EmpTourPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationUploads_AccomodationDetailsId",
                table: "AccomodationUploads",
                column: "AccomodationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimClarifications_EmpTourPlanId",
                table: "ClaimClarifications",
                column: "EmpTourPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DADetails_EmpTourPlanId",
                table: "DADetails",
                column: "EmpTourPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveDetails_EmpTourPlanId",
                table: "LeaveDetails",
                column: "EmpTourPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationDetails_EmpTourPlanId",
                table: "TransportationDetails",
                column: "EmpTourPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationUploads_TransportationDetailsId",
                table: "TransportationUploads",
                column: "TransportationDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccomodationUploads");

            migrationBuilder.DropTable(
                name: "ClaimClarifications");

            migrationBuilder.DropTable(
                name: "DADetails");

            migrationBuilder.DropTable(
                name: "LeaveDetails");

            migrationBuilder.DropTable(
                name: "TransportationUploads");

            migrationBuilder.DropTable(
                name: "AccomodationDetails");

            migrationBuilder.DropTable(
                name: "TransportationDetails");

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
        }
    }
}
