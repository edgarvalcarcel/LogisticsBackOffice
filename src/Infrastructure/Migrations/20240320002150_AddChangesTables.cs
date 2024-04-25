using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChangesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "WorkOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_OrderStatusId",
                table: "WorkOrder",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_StatusId",
                table: "Project",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Status_StatusId",
                table: "Project",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Status_OrderStatusId",
                table: "WorkOrder",
                column: "OrderStatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Status_StatusId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Status_OrderStatusId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_OrderStatusId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_Project_StatusId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Project");
        }
    }
}
