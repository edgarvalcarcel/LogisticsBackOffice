using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkerFixesField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Operator_OperatorId",
                table: "WorkOrder");

            migrationBuilder.DropTable(
                name: "Operator");

            //migrationBuilder.RenameColumn(
            //    name: "TotaOperators",
            //    table: "Project",
            //    newName: "TotaWorkers");
            migrationBuilder.RenameColumn(
               name: "TotaWorkers",
               table: "Project",
               newName: "TotalWorkers");

            migrationBuilder.RenameColumn(
                name: "OperatorReceivingId",
                table: "Project",
                newName: "ReceivingWorkerId");

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(4)", maxLength: 4, precision: 4, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                    GeographicalInfoId = table.Column<int>(type: "int", maxLength: 50, precision: 50, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ReceivingWorkerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", maxLength: 450, precision: 450, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_GeographicalInfo_GeographicalInfoId",
                        column: x => x.GeographicalInfoId,
                        principalTable: "GeographicalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worker_Project_ReceivingWorkerId",
                        column: x => x.ReceivingWorkerId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Worker_GeographicalInfoId",
                table: "Worker",
                column: "GeographicalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_Id",
                table: "Worker",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_ReceivingWorkerId",
                table: "Worker",
                column: "ReceivingWorkerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Worker_OperatorId",
                table: "WorkOrder",
                column: "OperatorId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Worker_OperatorId",
                table: "WorkOrder");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.RenameColumn(
                name: "TotaWorkers",
                table: "Project",
                newName: "TotaOperators");

            migrationBuilder.RenameColumn(
                name: "ReceivingWorkerId",
                table: "Project",
                newName: "OperatorReceivingId");

            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeographicalInfoId = table.Column<int>(type: "int", maxLength: 50, precision: 50, nullable: false),
                    OperatorIdReceivingId = table.Column<int>(type: "int", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                    Cellphone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(4)", maxLength: 4, precision: 4, nullable: true),
                    UserId = table.Column<int>(type: "int", maxLength: 450, precision: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operator_GeographicalInfo_GeographicalInfoId",
                        column: x => x.GeographicalInfoId,
                        principalTable: "GeographicalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operator_Project_OperatorIdReceivingId",
                        column: x => x.OperatorIdReceivingId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operator_GeographicalInfoId",
                table: "Operator",
                column: "GeographicalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Operator_Id",
                table: "Operator",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operator_OperatorIdReceivingId",
                table: "Operator",
                column: "OperatorIdReceivingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Operator_OperatorId",
                table: "WorkOrder",
                column: "OperatorId",
                principalTable: "Operator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
