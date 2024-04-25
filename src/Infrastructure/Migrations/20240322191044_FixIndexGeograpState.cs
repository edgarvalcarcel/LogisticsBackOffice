using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations;

/// <inheritdoc />
public partial class FixIndexGeograpState : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
        name: "FK_GeographicalInfo_State_StateId",
        table: "GeographicalInfo");

        migrationBuilder.AddForeignKey(
            name: "FK_GeographicalInfo_State_StateId",
            table: "GeographicalInfo",
            column: "StateId",
            principalTable: "State",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
}
