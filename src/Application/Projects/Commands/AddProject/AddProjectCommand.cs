using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Projects.Commands.AddProject;

public record AddProjectCommand(
    int? ClientId,
    DateTime? CreationDate,
    DateTime? ReceivingDate,
    DateTime? ProcessingDate,
    DateTime? EndDate,
    int? TotalReceivedPackages,
    int? TotaOperators,
    int? Sidemark,
    int? ContactId,
    bool? DeclaredValueInsurace,
    decimal? Amount,
    string? InspectionNotes,
    bool? ReplaytoEmail,
    string? EmailSent,
    int? GeographicalInfoId,
    int? OperatorIdReceiving,
    string? DriverName,
    string? ShippingNumber,
    string? ShippingOrigin,
    string? ProjectQRGenerated) : IRequest<Project>;


