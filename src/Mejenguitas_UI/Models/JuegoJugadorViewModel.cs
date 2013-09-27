using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Models
{
    public class JuegoJugadorViewModel
    {
        public List<JuegoJugador> JugadoresInscritos { get; set; }
        public bool EstaInscrito { get; set; }
        public Juego Juego { get; set; }
        public int IdJugador{get;set;}
    }
}