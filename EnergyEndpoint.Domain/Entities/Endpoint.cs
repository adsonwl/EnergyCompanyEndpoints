using EnergyEndpoint.Domain.Entities.Enum;

namespace EnergyEndpoint.Domain.Entities
{
    public class Endpoint
    {
        public string SerialNumber { get; set; }
        public MeterModelEnum MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public SwitchStateEnum SwitchState { get; set; }

    }
}
