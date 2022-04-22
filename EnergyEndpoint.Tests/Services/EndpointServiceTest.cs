using AutoMapper;
using EnergyEndpoint.Application.Mappings;
using EnergyEndpoint.Application.Services;
using EnergyEndpoint.Application.ViewModels;
using EnergyEndpoint.Application.ViewModels.Enum;
using EnergyEndpoint.Domain.Entities;
using EnergyEndpoint.Infra.Data;
using EnergyEndpoint.Infra.Data.Repository;
using Moq;
using Xunit;

namespace EnergyEndpoint.Tests.Services
{
    public class EndpointServiceTest
    {
        private EndpointService _endpointService;
        private static IMapper _mapper;
        private static EnergyEndpointDbContext dbContext;

        public EndpointServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ViewModelToDomainMappingProfile());
                    mc.AddProfile(new DomainToViewModelMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            dbContext  = new EnergyEndpointDbContext();
            var mockRepository = new Mock<EndpointRepository>(dbContext);

            _endpointService = new EndpointService(mockRepository.Object, _mapper);
        }

        [Fact]
        public void Add_SendingValidObject()
        {
            var result = _endpointService.Add(new EndpointViewModel { SerialNumber = "1", MeterFirmwareVersion = "1", MeterModelId = MeterModelEnum.NSX1P2W, MeterNumber = 1, SwitchState = SwitchStateEnum.Armed});
            Assert.True(result);
        }


        [Fact]
        public void Add_SendingInValidObject()
        {
            Assert.Throws<Exception>(() => _endpointService.Add(new EndpointViewModel { SerialNumber = " ", MeterFirmwareVersion = "1", MeterModelId = MeterModelEnum.NSX1P2W, MeterNumber = 1, SwitchState = SwitchStateEnum.Armed }));
        }

        [Fact]
        public void Update_SendingValidObject()
        {
            var result = _endpointService.Update(new EndpointViewModel { SerialNumber = "1", MeterFirmwareVersion = "1", MeterModelId = MeterModelEnum.NSX1P2W, MeterNumber = 1, SwitchState = SwitchStateEnum.Disconnected });
            Assert.True(result);
        }

        [Fact]
        public void Remove_SendingValidObject()
        {
            var result = _endpointService.Remove("1");
            Assert.True(result);
        }
    }
}
