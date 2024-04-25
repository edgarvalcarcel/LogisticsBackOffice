using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationsShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Project_Worker_ReceivingWorkerId",
                table: "Project",
                column: "ReceivingWorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Worker_CourierCompanyIdd",
                table: "Project",
                column: "CourierCompanyId",
                principalTable: "CourierCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_Project_Worker_ReceivingWorkerId",
               table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Worker_CourierCompanyIdd",
                table: "Project");
        }
    }
}
