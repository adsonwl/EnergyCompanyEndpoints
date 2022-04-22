using EnergyEndpoint.Application.Interfaces;
using EnergyEndpoint.Application.ViewModels;
using EnergyEndpoint.Application.ViewModels.Enum;
using EnergyEndpoint.ConsoleApp.Interfaces;

namespace EnergyEndpoint.ConsoleApp.Pages
{
    public class Insert : IInsert
    {
        private IEndpointService _endpointService;

        public Insert(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public void InsertOptions()
        {
            Console.Clear();

            bool doNotReturn = true;

            do
            {

                Console.WriteLine("Type the Endpoint Serial Number or 0(zero) to return:");
                string serialNumber = Console.ReadLine();
                if (serialNumber != null && serialNumber != "0" && serialNumber.Trim() != "")
                {
                    EndpointViewModel endpoint = _endpointService.GetEndpointBySerialNumber(serialNumber);
                    if (endpoint == null)
                    {
                        endpoint = new EndpointViewModel();
                        endpoint.SerialNumber = serialNumber;
                        Console.Clear();
                        endpoint.MeterModelId = InsertModelId();
                        Console.Clear();
                        endpoint.MeterNumber = InsertMeterNumber();
                        Console.Clear();
                        endpoint.MeterFirmwareVersion = InsertFirmwareVersion();
                        Console.Clear();
                        endpoint.SwitchState = InsertSwitchState();
                        _endpointService.Add(endpoint);
                    }
                    else
                    {
                        Console.WriteLine("The Serial Number " + serialNumber + " is alread registerd.");
                    }
                }
                else
                {
                    doNotReturn = false;
                }
            }while (doNotReturn);
        }

        private MeterModelEnum InsertModelId()
        {
            Console.WriteLine("Considering the following options, type the Meter Model Id:");
            Console.WriteLine("16 - NSX1P2W");
            Console.WriteLine("17 - NSX1P3W");
            Console.WriteLine("18 - NSX2P3W");
            Console.WriteLine("19 - NSX3P4W");
            string modelId = Console.ReadLine();

            if (modelId != null && modelId.All(char.IsDigit) && modelId.Trim() != "")
            {
                int intModelId = Int32.Parse(modelId);
                if (intModelId > 15 && intModelId < 20)
                {
                    return (MeterModelEnum)intModelId;
                }
            }

            Console.Clear();
            Console.WriteLine("Choose a valid option!");
            return InsertModelId();
        }

        private int InsertMeterNumber() { 
            Console.WriteLine("Type the Meter Number:");
            string meterNumber = Console.ReadLine();

            if (meterNumber != null && meterNumber.All(char.IsDigit) && meterNumber.Trim() != "")
            {
                return Int32.Parse(meterNumber);    
            }
            Console.Clear();
            Console.WriteLine("The Meter Number must be a number");
            return InsertMeterNumber();

        }

        private string InsertFirmwareVersion()
        {
            Console.WriteLine("Type the Meter Firmware Version:");
            string firmwareVersion = Console.ReadLine();
            if(firmwareVersion != null && firmwareVersion.Trim() != "")
            {
                return firmwareVersion;
            }
            Console.Clear();
            Console.WriteLine("The Firmware Version cannot be empty");
            return InsertFirmwareVersion();
        }

        private SwitchStateEnum InsertSwitchState() { 
            Console.WriteLine("Considering the following options, type the Switch State:");
            Console.WriteLine("0 - Disconnected");
            Console.WriteLine("1 - Connected");
            Console.WriteLine("2 - Armed");
            string switchState = Console.ReadLine();

            if (switchState != null && switchState.All(char.IsDigit) && switchState.Trim() != "" )
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
