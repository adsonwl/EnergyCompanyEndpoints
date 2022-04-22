using AutoMapper;
using EnergyEndpoint.Application.ViewModels;
using EnergyEndpoint.Domain.Entities;

namespace EnergyEndpoint.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EndpointViewModel, Endpoint>();
        }
    }
}
