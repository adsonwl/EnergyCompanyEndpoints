using EnergyEndpoint.Application.Interfaces;
using EnergyEndpoint.Application.ViewModels;
using EnergyEndpoint.ConsoleApp.Interfaces;

namespace EnergyEndpoint.ConsoleApp.Pages
{
    public class Delete : IDelete
    {
        private IEndpointService _endpointService;

        public Delete(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public void DeleteOptions()
        {
            Console.Clear();
            Console.WriteLine("Type the Serial Number of the endpoint you want to delete:");
            string serialNumber = Console.ReadLine();
            if (serialNumber != null && serialNumber != "0" && serialNumber.Trim() != "")
            {
                EndpointViewModel endpoint = _endpointService.GetEndpointBySerialNumber(serialNumber);
                if (endpoint != null)
                {
                    DeleteEndpoint(endpoint);

                    Console.WriteLine("Press enter to return:");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("The Serial Number " + serialNumber + " is not registered.");
                }
            }
        }

        private void DeleteEndpoint(EndpointViewModel endpoint)
        {
            Console.Clear();
            Console.WriteLine(" | " + endpoint.SerialNumber +
                                  " | " + endpoint.MeterModelId.ToString() +
                                  " | " + endpoint.MeterNumber +
                                  " | " + endpoint.MeterFirmwareVersion +
                                  " | " + endpoint.SwitchState +
                                  " | ");

            Console.WriteLine("Are you shure you want to delete this endpoint?");
            Console.WriteLine("1 - yes");
            Console.WriteLine("2 - no");
            string shureDeleteIt = Console.ReadLine();
            if (shureDeleteIt != null && shureDeleteIt.Trim() == "1")
                _endpointService.Remove(endpoint.SerialNumber);
            else if (shureDeleteIt != null && shureDeleteIt.Trim() == "2")
            {
                return;
            }
            else
                DeleteEndpoint(endpoint);
        }
    }
}
