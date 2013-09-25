using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Controllers
{
    public class MejengasController : Controller
    {
        private IJuegoRepository juegoRepository;
        //
        // GET: /Mejengas/
        public MejengasController(IJuegoRepository juegoRepo) {
            juegoRepository = juegoRepo;
        }
        public ActionResult Index(int idJuego =0)
        {
            Juego juegoActual=null;
            if (idJuego == 0)
            {
                //Get the next game
                 juegoActual=  juegoRepository.Juegos.FirstOrDefault(j => j.Fecha >= DateTime.Now && j.EquipoGanador != 0);
            }
            else
            {
                juegoActual = juegoRepository.Juegos.FirstOrDefault(j => j.Id== idJuego);
            }
            return View(juegoActual);
        }
        

    }
}
