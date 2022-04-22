using EnergyEndpoint.Application.ViewModels.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyEndpoint.Application.ViewModels
{
    public class EndpointViewModel
    {
        [Required(ErrorMessage = "Serial Number is Required!")]
        [MaxLength(128)]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Meter Model Id is Required!")]
        [Range(16, 19)]
        [Display(Name = "Meter Model Id")]
        public MeterModelEnum MeterModelId { get; set; }

        [Required(ErrorMessage = "Meter Number is Required!")]
        [Display(Name = "Meter Number")]
        public int MeterNumber { get; set; }

        [Required(ErrorMessage = "Meter Firmware Version is Required!")]
        [MaxLength(128)]
        [Display(Name = "Meter Firmware Version")]
        public string MeterFirmwareVersion { get; set; }

        [Required(ErrorMessage = "Switch State is Required!")]
        [Range(0, 2)]
        [Display(Name = "Switch State")]
        public SwitchStateEnum SwitchState { get; set; }
    }
}
