using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIndexClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeographicalInfo_Client_ClientId",
                table: "GeographicalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Worker_OperatorId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_GeographicalInfo_ClientId",
                table: "GeographicalInfo");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "GeographicalInfo");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "WorkOrder",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_ProjectDetailId_ServiceId_OperatorId",
                table: "WorkOrder",
                newName: "IX_WorkOrder_ProjectDetailId_ServiceId_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_OperatorId",
                table: "WorkOrder",
                newName: "IX_WorkOrder_WorkerId");

            //migrationBuilder.RenameColumn(
            //    name: "TotaWorkers",
            //    table: "Project",
            //    newName: "TotalWorkers");

            migrationBuilder.CreateIndex(
                name: "IX_Client_GeographicalInfoId",
                table: "Client",
                column: "GeographicalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_GeographicalInfo_GeographicalInfoId",
                table: "Client",
                column: "GeographicalInfoId",
                principalTable: "GeographicalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Worker_WorkerId",
                table: "WorkOrder",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_GeographicalInfo_GeographicalInfoId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Worker_WorkerId",
                table: "WorkOrder");

            migrationBuilder.DropIndex(
                name: "IX_Client_GeographicalInfoId",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "WorkOrder",
                newName: "OperatorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_WorkerId",
                table: "WorkOrder",
                newName: "IX_WorkOrder_OperatorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_ProjectDetailId_ServiceId_WorkerId",
                table: "WorkOrder",
                newName: "IX_WorkOrder_ProjectDetailId_ServiceId_OperatorId");

            migrationBuilder.RenameColumn(
                name: "TotalWorkers",
                table: "Project",
                newName: "TotaWorkers");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "GeographicalInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalInfo_ClientId",
                table: "GeographicalInfo",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GeographicalInfo_Client_ClientId",
                table: "GeographicalInfo",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Worker_OperatorId",
                table: "WorkOrder",
                column: "OperatorId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
