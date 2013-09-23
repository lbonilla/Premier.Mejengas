﻿using System;
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
            return View(repository.Juegos);
        }

        public ActionResult Edit(int id)
        {
            Juego juego = repository.Juegos.FirstOrDefault(p => p.Id == id);
            return View(juego);
        }

        [HttpPost]
        public ActionResult Edit(Juego juego)
        {
            if (ModelState.IsValid)
            {
                repository.Guardar(juego);
                TempData["message"] = string.Format("El partido para la fecha {0} fue salvado.", juego.Fecha);
                return RedirectToAction("List");
            }
            else
            {
                return View(juego);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Juego());
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
    }
}