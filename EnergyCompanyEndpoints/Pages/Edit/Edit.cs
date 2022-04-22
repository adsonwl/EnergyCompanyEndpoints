using EnergyEndpoint.Application.Interfaces;
using EnergyEndpoint.Application.ViewModels;
using EnergyEndpoint.Application.ViewModels.Enum;
using EnergyEndpoint.ConsoleApp.Interfaces;

namespace EnergyEndpoint.ConsoleApp.Pages
{
    public class Edit : IEdit
    {
        private IEndpointService _endpointService;

        public Edit(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public void EditOptions()
        {
            Console.Clear();
            Console.WriteLine("Type the Serial Number of the endpoint you want to edit:");
            string serialNumber = Console.ReadLine();
            if (serialNumber != null && serialNumber != "0" && serialNumber.Trim() != "")
            {
                EndpointViewModel endpoint = _endpointService.GetEndpointBySerialNumber(serialNumber);
                if (endpoint != null)
                {
                    Console.WriteLine(" | " + endpoint.SerialNumber +
                                  " | " + endpoint.MeterModelId.ToString() +
                                  " | " + endpoint.MeterNumber +
                                  " | " + endpoint.MeterFirmwareVersion +
                                  " | " + endpoint.SwitchState +
                                  " | ");
                    endpoint.SwitchState = InsertSwitchState();
                    _endpointService.Update(endpoint);
                    
                    endpoint = _endpointService.GetEndpointBySerialNumber(serialNumber);
                    Console.WriteLine(" | " + endpoint.SerialNumber +
                                  " | " + endpoint.MeterModelId.ToString() +
                                  " | " + endpoint.MeterNumber +
                                  " | " + endpoint.MeterFirmwareVersion +
                                  " | " + endpoint.SwitchState +
                                  " | ");
                    Console.WriteLine("Press enter to return:");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("The Serial Number " + serialNumber + " is not registered.");
                }
            }
        }

        private SwitchStateEnum InsertSwitchState()
        {
            Console.WriteLine("Considering the following options, type the new Switch State:");
            Console.WriteLine("0 - Disconnected");
            Console.WriteLine("1 - Connected");
            Console.WriteLine("2 - Armed");
            string switchState = Console.ReadLine();

            if (switchState != null && switchState.All(char.IsDigit) && switchState.Trim() != "")
            {
                int intModelId = Int32.Parse(switchState);
                if (intModelId >= 0 && intModelId < 4)
                {
                    return (SwitchStateEnum)intModelId;
                }
            }

            Console.Clear();
            Console.WriteLine("Choose a valid option!");
            return InsertSwitchState();
        }
    }
}
