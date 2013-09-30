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
        public ActionResult Subscribir(int idJuego, int idJugador, int equipo, string puesto)
        {
            repository.Guardar(idJuego, idJugador, equipo, puesto);
            return RedirectToAction("Index", "Mejengas", new { idJuego, idJugador });

        }

    }
}
