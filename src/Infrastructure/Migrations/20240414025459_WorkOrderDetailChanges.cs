using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkOrderDetailChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Worker_WorkerId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_ProjectDetailId_ServiceId_WorkerId_Dates",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_ProjectId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_WorkerId",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "IsCleaningService",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "IsProcessingService",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "IsReceivingService",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "IsWarehouseService",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "ModifiedStartDate",
                table: "WorkOrder",
                newName: "ActualStartDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedEndDate",
                table: "WorkOrder",
                newName: "ActualEndDate");

            migrationBuilder.AddColumn<int>(
                name: "ReportStaffId",
                table: "WorkOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReportToStaff",
                table: "WorkOrder",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "WorkOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStaff",
                table: "Contact",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    HoursAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ScheduledStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportToStaff = table.Column<bool>(type: "bit", nullable: true),
                    ReportStaffId = table.Column<int>(type: "int", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    WorkerSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderDetail_Contact_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderDetail_WorkOrder_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrderDetail_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ProjectDetailId",
                table: "WorkOrder",
                column: "ProjectDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ProjectId_ProjectDetailId_ServiceId",
                table: "WorkOrder",
                columns: new[] { "ProjectId", "ProjectDetailId", "ServiceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_StaffId",
                table: "WorkOrder",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceTypeId",
                table: "Service",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderDetail_Id",
                table: "WorkOrderDetail",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderDetail_StaffId",
                table: "WorkOrderDetail",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderDetail_WorkerId",
                table: "WorkOrderDetail",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderDetail_WorkOrderId_WorkerId",
                table: "WorkOrderDetail",
                columns: new[] { "WorkOrderId", "WorkerId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceType_ServiceTypeId",
                table: "Service",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Contact_StaffId",
                table: "WorkOrder",
                column: "StaffId",
                principalTable: "Contact",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceType_ServiceTypeId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Contact_StaffId",
                table: "WorkOrder");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "WorkOrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_ProjectDetailId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_ProjectId_ProjectDetailId_ServiceId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_StaffId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_Service_ServiceTypeId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ReportStaffId",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "ReportToStaff",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "IsStaff",
                table: "Contact");

            migrationBuilder.RenameColumn(
                name: "ActualStartDate",
                table: "WorkOrder",
                newName: "ModifiedStartDate");

            migrationBuilder.RenameColumn(
                name: "ActualEndDate",
                table: "WorkOrder",
                newName: "ModifiedEndDate");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "WorkOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCleaningService",
                table: "Service",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsProcessingService",
                table: "Service",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReceivingService",
                table: "Service",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWarehouseService",
                table: "Service",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ProjectDetailId_ServiceId_WorkerId",
                table: "WorkOrder",
                columns: new[] { "ProjectDetailId", "ServiceId", "WorkerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ProjectId",
                table: "WorkOrder",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_WorkerId",
                table: "WorkOrder",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Worker_WorkerId",
                table: "WorkOrder",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
