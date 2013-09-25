using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Areas.Administration.Controllers
{
    public class GaleriaController : Controller
    {
        private IGaleriaRepository repository;
        public GaleriaController(IGaleriaRepository repo)
        {
            repository = repo;
        }

        public ActionResult Add(int id, string descripcion, HttpPostedFileBase image)
        {
            if (image != null)
            {

                Galeria newGaleria = new Galeria();
                newGaleria.MimeTypeObjeto = image.ContentType;
                newGaleria.Objecto = new byte[image.ContentLength];
                newGaleria.IdJuego = id;
                newGaleria.Descripcion = descripcion;
                image.InputStream.Read(newGaleria.Objecto, 0, image.ContentLength);

                repository.Guardar(newGaleria);
                TempData["valImage"] = string.Format("Se agregó la imagen exitosamente");
            }
            else
            {
                TempData["valImage"] = "Seleccione una imagen";
            }
            return RedirectToAction("Edit","Juego",new{id});
        }

        public ActionResult Delete(int idGaleria,int idJuego) {

            if (repository.Eliminar(idGaleria))
            {
                TempData["valImage"] = "Imagen eliminada";
            }
            else
            {
                TempData["valImage"] = "La imagen no se pudo eliminar";
            }
            return RedirectToAction("Edit","Juego",new{id=idJuego});
        }
    
    }
}
