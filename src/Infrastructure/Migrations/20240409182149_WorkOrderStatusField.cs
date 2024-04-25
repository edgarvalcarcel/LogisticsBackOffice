using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkOrderStatusField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Status_OrderStatusId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_OrderStatusId",
                table: "WorkOrder");
            //-----------------------------*//
            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "WorkOrder");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_StatusId",
                table: "WorkOrder",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Status_StatusId",
                table: "WorkOrder",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "WorkOrder",
                type: "int",
                nullable: true);
        }
    }
}
