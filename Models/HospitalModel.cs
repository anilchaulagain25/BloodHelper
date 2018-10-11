using System.ComponentModel.DataAnnotations;

namespace BLOOD_HELP.Models
{
    public class HospitalModel
    {
        [Required(ErrorMessage = "Hospital Name Is Required")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Hospital Name Must Between 4 and 200 in Length")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Name Length Must Between 4 and 50")]
        public string Username { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Password Length Must Between 6 and 256")]
        public string Password { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "ContactNo Length Must Between 7 and 100")]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Location Length Must Between 3 and 500")]
        public string Location { get; set; }
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Website Length Must Between 4 and 200")]
        public string Website { get; set; }
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Email Length Must Between 4 and 200")]

        [EmailAddress]
        public string Email { get; set; }

        public string IpAddress { get; set; }
        public int Id { get; internal set; }
    }
}