using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIndexProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalInfo_Project_ProjectId",
                table: "GeographicalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Project_ReceivingWorkerId",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_ReceivingWorkerId",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "ReceivingWorkerId",
                table: "Worker");

            migrationBuilder.CreateIndex(
                name: "IX_Project_GeographicalInfoId",
                table: "Project",
                column: "GeographicalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ReceivingWorkerId",
                table: "Project",
                column: "ReceivingWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_GeographicalInfo_GeographicalInfoId",
                table: "Project",
                column: "GeographicalInfoId",
                principalTable: "GeographicalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Project_Worker_ReceivingWorkerId",
            //    table: "Project",
            //    column: "ReceivingWorkerId",
            //    principalTable: "Worker",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_GeographicalInfo_GeographicalInfoId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Worker_ReceivingWorkerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_GeographicalInfoId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ReceivingWorkerId",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Worker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceivingWorkerId",
                table: "Worker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_ReceivingWorkerId",
                table: "Worker",
                column: "ReceivingWorkerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalInfo_Project_ProjectId",
                table: "GeographicalInfo",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Project_ReceivingWorkerId",
                table: "Worker",
                column: "ReceivingWorkerId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}
