using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProjectGeographicalFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalInfo_ProjectGeographicalInfo_ProjectId",
                table: "GeographicalInfo");

            migrationBuilder.DropTable(
                name: "ProjectGeographicalInfo");

            migrationBuilder.DropIndex(
                name: "IX_GeographicalInfo_ProjectId",
                table: "GeographicalInfo");

            migrationBuilder.DropColumn(
                name: "ProjectGeographicalInfoId",
                table: "GeographicalInfo");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "GeographicalInfo");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.AddColumn<int>(
                name: "ProjectGeographicalInfoId",
                table: "GeographicalInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "GeographicalInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectGeographicalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeographicalInfoId = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectGeographicalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectGeographicalInfo_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalInfo_ProjectId",
                table: "GeographicalInfo",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGeographicalInfo_Id",
                table: "ProjectGeographicalInfo",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGeographicalInfo_ProjectId",
                table: "ProjectGeographicalInfo",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalInfo_ProjectGeographicalInfo_ProjectId",
                table: "GeographicalInfo",
                column: "ProjectId",
                principalTable: "ProjectGeographicalInfo",
                principalColumn: "Id");
        }
    }
}
