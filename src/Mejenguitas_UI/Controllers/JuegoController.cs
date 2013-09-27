using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mejenguitas.Domain.Abstract;

namespace Mejenguitas_UI.Controllers
{
    public class JuegoController : Controller
    {
        private IJuegoRepository repository;

        public JuegoController(IJuegoRepository repo)
        {
            repository = repo;
        }

        public ActionResult List()
        {
            return View(repository.Juegos.OrderByDescending(j => j.Fecha).Take(3));
        }
    }
}
