using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VTSMVC.Models
{
    public class VehicleModel 
    {
      
      
        public int? UserID { get; set; }
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Display(Name = "Vehicle Number")]
        [Required(ErrorMessage = "Enter Vehicle Number")]
        public string VehicleNumber { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "Enter Vehicle Type")]
        public string VehicleType { get; set; }

        [Display(Name = "Chasis Number")]
        [Required(ErrorMessage = " Enter Chasis Number")]
        public string ChasisNumber { get; set; }

        [Display(Name = "Engine Number")]
        [Required(ErrorMessage = "Enter Engine Number")]
        public string EngineNumber { get; set; }

        [Display(Name = "Manufacturing Year")]
        [Required(ErrorMessage = "Enter Manufacturing Year")]
        public string ManufacturingYear { get; set; }

        [Display(Name = "Load Carrying Capacity")]
        [Required(ErrorMessage = "Enter Load Carrying Capacity")]
        public string LoadCarryingCapacity { get; set; }

        [Display(Name = "Make of Vehicle")]
        [Required(ErrorMessage = "Enter Make of Vehicle")]
        public string MakeofVehicle { get; set; }

        [Display(Name = "Model Number")]
        [Required(ErrorMessage = "Enter Model Number")]
        public string ModelNumber { get; set; }

        [Display(Name = "Body Type")]
        [Required(ErrorMessage = "Enter Body Type")]
        public string BodyType { get; set; }

        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "Enter Organization Name")]
        public string Organization { get; set; }

       
       
    }
}