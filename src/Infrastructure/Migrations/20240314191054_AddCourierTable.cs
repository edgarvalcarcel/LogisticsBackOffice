using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCourierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryCompanyId",
                table: "Project",
                newName: "CourierCompanyId");

            migrationBuilder.CreateTable(
                name: "CourierCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierCompany_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourierCompany_Id",
                table: "CourierCompany",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourierCompany_ProjectId",
                table: "CourierCompany",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourierCompany");

            migrationBuilder.RenameColumn(
                name: "CourierCompanyId",
                table: "Project",
                newName: "DeliveryCompanyId");
        }
    }
}
