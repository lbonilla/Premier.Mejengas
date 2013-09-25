using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mejenguitas.Domain.Entities
{
    public class JuegoJugador
    {
        public int Id { get; set; }
        public int IdJugador { get; set; }
        public int IdJuego { get; set; }
        public string Puesto { get; set; }
        public int Numero { get; set; }
        public int Equipo { get; set; }
        public int CantLesionados { get; set; }
        public int CantGoles { get; set; }

        //Child Entities

    }
}
