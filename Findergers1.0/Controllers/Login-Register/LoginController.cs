using Findergers1._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Findergers1._0.Controllers.Login_Register
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginAndRegister model)
        {
            using (DesappContext db = new DesappContext())
            {
                string username = model.Username ;
                string pass = model.Password;


                if ((from d in db.LoginAndRegisters where d.Username == username && d.Password == pass select d).Count() > 0)
                {
                    return Redirect("~/Home/Index");
                }
            }
            return View();

        }
    }
}
