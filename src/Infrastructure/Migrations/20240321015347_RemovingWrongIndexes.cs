using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingWrongIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Worker_CourierCompanyIdd",
                table: "Project");

            migrationBuilder.AddForeignKey(
              name: "FK_Project_CourierCompany_CourierCompanyId",
              table: "Project",
              column: "CourierCompanyId",
              principalTable: "CourierCompany",
              principalColumn: "Id",
              onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
               name: "FK_Project_CourierCompany_CourierCompanyIdd",
               table: "Project",
               column: "CourierCompanyId",
               principalTable: "CourierCompany",
               principalColumn: "Id",
               onDelete: ReferentialAction.NoAction);
        }
    }
}
