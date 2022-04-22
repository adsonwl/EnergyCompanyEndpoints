using AutoMapper;
using EnergyEndpoint.Application.Interfaces;
using EnergyEndpoint.Application.ViewModels;
using EnergyEndpoint.Domain.Entities;
using EnergyEndpoint.Infra.Data.Repository;

namespace EnergyEndpoint.Application.Services
{
    public class EndpointService : IEndpointService
    {
        private EndpointRepository _endpointRepository;
        private readonly IMapper _mapper;

        public EndpointService(EndpointRepository endpointRepository, IMapper mapper)
        {
            _endpointRepository = endpointRepository;
            _mapper = mapper;
        }

        public bool Add(EndpointViewModel endpointViewModel)
        {
            if (endpointViewModel.SerialNumber.Trim() == "")
            {
                throw new Exception("Serial number cannot be empty!");
            }
            Endpoint mapEndpoint = _mapper.Map<Endpoint>(endpointViewModel);
            return _endpointRepository.Add(mapEndpoint);
        }

        public EndpointViewModel GetEndpointBySerialNumber(string serialNumber)
        {
            Endpoint result = _endpointRepository.Get(p => p.SerialNumber == serialNumber).FirstOrDefault();
            return _mapper.Map<EndpointViewModel>(result);
        }

        public IEnumerable<EndpointViewModel> GetEndpoints()
        {
            IEnumerable<Endpoint> result = _endpointRepository.Get();
            return _mapper.Map<IEnumerable<EndpointViewModel>>(result);
        }

        public bool Remove(string serialNumber)
        {
            Endpoint result = _endpointRepository.Get(p => p.SerialNumber == serialNumber).FirstOrDefault();
            return _endpointRepository.Delete(result);
        }

        public bool Update(EndpointViewModel endpointViewModel)
        {
            Endpoint mapEndpoint = _mapper.Map<Endpoint>(endpointViewModel);
            return _endpointRepository.Update(mapEndpoint);
        }
    }
}
