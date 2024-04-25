using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TableStatusProjWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkOrderStatusId",
                table: "Project");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_WorkOrder_Project_ProjectId",
            //    table: "WorkOrder");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Project_WorkOrder_WorkOrderId",
            //    table: "Project");

            //migrationBuilder.DropIndex(
            //    name: "IX_Project_WorkOrderId",
            //    table: "WorkOrder");

            //migrationBuilder.DropIndex(
            //    name: "IX_Project_WorkOrderId",
            //    table: "Project");

            //migrationBuilder.DropColumn(
            //    name: "WorkOrderId",
            //    table: "Project");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, precision: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, precision: 20, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_WorkOrder_ProjectId",
            //    table: "WorkOrder",
            //    column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Id",
                table: "Status",
                column: "Id",
                unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_WorkOrder_Project_ProjectId",
            //    table: "WorkOrder",
            //    column: "ProjectId",
            //    principalTable: "Project",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Project_ProjectId",
                table: "WorkOrder");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrder_ProjectId",
                table: "WorkOrder");

            migrationBuilder.AddColumn<int>(
                name: "WorkOrderId",
                table: "Project",
                type: "int",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Project_WorkOrderId",
            //    table: "Project",
            //    column: "WorkOrderId",
            //    unique: true,
            //    filter: "[WorkOrderId] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Project_WorkOrder_WorkOrderId",
            //    table: "Project",
            //    column: "WorkOrderId",
            //    principalTable: "WorkOrder",
            //    principalColumn: "Id");
        }
    }
}
