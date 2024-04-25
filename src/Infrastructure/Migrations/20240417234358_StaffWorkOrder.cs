using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StaffWorkOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_ProjectDetail_ProjectDetailId",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "ReportStaffId",
                table: "WorkOrderDetail");

            migrationBuilder.DropColumn(
                name: "ReportStaffId",
                table: "WorkOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_ProjectDetail_ProjectDetailId",
                table: "WorkOrder",
                column: "ProjectDetailId",
                principalTable: "ProjectDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_ProjectDetail_ProjectDetailId",
                table: "WorkOrder");

            migrationBuilder.AddColumn<int>(
                name: "ReportStaffId",
                table: "WorkOrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStaffId",
                table: "WorkOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_ProjectDetail_ProjectDetailId",
                table: "WorkOrder",
                column: "ProjectDetailId",
                principalTable: "ProjectDetail",
                principalColumn: "Id");
        }
    }
}
