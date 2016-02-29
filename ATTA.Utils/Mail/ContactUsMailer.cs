using System.Configuration;
using ATTA.Utils.Models;

namespace ATTA.Utils.Mail
{
    public class ContactUsMailer
    {
        private readonly string _name;
        private readonly string _message;
        private readonly string _email;

        public ContactUsMailer(string name, string message, string email)
        {
            _name = name;
            _message = message;
            _email = email;
        }
            
        public void SendContactUsConfirmation()
        {
            var mail = new ContactUsConfirmationEmail
            {
                From = ConfigurationManager.AppSettings.Get("EmailResponder"),
                To = _email,
                Name = _name
            };
            mail.Send();
        }

        public void SendContactUsNotification()
        {
            var mail = new ContactUsNotificationEmail
            {
                From = ConfigurationManager.AppSettings.Get("EmailResponder"),
                To = ConfigurationManager.AppSettings.Get("EmailReceiver"),
                Email = _email,
                Name = _name,
                Message = _message
            };
            mail.Send();
        }
    }
}
