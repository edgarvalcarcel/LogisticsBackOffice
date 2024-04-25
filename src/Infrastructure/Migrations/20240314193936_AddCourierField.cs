using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCourierField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourierCompany_Project_ProjectId",
                table: "CourierCompany");

            migrationBuilder.DropIndex(
                name: "IX_CourierCompany_ProjectId",
                table: "CourierCompany");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "CourierCompany");

            migrationBuilder.AlterColumn<int>(
                name: "CourierCompanyId",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CourierCompanyId",
                table: "Project",
                column: "CourierCompanyId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Project_CourierCompany_CourierCompanyId",
            //    table: "Project",
            //    column: "CourierCompanyId",
            //    principalTable: "CourierCompany",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_CourierCompany_CourierCompanyId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CourierCompanyId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "CourierCompanyId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "CourierCompany",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourierCompany_ProjectId",
                table: "CourierCompany",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourierCompany_Project_ProjectId",
                table: "CourierCompany",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}
