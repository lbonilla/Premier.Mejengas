using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Abstract
{
    public interface IJuegoJugadorRepository
    {
        IQueryable<JuegoJugador> JuegosJugadores { get; }

        void Guardar(int idJuego, int idJugador, int equipo, string puesto, bool esInvitado);
    }
}
