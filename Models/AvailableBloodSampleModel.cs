using System.Collections.Generic;

namespace BLOOD_HELP.Models
{
    public class AvailableBloodSampleModel
    {
        public AvailableBloodSampleModel()
        {
            HospitalList=new List<HospitalListDropdown>();
            BloodSampleList=new List<BloodInfo>();
        }
        public List<HospitalListDropdown> HospitalList { get; set; }
        public List<BloodInfo> BloodSampleList { get; set; }
    }
    public class  BloodInfo
    {
        public string BloodInfoId { get; internal set; }
        public string Name { get; internal set; }
        public string BloodGroup { get; internal set; }
        public string Unit { get; internal set; }

        public decimal Latitude{ get; internal set; }
        public decimal Longitude{ get; internal set; }
        
    }
    public class HospitalListDropdown
    {
        public string Value { get; internal set; }
        public string Text { get; internal set; }
    }
}