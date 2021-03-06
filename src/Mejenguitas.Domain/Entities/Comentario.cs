﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mejenguitas.Domain.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdJuego { get; set; }
        public int IdJugador { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }

        public virtual Juego Juego { get; set; }        
    }
}
