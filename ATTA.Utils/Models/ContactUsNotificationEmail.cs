using Postal;

namespace ATTA.Utils.Models
{
    public class ContactUsNotificationEmail : Email
    {
        
        public string From { get; set; }
        public string To { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
