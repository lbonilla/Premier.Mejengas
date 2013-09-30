using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;
using Mejenguitas_UI.Models;

namespace Mejenguitas_UI.Controllers
{
    public class MejengasController : Controller
    {
        private IJuegoRepository juegoRepository;
        private IJuegoJugadorRepository juegoJugadorRepository;
        private IJugadorRepository jugadorRepository;
        //
        // GET: /Mejengas/
        public MejengasController(IJuegoRepository juegoRepo, IJugadorRepository jugadorRepo, IJuegoJugadorRepository juegoJugadorRepo)
        {
            juegoRepository = juegoRepo;
            juegoJugadorRepository = juegoJugadorRepo;
            jugadorRepository = jugadorRepo;

        }
        public ActionResult Index(int idJuego = 0, int idJugador = 11)
        {
            Juego juegoActual = null;
            bool estaInscrito = false;
            List<JuegoJugador> jugadoresInscritos = null;
            if (idJuego == 0)
            {
                //Get the next game
                juegoActual = juegoRepository.Juegos.FirstOrDefault(j => j.Fecha >= DateTime.Now);
            }
            else
            {
                juegoActual = juegoRepository.Juegos.FirstOrDefault(j => j.Id == idJuego);
            }

            if (idJugador != 0)
            {
                estaInscrito = juegoJugadorRepository.JuegosJugadores.FirstOrDefault(jj => jj.IdJugador == idJugador && jj.IdJuego == idJuego) == null ? false : true;
            }

            if (juegoActual != null)
                jugadoresInscritos = juegoJugadorRepository.JuegosJugadores.Where(jj => jj.IdJuego == juegoActual.Id).ToList();

            return View(new JuegoJugadorViewModel
            {
                Juego = juegoActual,
                JugadoresInscritos = jugadoresInscritos,
                EstaInscrito = estaInscrito,
                IdJugador = idJugador
            });
        }

        #region Others
        public FileContentResult ObtenerImagen(int idJugador)
        {
            Jugador g = jugadorRepository.Jugadores.FirstOrDefault(j => j.Id == idJugador); ;
            if (g != null && g.Avatar != null && g.AvatarMimeType != string.Empty)
                return File(g.Avatar, g.AvatarMimeType);
            return null;
        }
        #endregion
    }
}
