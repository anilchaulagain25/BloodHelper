using System.Globalization;

namespace BLOOD_HELP.Models
{
    public class ResultSet
    {
        private string _message;
        public bool Success { get; set; }
        public string Message
        {
            get
            {
                return _message == null ? string.Empty : new CultureInfo("en-US").TextInfo.ToTitleCase(_message.ToLower());
            }
            set
            {
                _message = value;
            }
        }
        public dynamic Data { get; set; }
    }
}