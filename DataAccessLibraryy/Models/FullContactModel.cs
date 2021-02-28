using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public class FullContactModel
    {
        public BasicContactModel BasicInfo { get; set; }
        public List<EmailAddressModel> EmailAdresses { get; set; } = new List<EmailAddressModel>();
        public List<PhoneNumberModel> PhoneNumbers { get; set; } = new List<PhoneNumberModel>();
    }
}