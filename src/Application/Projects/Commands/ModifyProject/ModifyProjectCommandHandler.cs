using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Projects.Commands.ModifyProject;
public class ModifyProjectCommandHandler : IRequestHandler<ModifyProjectCommand, Project?>
{
    private readonly IProjectRepository _repository;

    public ModifyProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Project?> Handle(ModifyProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.FindProjectByIdAsync(request.Id, cancellationToken);

        if (project is null) return project;
        if (request.ClientId.HasValue) project.ClientId = request.ClientId;
        if (request.CreationDate.HasValue) project.CreationDate = request.CreationDate;
        if (request.ReceivingDate.HasValue) project.ReceivingDate = request.ReceivingDate;
        if (request.ProcessingDate.HasValue) project.ProcessingDate = request.ProcessingDate;
        if (request.EndDate.HasValue) project.EndDate = request.EndDate;
        if (request.TotalReceivedPackages.HasValue) project.TotalReceivedPackages = request.TotalReceivedPackages;
        if (request.TotaOperators.HasValue) project.TotaOperators = request.TotaOperators;
        if (request.Sidemark.HasValue) project.Sidemark = request.Sidemark;
        if (request.ContactId.HasValue) project.ContactId = request.ContactId;
        if (request.DeclaredValueInsurace.HasValue) project.DeclaredValueInsurace = request.DeclaredValueInsurace;
        if (request.Amount.HasValue) project.Amount = request.Amount;
        if (request.InspectionNotes.HasValue) project.InspectionNotes = request.InspectionNotes;
        if (request.ReplaytoEmail.HasValue) project.ReplaytoEmail = request.ReplaytoEmail;
        if (request.EmailSent.HasValue) project.EmailSent = request.EmailSent;
        if (request.GeographicalInfoId.HasValue) project.GeographicalInfoId = request.GeographicalInfoId;
        if (request.OperatorIdReceiving.HasValue) project.OperatorIdReceiving = request.OperatorIdReceiving;
        if (request.DriverName.HasValue) project.DriverName = request.DriverName;
        if (request.ShippingNumber.HasValue) project.ShippingNumber = request.ShippingNumber;
        if (request.ShippingOrigin.HasValue) project.ShippingOrigin = request.ShippingOrigin;
        if (request.ProjectQRGenerated.HasValue) project.ProjectQRGenerated = request.ProjectQRGenerated; 

        await _repository.UpdateProjectAsync(project, cancellationToken);
        return project;
    }
}
