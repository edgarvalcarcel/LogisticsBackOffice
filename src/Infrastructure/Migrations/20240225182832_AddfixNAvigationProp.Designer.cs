﻿// <auto-generated />
using System;
using LogisticsBackOffice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogisticsBackOffice.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240225182832_AddfixNAvigationProp")]
    partial class AddfixNAvigationProp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasPrecision(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(150)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Done")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasPrecision(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GeographicalInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Suffix")
                        .HasMaxLength(4)
                        .HasPrecision(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Title")
                        .HasMaxLength(3)
                        .HasPrecision(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Client");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.ClientContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ContactId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("ClientContact");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasMaxLength(150)
                        .HasPrecision(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasPrecision(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Suffix")
                        .HasMaxLength(4)
                        .HasPrecision(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Title")
                        .HasPrecision(4)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.CountryRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryRegionCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasPrecision(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("CountryRegion");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.GeographicalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(12)
                        .HasPrecision(20)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(12)
                        .HasPrecision(20)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasPrecision(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasPrecision(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("ProjectGeographicalInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasFilter("[ClientId] IS NOT NULL");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProjectId")
                        .IsUnique()
                        .HasFilter("[ProjectId] IS NOT NULL");

                    b.HasIndex("StateId");

                    b.ToTable("GeographicalInfo");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GeographicalInfoId")
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OperatorIdReceivingId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .HasMaxLength(4)
                        .HasPrecision(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("UserId")
                        .HasMaxLength(450)
                        .HasPrecision(450)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeographicalInfoId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OperatorIdReceivingId")
                        .IsUnique();

                    b.ToTable("Operator");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool?>("DeclaredValueInsurace")
                        .HasColumnType("bit");

                    b.Property<int>("DeliveryCompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("DriverName")
                        .HasMaxLength(80)
                        .HasPrecision(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("EmailSent")
                        .HasMaxLength(80)
                        .HasPrecision(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeographicalInfoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("InspectionNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OperatorReceivingId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProcessingDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectQRGenerated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceivingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("ReplaytoEmail")
                        .HasColumnType("bit");

                    b.Property<string>("ShipperOrigin")
                        .HasMaxLength(80)
                        .HasPrecision(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("ShippingNumber")
                        .HasMaxLength(80)
                        .HasPrecision(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int?>("Sidemark")
                        .HasColumnType("int");

                    b.Property<int?>("TotaOperators")
                        .HasColumnType("int");

                    b.Property<int?>("TotalReceivedPackages")
                        .HasColumnType("int");

                    b.Property<int?>("WorkOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ContactId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("WorkOrderId")
                        .IsUnique()
                        .HasFilter("[WorkOrderId] IS NOT NULL");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.ProjectDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Duration")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ServiceId");

                    b.HasIndex("ProjectId", "ServiceId")
                        .IsUnique();

                    b.ToTable("ProjectDetail");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.ProjectGeographicalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GeographicalInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectGeographicalInfo");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsCleaningService")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsProcessingService")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsReceivingService")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsWarehouseService")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Service");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryRegionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasPrecision(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasPrecision(3)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("TerritoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryRegionId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("State");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.WorkOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("HoursAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(100)
                        .HasPrecision(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperatorId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ScheduledEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ScheduledStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OperatorId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("ProjectDetailId", "ServiceId", "OperatorId")
                        .IsUnique();

                    b.ToTable("WorkOrder");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.ClientContact", b =>
                {
                    b.HasOne("LogisticsBackOffice.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsBackOffice.Domain.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.GeographicalInfo", b =>
                {
                    b.HasOne("LogisticsBackOffice.Domain.Entities.Client", "Client")
                        .WithOne("GeographicalInfo")
                        .HasForeignKey("LogisticsBackOffice.Domain.Entities.GeographicalInfo", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LogisticsBackOffice.Domain.Entities.Project", "Project")
                        .WithOne("GeographicalInfo")
                        .HasForeignKey("LogisticsBackOffice.Domain.Entities.GeographicalInfo", "ProjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LogisticsBackOffice.Domain.Entities.ProjectGeographicalInfo", "ProjectGeographicalInfo")
                        .WithOne("GeographicalInfo")
                        .HasForeignKey("LogisticsBackOffice.Domain.Entities.GeographicalInfo", "ProjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LogisticsBackOffice.Domain.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Project");

                    b.Navigation("ProjectGeographicalInfo");

                    b.Navigation("State");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Operator", b =>
                {
                    b.HasOne("LogisticsBackOffice.Domain.Entities.GeographicalInfo", "Geographicalnfo")
                        .WithMany()
                        .HasForeignKey("GeographicalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsBackOffice.Domain.Entities.Project", "Project")
                        .WithOne("OperatorReceiving")
                        .HasForeignKey("LogisticsBackOffice.Domain.Entities.Operator", "OperatorIdReceivingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Geographicalnfo");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Project", b =>
                {
                    b.HasOne("LogisticsBackOffice.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsBackOffice.Domain.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsBackOffice.Domain.Entities.WorkOrder", "WorkOrder")
                        .WithOne("Project")
                        .HasForeignKey("LogisticsBackOffice.Domain.Entities.Project", "WorkOrderId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Client");

                    b.Navigation("Contact");

                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.ProjectDetail", b =>
                {
                    b.HasOne("LogisticsBackOffice.Domain.Entities.Project", "Project")
                        .WithMany("ProjectDetail")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsBackOffice.Domain.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.ProjectGeographicalInfo", b =>
                {
                    b.HasOne("LogisticsBackOffice.Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.State", b =>
                {
                    b.HasOne("LogisticsBackOffice.Domain.Entities.CountryRegion", "CountryRegion")
                        .WithMany()
                        .HasForeignKey("CountryRegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryRegion");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.WorkOrder", b =>
                {
                    b.HasOne("LogisticsBackOffice.Domain.Entities.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsBackOffice.Domain.Entities.ProjectDetail", "ProjectDetail")
                        .WithMany("WorkOrders")
                        .HasForeignKey("ProjectDetailId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LogisticsBackOffice.Domain.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operator");

                    b.Navigation("ProjectDetail");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Client", b =>
                {
                    b.Navigation("GeographicalInfo");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.Project", b =>
                {
                    b.Navigation("GeographicalInfo");

                    b.Navigation("OperatorReceiving");

                    b.Navigation("ProjectDetail");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.ProjectDetail", b =>
                {
                    b.Navigation("WorkOrders");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.ProjectGeographicalInfo", b =>
                {
                    b.Navigation("GeographicalInfo");
                });

            modelBuilder.Entity("LogisticsBackOffice.Domain.Entities.WorkOrder", b =>
                {
                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
