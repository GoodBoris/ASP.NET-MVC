using System.Runtime.Serialization;

namespace Service.Utilities.PhotoAlbum
{
    [DataContract]
    public class CustomExpMsg
    {
        public CustomExpMsg()
        {
            ErrorMsg = "Service encountered an error";  
        }
        public CustomExpMsg(string message)
        {
            ErrorMsg = message;
        }

        [DataMember(Order = 0)]
        public int ErrorNumber { get; set; }

        [DataMember(Order = 1)]
        public string ErrorMsg { get; set; }

        [DataMember(Order = 2)]
        public string Description { get; set; }
    }
}