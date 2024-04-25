using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkerFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotaOperators",
                table: "Project",
                newName: "TotaWorkers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotaWorkers",
                table: "Project",
                newName: "TotaOperators");
        }
    }
}
