using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;

namespace Mejenguitas_UI.Controllers
{
    public class JuegoJugadorController : Controller
    {
        IJuegoJugadorRepository repository;
        public JuegoJugadorController(IJuegoJugadorRepository repo)
        {
            repository = repo;
        }

        [HttpPost]
        public ActionResult Subscribir(int idJuego, int idJugador, string posicion)
        {
            if (posicion != null & posicion.Length > 2)
            {
                int equipo = Int32.Parse(posicion[0].ToString());
                string puesto = posicion.Substring(1);
                repository.Guardar(idJuego, idJugador, equipo, puesto);
            }
            return RedirectToAction("Index", "Mejengas", new { idJuego, idJugador });

        }

    }
}
