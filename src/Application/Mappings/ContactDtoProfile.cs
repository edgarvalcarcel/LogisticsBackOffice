using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class ContactDtoProfile : Profile
{
    public ContactDtoProfile()
    {
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<ContactDto, Contact>().ReverseMap();
    }
}