namespace BLOOD_HELP.Models
{
    
    public class BloodRequest
    {
        public string User { get; set; }
        public string BloodGroup { get; set; }
        public string Unit { get; set; }

        public string ReleaseDate { get; set; }
        public string RequestDate { get; set; }
    }
}