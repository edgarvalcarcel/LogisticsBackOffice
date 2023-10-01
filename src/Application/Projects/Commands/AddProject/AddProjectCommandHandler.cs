using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Operators.Commands.AddOperator;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Projects.Commands.AddProject;

public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand, Project>
{
    private readonly IProjectRepository _repository;

    public AddProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Project> Handle(AddProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            ClientId = request.ClientId,
            CreationDate = request.CreationDate,
            ReceivingDate = request.ReceivingDate,
            ProcessingDate = request.ProcessingDate,
            EndDate = request.EndDate,
            TotalReceivedPackages = request.TotalReceivedPackages,
            TotaOperators = request.TotaOperators,
            Sidemark = request.Sidemark,
            ContactId = request.ContactId,
            DeclaredValueInsurace = request.DeclaredValueInsurace,
            Amount = request.Amount,
            InspectionNotes = request.InspectionNotes,
            ReplaytoEmail = request.ReplaytoEmail,
            EmailSent = request.EmailSent,
            GeographicalInfoId = request.GeographicalInfoId,
            OperatorIdReceiving = request.OperatorIdReceiving,
            DriverName = request.DriverName,
            ShippingNumber = request.ShippingNumber,
            ShippingOrigin = request.ShippingOrigin,
            ProjectQRGenerated = request.ProjectQRGenerated
        };

        await _repository.AddProjectAsync(project, cancellationToken);
        return project;
    }
}
