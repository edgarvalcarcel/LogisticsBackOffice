using Microsoft.EntityFrameworkCore.Migrations;
namespace LogisticsBackOffice.Infrastructure.Migrations;
/// <inheritdoc />
public partial class AddInitialTables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        ArgumentNullException.ThrowIfNull(migrationBuilder);
        migrationBuilder.CreateTable(
            name: "Client",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(3)", maxLength: 3, precision: 3, nullable: true),
                FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                Suffix = table.Column<string>(type: "nvarchar(4)", maxLength: 4, precision: 4, nullable: true),
                Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, precision: 150, nullable: false),
                Cellphone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 150, nullable: false),
                AdditionalInfo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, precision: 150, nullable: false),
                GeographicalInfoId = table.Column<int>(type: "int", nullable: false),
                Done = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_Client", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Contact",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(max)", precision: 4, nullable: true),
                FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                Suffix = table.Column<string>(type: "nvarchar(4)", maxLength: 4, precision: 4, nullable: true),
                Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, precision: 150, nullable: false),
                Cellphone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                AdditionalInfo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, precision: 150, nullable: true),
                Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_Contact", x => x.Id));

        migrationBuilder.CreateTable(
            name: "CountryRegion",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                CountryRegionCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, precision: 2, nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_CountryRegion", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Service",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: true),
                IsReceivingService = table.Column<bool>(type: "bit", nullable: true),
                IsProcessingService = table.Column<bool>(type: "bit", nullable: true),
                IsWarehouseService = table.Column<bool>(type: "bit", nullable: true),
                IsCleaningService = table.Column<bool>(type: "bit", nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_Service", x => x.Id));

        migrationBuilder.CreateTable(
            name: "ClientContact",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ClientId = table.Column<int>(type: "int", nullable: false),
                ContactId = table.Column<int>(type: "int", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientContact", x => x.Id);
                table.ForeignKey(
                    name: "FK_ClientContact_Client_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Client",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ClientContact_Contact_ContactId",
                    column: x => x.ContactId,
                    principalTable: "Contact",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "State",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: true),
                StateCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, precision: 2, nullable: false),
                CountryRegionId = table.Column<int>(type: "int", nullable: false),
                TerritoryId = table.Column<int>(type: "int", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_State", x => x.Id);
                table.ForeignKey(
                    name: "FK_State_CountryRegion_CountryRegionId",
                    column: x => x.CountryRegionId,
                    principalTable: "CountryRegion",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "GeographicalInfo",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, precision: 50, nullable: false),
                StateId = table.Column<int>(type: "int", nullable: false),
                PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, precision: 10, nullable: false),
                Latitude = table.Column<string>(type: "nvarchar(12)", maxLength: 12, precision: 12, nullable: false),
                Longitude = table.Column<string>(type: "nvarchar(12)", maxLength: 12, precision: 12, nullable: false),
                LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, precision: 20, nullable: false),
                ClientId = table.Column<int>(type: "int", nullable: true),
                ProjectId = table.Column<int>(type: "int", nullable: true),
                ProjectGeographicalInfoId = table.Column<int>(type: "int", nullable: true),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GeographicalInfo", x => x.Id);
                table.ForeignKey(
                    name: "FK_GeographicalInfo_Client_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Client",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_GeographicalInfo_State_StateId",
                    column: x => x.StateId,
                    principalTable: "State",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Operator",
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
                OperatorIdReceivingId = table.Column<int>(type: "int", nullable: false),
                UserId = table.Column<int>(type: "int", maxLength: 450, precision: 450, nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
            });

        migrationBuilder.CreateTable(
            name: "Project",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ClientId = table.Column<int>(type: "int", nullable: false),
                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                ProcessingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                TotalReceivedPackages = table.Column<int>(type: "int", nullable: true),
                TotaOperators = table.Column<int>(type: "int", nullable: true),
                Sidemark = table.Column<int>(type: "int", nullable: true),
                ContactId = table.Column<int>(type: "int", nullable: false),
                DeclaredValueInsurace = table.Column<bool>(type: "bit", nullable: true),
                Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                InspectionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ReplaytoEmail = table.Column<bool>(type: "bit", nullable: true),
                EmailSent = table.Column<string>(type: "nvarchar(80)", maxLength: 80, precision: 80, nullable: true),
                GeographicalInfoId = table.Column<int>(type: "int", nullable: false),
                OperatorReceivingId = table.Column<int>(type: "int", nullable: false),
                DeliveryCompanyId = table.Column<int>(type: "int", nullable: false),
                DriverName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, precision: 80, nullable: true),
                ShippingNumber = table.Column<string>(type: "nvarchar(80)", maxLength: 80, precision: 80, nullable: true),
                ShipperOrigin = table.Column<string>(type: "nvarchar(80)", maxLength: 80, precision: 80, nullable: true),
                ProjectQRGenerated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                WorkOrderId = table.Column<int>(type: "int", nullable: true),
                Done = table.Column<bool>(type: "bit", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Project", x => x.Id);
                table.ForeignKey(
                    name: "FK_Project_Client_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Client",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Project_Contact_ContactId",
                    column: x => x.ContactId,
                    principalTable: "Contact",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ProjectDetail",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProjectId = table.Column<int>(type: "int", nullable: false),
                ServiceId = table.Column<int>(type: "int", nullable: false),
                Duration = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                Rate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProjectDetail", x => x.Id);
                table.ForeignKey(
                    name: "FK_ProjectDetail_Project_ProjectId",
                    column: x => x.ProjectId,
                    principalTable: "Project",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ProjectDetail_Service_ServiceId",
                    column: x => x.ServiceId,
                    principalTable: "Service",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ProjectGeographicalInfo",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProjectId = table.Column<int>(type: "int", nullable: false),
                GeographicalInfoId = table.Column<int>(type: "int", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

        migrationBuilder.CreateTable(
            name: "WorkOrder",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ProjectDetailId = table.Column<int>(type: "int", nullable: false),
                ServiceId = table.Column<int>(type: "int", nullable: false),
                OperatorId = table.Column<int>(type: "int", nullable: false),
                HoursAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                ScheduledStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                ScheduledEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                ModifiedEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                ProjectId = table.Column<int>(type: "int", nullable: false),
                Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true),
                LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, precision: 100, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WorkOrder", x => x.Id);
                table.ForeignKey(
                    name: "FK_WorkOrder_Operator_OperatorId",
                    column: x => x.OperatorId,
                    principalTable: "Operator",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_WorkOrder_ProjectDetail_ProjectDetailId",
                    column: x => x.ProjectDetailId,
                    principalTable: "ProjectDetail",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_WorkOrder_Service_ServiceId",
                    column: x => x.ServiceId,
                    principalTable: "Service",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Client_Email",
            table: "Client",
            column: "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Client_Id",
            table: "Client",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_ClientContact_ClientId",
            table: "ClientContact",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_ClientContact_ContactId",
            table: "ClientContact",
            column: "ContactId");

        migrationBuilder.CreateIndex(
            name: "IX_ClientContact_Id",
            table: "ClientContact",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Contact_Email",
            table: "Contact",
            column: "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Contact_Id",
            table: "Contact",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_CountryRegion_Id",
            table: "CountryRegion",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_GeographicalInfo_ClientId",
            table: "GeographicalInfo",
            column: "ClientId",
            unique: true,
            filter: "[ClientId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_GeographicalInfo_Id",
            table: "GeographicalInfo",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_GeographicalInfo_ProjectId",
            table: "GeographicalInfo",
            column: "ProjectId",
            unique: true,
            filter: "[ProjectId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_GeographicalInfo_StateId",
            table: "GeographicalInfo",
            column: "StateId");

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

        migrationBuilder.CreateIndex(
            name: "IX_Project_ClientId",
            table: "Project",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_Project_ContactId",
            table: "Project",
            column: "ContactId");

        migrationBuilder.CreateIndex(
            name: "IX_Project_Id",
            table: "Project",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Project_WorkOrderId",
            table: "Project",
            column: "WorkOrderId",
            unique: true,
            filter: "[WorkOrderId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_ProjectDetail_Id",
            table: "ProjectDetail",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_ProjectDetail_ProjectId_ServiceId",
            table: "ProjectDetail",
            columns: ["ProjectId", "ServiceId"],
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_ProjectDetail_ServiceId",
            table: "ProjectDetail",
            column: "ServiceId");

        migrationBuilder.CreateIndex(
            name: "IX_ProjectGeographicalInfo_Id",
            table: "ProjectGeographicalInfo",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_ProjectGeographicalInfo_ProjectId",
            table: "ProjectGeographicalInfo",
            column: "ProjectId");

        migrationBuilder.CreateIndex(
            name: "IX_Service_Id",
            table: "Service",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_State_CountryRegionId",
            table: "State",
            column: "CountryRegionId");

        migrationBuilder.CreateIndex(
            name: "IX_State_Id",
            table: "State",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_TodoItems_ListId",
            table: "TodoItems",
            column: "ListId");

        migrationBuilder.CreateIndex(
            name: "IX_WorkOrder_Id",
            table: "WorkOrder",
            column: "Id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_WorkOrder_OperatorId",
            table: "WorkOrder",
            column: "OperatorId");

        migrationBuilder.CreateIndex(
            name: "IX_WorkOrder_ProjectDetailId_ServiceId_OperatorId",
            table: "WorkOrder",
            columns: ["ProjectDetailId", "ServiceId", "OperatorId"],
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_WorkOrder_ServiceId",
            table: "WorkOrder",
            column: "ServiceId");

        migrationBuilder.AddForeignKey(
            name: "FK_GeographicalInfo_ProjectGeographicalInfo_ProjectId",
            table: "GeographicalInfo",
            column: "ProjectId",
            principalTable: "ProjectGeographicalInfo",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_GeographicalInfo_Project_ProjectId",
            table: "GeographicalInfo",
            column: "ProjectId",
            principalTable: "Project",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Operator_Project_OperatorIdReceivingId",
            table: "Operator",
            column: "OperatorIdReceivingId",
            principalTable: "Project",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Project_WorkOrder_WorkOrderId",
            table: "Project",
            column: "WorkOrderId",
            principalTable: "WorkOrder",
            principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        ArgumentNullException.ThrowIfNull(migrationBuilder);
        migrationBuilder.DropForeignKey(
            name: "FK_GeographicalInfo_Client_ClientId",
            table: "GeographicalInfo");

        migrationBuilder.DropForeignKey(
            name: "FK_Project_Client_ClientId",
            table: "Project");

        migrationBuilder.DropForeignKey(
            name: "FK_Project_Contact_ContactId",
            table: "Project");

        migrationBuilder.DropForeignKey(
            name: "FK_GeographicalInfo_ProjectGeographicalInfo_ProjectId",
            table: "GeographicalInfo");

        migrationBuilder.DropForeignKey(
            name: "FK_GeographicalInfo_Project_ProjectId",
            table: "GeographicalInfo");

        migrationBuilder.DropForeignKey(
            name: "FK_Operator_Project_OperatorIdReceivingId",
            table: "Operator");

        migrationBuilder.DropForeignKey(
            name: "FK_ProjectDetail_Project_ProjectId",
            table: "ProjectDetail");
        migrationBuilder.DropTable(
            name: "ClientContact");
        migrationBuilder.DropTable(
            name: "TodoItems");
        migrationBuilder.DropTable(
            name: "TodoLists");
        migrationBuilder.DropTable(
            name: "Client");
        migrationBuilder.DropTable(
            name: "Contact");
        migrationBuilder.DropTable(
            name: "ProjectGeographicalInfo");

        migrationBuilder.DropTable(
            name: "Project");

        migrationBuilder.DropTable(
            name: "WorkOrder");

        migrationBuilder.DropTable(
            name: "Operator");

        migrationBuilder.DropTable(
            name: "ProjectDetail");

        migrationBuilder.DropTable(
            name: "GeographicalInfo");

        migrationBuilder.DropTable(
            name: "Service");

        migrationBuilder.DropTable(
            name: "State");

        migrationBuilder.DropTable(
            name: "CountryRegion");
    }
}
