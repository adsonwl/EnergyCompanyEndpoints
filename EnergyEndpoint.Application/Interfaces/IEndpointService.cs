using EnergyEndpoint.Application.ViewModels;

namespace EnergyEndpoint.Application.Interfaces
{
    public interface IEndpointService
    {
        bool Add(EndpointViewModel endpointViewModel);
        bool Update(EndpointViewModel endpointViewModel);
        IEnumerable<EndpointViewModel> GetEndpoints();
        EndpointViewModel GetEndpointBySerialNumber(string serialNumber);
        bool Remove(string serialNumber);

    }
}
