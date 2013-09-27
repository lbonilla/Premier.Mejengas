using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas_UI.Models;
using Mejenguitas_UI.Infrastructure.Abstract;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Controllers
{
    public class LoginController : Controller
    {
        IAuthProvider authProvider;
        
        public LoginController(IAuthProvider auth)
        {
            authProvider = auth;            
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Jugador jugador = authProvider.Authenticate(model.Correo, model.Contrasenna);
                if (jugador != null)
                {
                    Session["idJugador"] = jugador.Id;
                    Session["nombreJugador"] = jugador.Nombre;                    
                    return Redirect(returnUrl ?? Url.Action("Index", "Mejengas"));
                }
                else
                {
                    ModelState.AddModelError("", "Correo Electrónico o Contraseña incorrectos");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult LoginJugador()
        {
            return RedirectToAction("Index", "Mejengas");
        }

        public ActionResult LogOut() 
        {
            authProvider.LogOut();
            Session["idJugador"] = null;
            Session["nombreJugador"] = null;
            return RedirectToAction("Index", "Mejengas");
        }
    }
}
