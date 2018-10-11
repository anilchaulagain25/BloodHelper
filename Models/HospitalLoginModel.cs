using System.ComponentModel.DataAnnotations;

namespace BLOOD_HELP.Models
{
    public class HospitalLoginModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username/Email Length Must Between 4 and 50")]
        public string Username { get; set; }


        [Required]
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Password Length Must Between 6 and 256")]
        public string Password { get; set; }
    }
}