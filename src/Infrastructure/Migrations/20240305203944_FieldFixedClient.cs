using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations;

/// <inheritdoc />
public partial class FieldFixedClient : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "GeographicalInfoId",
            table: "Client",
            newName: "GeographicalInfoId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "GeographicalInfoId",
            table: "Client",
            newName: "GeographicalInfoId");
    }
}
