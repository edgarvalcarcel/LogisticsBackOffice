using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations;

/// <inheritdoc />
public partial class TableGeographicalInfo : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        ArgumentNullException.ThrowIfNull(migrationBuilder);
        migrationBuilder.DropForeignKey(
            name: "FK_Project_WorkOrder_WorkOrderId",
            table: "Project");

        migrationBuilder.AlterColumn<string>(
            name: "LastModifiedBy",
            table: "State",
            type: "nvarchar(100)",
            maxLength: 100,
            precision: 100,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100,
            oldPrecision: 100,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Longitude",
            table: "GeographicalInfo",
            type: "nvarchar(20)",
            maxLength: 20,
            precision: 20,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(20)",
            oldMaxLength: 20,
            oldPrecision: 20);

        migrationBuilder.AlterColumn<string>(
            name: "Latitude",
            table: "GeographicalInfo",
            type: "nvarchar(20)",
            maxLength: 20,
            precision: 20,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(20)",
            oldMaxLength: 20,
            oldPrecision: 20);

        migrationBuilder.AlterColumn<string>(
            name: "LastModifiedBy",
            table: "GeographicalInfo",
            type: "nvarchar(100)",
            maxLength: 100,
            precision: 100,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100,
            oldPrecision: 100,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "LastModifiedBy",
            table: "CountryRegion",
            type: "nvarchar(100)",
            maxLength: 100,
            precision: 100,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100,
            oldPrecision: 100,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "LastModifiedBy",
            table: "ClientContact",
            type: "nvarchar(100)",
            maxLength: 100,
            precision: 100,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100,
            oldPrecision: 100,
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Project_WorkOrder_WorkOrderId",
            table: "Project",
            column: "WorkOrderId",
            principalTable: "WorkOrder",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        ArgumentNullException.ThrowIfNull(migrationBuilder);
        migrationBuilder.DropForeignKey(
            name: "FK_Project_WorkOrder_WorkOrderId",
            table: "Project");

        migrationBuilder.AlterColumn<string>(
            name: "LastModifiedBy",
            table: "State",
            type: "nvarchar(100)",
            maxLength: 100,
            precision: 100,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100,
            oldPrecision: 100);

        migrationBuilder.AlterColumn<string>(
            name: "Longitude",
            table: "GeographicalInfo",
            type: "nvarchar(20)",
            maxLength: 20,
            precision: 20,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(20)",
            oldMaxLength: 20,
            oldPrecision: 20,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Latitude",
            table: "GeographicalInfo",
            type: "nvarchar(20)",
            maxLength: 20,
            precision: 20,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(20)",
            oldMaxLength: 20,
            oldPrecision: 20,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "LastModifiedBy",
            table: "GeographicalInfo",
            type: "nvarchar(100)",
            maxLength: 100,
            precision: 100,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100,
            oldPrecision: 100);

        migrationBuilder.AlterColumn<string>(
            name: "LastModifiedBy",
            table: "CountryRegion",
            type: "nvarchar(100)",
            maxLength: 100,
            precision: 100,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100,
            oldPrecision: 100);

        migrationBuilder.AlterColumn<string>(
            name: "LastModifiedBy",
            table: "ClientContact",
            type: "nvarchar(100)",
            maxLength: 100,
            precision: 100,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100,
            oldPrecision: 100);

        migrationBuilder.AddForeignKey(
            name: "FK_Project_WorkOrder_WorkOrderId",
            table: "Project",
            column: "WorkOrderId",
            principalTable: "WorkOrder",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
