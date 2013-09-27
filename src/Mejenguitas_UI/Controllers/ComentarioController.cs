using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Controllers
{
    public class ComentarioController : Controller
    {
        IJuegoRepository juegoRepository;
        IComentarioRepository comentarioRepository;

        public ComentarioController(IJuegoRepository juegoRepo, IComentarioRepository comentarioRepo)
        {
            juegoRepository = juegoRepo;
            comentarioRepository = comentarioRepo;
        }

        public ActionResult List(int idJuego = 0)
        {
            if (idJuego == 0)
            {
                return View(juegoRepository.Juegos.FirstOrDefault(j => j.Fecha >= DateTime.Now && j.EquipoGanador != 0));
            }
            else
            {
                return View(juegoRepository.Juegos.FirstOrDefault(j => j.Id == idJuego));
            }
        }

        [HttpPost]
        public ActionResult Add(int idJuego, string texto)
        {
            if (!texto.Equals(string.Empty))
            {
                Comentario nuevoComentario = new Comentario();
                nuevoComentario.IdJuego = idJuego;
                nuevoComentario.Fecha = DateTime.Now;
                nuevoComentario.Texto = texto;

                comentarioRepository.Guardar(nuevoComentario);
                TempData["valComentario"] = string.Format("Se agregó el comentario exitosamente");
            }
            else
            {
                TempData["valComentario"] = "Ingrese el texto del comentario";
            }
            return RedirectToAction("Index","Mejengas",new{idJuego});
        }
    }
}
