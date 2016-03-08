using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.Messages
{
    [DataContract]
    public abstract class BaseResponse
    {
        protected BaseResponse()
        {
            Errors = new List<string>();
            Success = true;
        }

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public IList<string> Errors { get; set; }

        public void AddErrors(IEnumerable<string> errorList)
        {
            if (Errors == null) return;
            foreach (var error in errorList)
                Errors.Add(error);
        }

        public void AddErrors(string error)
        {
            Errors.Add(error);
        }
    }
}