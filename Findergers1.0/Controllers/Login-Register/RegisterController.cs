using Findergers1._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Findergers1._0.Controllers.Login_Register
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.LoginAndRegister model)
        {
            using (DesappContext db = new DesappContext())
            {
                var oPeople = new LoginAndRegister();
                var frist_name = model.FristName;
                oPeople.FristName = model.FristName;
                oPeople.LastName = model.LastName;
                oPeople.Username = model.Username;
                oPeople.Password = model.Password;
                oPeople.Email = model.Email;
                oPeople.Phone = model.Phone;
                db.LoginAndRegisters.Add(oPeople);
                db.SaveChanges();
            }
            return Redirect("~/Login/Login");
        }
    }
}
