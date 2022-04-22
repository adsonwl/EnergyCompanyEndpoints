using EnergyEndpoint.Application.Interfaces;
using EnergyEndpoint.Application.ViewModels;
using EnergyEndpoint.ConsoleApp.Interfaces;

namespace EnergyEndpoint.ConsoleApp.Pages
{
    public class Select : ISelect
    {
        private IEndpointService _endpointService;

        public Select(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }
        public void SelectAll()
        {
            Console.Clear();
            IEnumerable<EndpointViewModel> endpoints = _endpointService.GetEndpoints();
            foreach (EndpointViewModel endpoint in endpoints)
            {
                Console.WriteLine(" | " + endpoint.SerialNumber + 
                                  " | " + endpoint.MeterModelId.ToString() +
                                  " | " + endpoint.MeterNumber +
                                  " | " + endpoint.MeterFirmwareVersion +
                                  " | " + endpoint.SwitchState +
                                  " | ");
            }
            Console.WriteLine("Press enter to return:");
            Console.ReadLine();
        }

        public void SelectBySerialNumber()
        {
            Console.Clear();
            Console.WriteLine("Type the Serial Number of the endpoint you want to search:");
            string serialNumber = Console.ReadLine();
            if (serialNumber != null && serialNumber != "0" && serialNumber.Trim() != "")
            {
                EndpointViewModel endpoint = _endpointService.GetEndpointBySerialNumber(serialNumber);
                Console.WriteLine(" | " + endpoint.SerialNumber +
                                      " | " + endpoint.MeterModelId.ToString() +
                                      " | " + endpoint.MeterNumber +
                                      " | " + endpoint.MeterFirmwareVersion +
                                      " | " + endpoint.SwitchState +
                                      " | ");
            }
            Console.WriteLine("Press enter to return:");
            Console.ReadLine();
        }
    }
}
