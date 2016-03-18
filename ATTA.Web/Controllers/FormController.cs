using System.Web.Mvc;
using ATTA.Utils.Mail;
using ATTA.Web.Controllers.ViewModels;
using Umbraco.Web.Mvc;

namespace ATTA.Web.Controllers
{
    public class FormsController : SurfaceController
    {
        [HttpPost]
        public ActionResult ContactUs(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contactUsMailer = new ContactUsMailer(model.Name, model.Message, model.Email);
                contactUsMailer.SendContactUsConfirmation();
                contactUsMailer.SendContactUsNotification();
            }
            return new JsonResult();
        }
    }
}