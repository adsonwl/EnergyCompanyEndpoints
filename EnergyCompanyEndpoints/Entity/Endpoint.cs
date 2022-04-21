using EnergyCompanyEndpoints.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyCompanyEndpoints.Entity
{
    internal class Endpoint
    {
        private string SerialNumber { get; set; }
        private MeterModelEnum MeterModelId { get; set; }
        private int MeterNumber { get; set; }
        private string MeterFirmwareVersion { get; set; }
        private SwitchStateEnum SwitchState { get; set; }

    }
}
