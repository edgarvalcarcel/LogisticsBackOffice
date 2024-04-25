using LogisticsBackOffice.Domain.Entities;
namespace LogisticsBackOffice.GraphQL.Types;

public class ClientType : ObjectType<Client>
{
    protected override void Configure(IObjectTypeDescriptor<Client> descriptor)
    {
        //descriptor.Field(x => x.DomainEvents).Ignore();
    }
}
