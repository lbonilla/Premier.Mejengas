using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Controllers
{
    public class JugadorController : Controller
    {
        IJugadorRepository repository;

        public JugadorController(IJugadorRepository repo)
        {
            repository = repo;
        }

        public FileContentResult ObtenerImagen(int idJugador)
        {
            Jugador jugador = repository.Jugadores.FirstOrDefault(j => j.Id == idJugador);
            if (jugador != null && jugador.Avatar != null && jugador.AvatarMimeType != null)
                return File(jugador.Avatar, jugador.AvatarMimeType);
            return null;
        }

    }
}
