using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BLOOD_HELP.Models
{
    public class ReceiverLoginModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username/Email Must Between 4 and 50 in Length")]
        public string Username { get; set; }



        [Required]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password Must Between 6 and 200 in Length")]
        public string Password { get; set; }
    }
}