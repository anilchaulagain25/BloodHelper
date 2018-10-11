using System.ComponentModel.DataAnnotations;

namespace BLOOD_HELP.Models
{
    public class BloodSampleModel
    {
        [Required]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "BloodGroup Must Have Length Between 1 and 5")]
        public string BloodGroup { get; set; }



        [Required]
        [Range(1, 9999999999, ErrorMessage = "Blood Amount Must Between 1 and 9999999999")]
        public decimal Amount { get; set; }



        [Required]
        [StringLength(10, ErrorMessage = "Unit Can't Have More Than 10 Characters")]
        public string Unit { get; set; }



        [StringLength(10,  ErrorMessage = "Blood Property Can't Have More Than 10 Characters")]
        public string BloodPropertyOne { get; set; }



        [StringLength(10,  ErrorMessage = "Blood Property Can't Have More Than 10 Characters")]
        public string BloddPropertyTwo { get; set; }




        [StringLength(10,  ErrorMessage = "Blood Property Can't Have More Than 10 Characters")]
        public string BloodPropertyThree { get; set; }




        [StringLength(50, MinimumLength = 7, ErrorMessage = "Contact No Must Have Character Between 7 and 50")]
        public string ContactNo { get; set; }



        [StringLength(500, MinimumLength = 3, ErrorMessage = "Location Must Have Character Between 3 and 500")]
        public string Location { get; set; }




        [Range(-90,  90, ErrorMessage = "Latitude Must Between -90 and 90")]
        public double Latitude { get; set; }




        [Range(-90,  90, ErrorMessage = "Longitude Must Between -90 and 90")]
        public double Longitude { get; set; }

        public int HospitalId { get; set; }
    }
}