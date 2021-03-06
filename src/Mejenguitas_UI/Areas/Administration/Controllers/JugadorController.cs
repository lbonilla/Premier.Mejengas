﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Areas.Administration.Controllers
{
    [Authorize]
    public class JugadorController : Controller
    {
        IJugadorRepository repository;

        public JugadorController(IJugadorRepository repo)
        {
            repository = repo;
        }

        #region CRUD Methods

        public ActionResult List()
        {
            return View(repository.Jugadores);
        }

        public ActionResult Edit(int id=0)
        {
            Jugador jugador = repository.Jugadores.FirstOrDefault(j => j.Id == id);
            return View(jugador);
        }

        [HttpPost]
        public ActionResult Edit(Jugador jugador, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    jugador.AvatarMimeType = image.ContentType;
                    jugador.Avatar = new byte[image.ContentLength];
                    image.InputStream.Read(jugador.Avatar, 0, image.ContentLength);
                }
                repository.Guardar(jugador);
                TempData["message"] = string.Format("El jugador {0} fue registado exitosamente", jugador.Nombre);
                return RedirectToAction("List");
            }
            else
            {
                return View(jugador);
            }
        }

        public RedirectToRouteResult Delete(int id)
        {
            if (repository.Eliminar(id))
                TempData["message"] = "Se eliminó el jugador exitosamente";
            else
                TempData["message"] = "El Jugador no fue eliminado";

            return RedirectToAction("List");
        }

        public ViewResult Create() { 
            return View("Edit",new Jugador());
        }
        #endregion

        #region Other
        public FileContentResult ObtenerImagen(int id)
        {
            Jugador jugador = repository.Jugadores.FirstOrDefault(j => j.Id == id);
            if (jugador != null && jugador.Avatar != null && jugador.AvatarMimeType != null)
                return File(jugador.Avatar, jugador.AvatarMimeType);
            return null;
        }       
        #endregion
    }

}
