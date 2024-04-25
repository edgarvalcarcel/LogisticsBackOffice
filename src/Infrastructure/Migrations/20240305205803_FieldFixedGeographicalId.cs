using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations;

/// <inheritdoc />
public partial class FieldFixedGeographicalId : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Operator_GeographicalInfo_GeographicalInfoId",
            table: "Operator");

        migrationBuilder.RenameColumn(
            name: "GeographicalInfoId",
            table: "Operator",
            newName: "GeographicalInfoId");

        migrationBuilder.RenameIndex(
            name: "IX_Operator_GeographicalInfoId",
            table: "Operator",
            newName: "IX_Operator_GeographicalInfoId");

        migrationBuilder.AddForeignKey(
            name: "FK_Operator_GeographicalInfo_GeographicalInfoId",
            table: "Operator",
            column: "GeographicalInfoId",
            principalTable: "GeographicalInfo",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Operator_GeographicalInfo_GeographicalInfoId",
            table: "Operator");

        migrationBuilder.RenameColumn(
            name: "GeographicalInfoId",
            table: "Operator",
            newName: "GeographicalInfoId");

        migrationBuilder.RenameIndex(
            name: "IX_Operator_GeographicalInfoId",
            table: "Operator",
            newName: "IX_Operator_GeographicalInfoId");

        migrationBuilder.AddForeignKey(
            name: "FK_Operator_GeographicalInfo_GeographicalInfoId",
            table: "Operator",
            column: "GeographicalInfoId",
            principalTable: "GeographicalInfo",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
