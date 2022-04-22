namespace EnergyEndpoint.Infra.Data.Models
{
    public class Endpoint
    {
        private string SerialNumber { get; set; }
        private int MeterModelId { get; set; }
        private int MeterNumber { get; set; }
        private string MeterFirmwareVersion { get; set; }
        private int SwitchState { get; set; }

    }
}
