using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Controllers
{
    public class GaleriaController : Controller
    {
        IJuegoRepository repository;

        public GaleriaController (IJuegoRepository repo)
        {
            repository = repo;
        }

        public ActionResult List(int idJuego = 0)
        {
            if (idJuego == 0)
            {
                return View(repository.Juegos.FirstOrDefault(j => j.Fecha >= DateTime.Now && j.EquipoGanador != 0).Galerias);
            }
            else 
            {
                return View(repository.Juegos.FirstOrDefault(j => j.Id == idJuego).Galerias);  
            }
        }

        public FileContentResult ObtenerImagen(int idJuego, int idGaleria)
        {
            Galeria galeria = repository.Juegos.FirstOrDefault(j => j.Id == idJuego).Galerias.FirstOrDefault(g => g.Id == idGaleria);
            if (galeria != null && galeria.Objecto != null && galeria.MimeTypeObjeto != string.Empty)
                return File(galeria.Objecto, galeria.MimeTypeObjeto);
            return null;
        }
    }
}
