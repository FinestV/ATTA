using Postal;

namespace ATTA.Utils.Models
{
    public class ContactUsConfirmationEmail : Email
    {
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}