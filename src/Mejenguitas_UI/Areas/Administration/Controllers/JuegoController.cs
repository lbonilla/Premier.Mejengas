using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Areas.Administration.Controllers
{
    public class JuegoController : Controller
    {
        private IJuegoRepository repository;

        public JuegoController(IJuegoRepository repo)
        {
            repository = repo;
        }

        #region CRUD Methods
        public ViewResult List()
        {
            return View(repository.Juegos.OrderByDescending(j=>j.Fecha));
        }

        public ActionResult Edit(int id)
        {
            Juego juego = repository.Juegos.FirstOrDefault(p => p.Id == id);
            return View(juego);
        }

        [HttpPost]
        public ActionResult Edit(Juego juego)
        {
            bool isNew = juego.Id == 0;
            if (ModelState.IsValid)
            {
                repository.Guardar(juego);
                TempData["message"] = string.Format("El partido para la fecha {0} fue salvado.", juego.Fecha);
                if (isNew)
                    return RedirectToAction("List");
            }

            return View(juego);
        }

        public ViewResult Create()
        {
            return View("Edit", new Juego() {  Fecha = DateTime.Now});
        }

        public ActionResult Delete(int id)
        {

            if (repository.Eliminar(id))
            {
                TempData["message"] = "Se elimino el juego exitosamente";
            }
            else
                TempData["message"] = "Sorry, El juego no fue eliminado..!! :)";

            return RedirectToAction("List");

        }

        #endregion

        #region Others
        public FileContentResult ObtenerImagen(int idJuego, int idGaleria)
        {
            Galeria g = repository.Juegos.FirstOrDefault(j => j.Id == idJuego).Galerias.FirstOrDefault(ga => ga.Id == idGaleria);
            if (g != null && g.Objecto != null && g.MimeTypeObjeto != string.Empty)
                return File(g.Objecto, g.MimeTypeObjeto);
            return null;
        }
        #endregion
    }
}
