using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BLOOD_HELP.Models
{
    public class ReceiverModel
    {
        internal int Id;

        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Name Must Between 3 and 200 in Length")]
        public string Name { get;  set; }



        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username Must Between 4 and 50 in Length")]
        public string Username { get;  set; }
        
        
        
        [Required]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password Must Between 6 and 200 in Length")]
        public string Password { get;  set; }
       
       
       
        [StringLength(10, MinimumLength = 7, ErrorMessage = "Contact No Must Between 7 and 10 in Length")]
        public string ContactNo { get;  set; }
       
       
       

        [EmailAddress]
        public string Email { get;  set; }
       
       
       
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Location Must Between 4 and 500 in Length")]

        public string Location { get;  set; }
        public string IpAddress { get;  set; }
    }
}