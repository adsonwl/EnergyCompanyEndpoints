using AutoMapper;
using EnergyEndpoint.Application.ViewModels;
using EnergyEndpoint.Domain.Entities;

namespace EnergyEndpoint.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Endpoint, EndpointViewModel>();
        }
    }
}
