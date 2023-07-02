using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VTSMVC.Models
{
    public class UserModel 
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Enter Name of Owner")]
        public string Name { get; set; }

        [MaxLength(10, ErrorMessage = "Max 10 Char Number")]

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Enter Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "Enter Organization Name")]
        public string Organization { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Enter Email ID")]
        public string EmailID { get; set; }

     
        [Required(ErrorMessage = "Enter Location")]
        public string Location { get; set; }

        [Display(Name = "Photo")]
        [Required(ErrorMessage = "Upload Image")]
        public HttpPostedFileBase Photopath { get; set; }
    }
}