using HotChocolate;
using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Projects.Commands.ModifyProject;
public record ModifyProjectCommand(
     [property: ID(nameof(Project))] int Id,
     Optional<int?> ClientId,
     Optional<DateTime?> CreationDate,
     Optional<DateTime?> ReceivingDate,
     Optional<DateTime?> ProcessingDate,
     Optional<DateTime?> EndDate,
     Optional<int?> TotalReceivedPackages,
     Optional<int?> TotaOperators,
     Optional<int?> Sidemark,
     Optional<int?> ContactId,
     Optional<bool?> DeclaredValueInsurace,
     Optional<decimal?> Amount,
     Optional<string?> InspectionNotes,
     Optional<bool?> ReplaytoEmail,
     Optional<string?> EmailSent,
     Optional<int?> GeographicalInfoId,
     Optional<int?> OperatorIdReceiving,
     Optional<string?> DriverName,
     Optional<string?> ShippingNumber,
     Optional<string?> ShippingOrigin,
     Optional<string?> ProjectQRGenerated) : IRequest<Project?>;






