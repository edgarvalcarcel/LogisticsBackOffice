using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReceivingWorker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Worker_ReceivingWorkerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ReceivingWorkerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ReceivingWorkerId",
                table: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceivingWorkerId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_ReceivingWorkerId",
                table: "Project",
                column: "ReceivingWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Worker_ReceivingWorkerId",
                table: "Project",
                column: "ReceivingWorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
