using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas_UI.Models;
using Mejenguitas_UI.Infrastructure.Abstract;

namespace Mejenguitas_UI.Controllers
{
    public class LoginController : Controller
    {
        IAuthProvider authProvider;
        public LoginController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("List", "Juego"));
                }
                else
                {
                    ModelState.AddModelError("", "Nombre de Usuario o Contraseña incorrectos");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
