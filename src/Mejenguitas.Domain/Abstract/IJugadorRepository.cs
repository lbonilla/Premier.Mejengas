using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Abstract
{
    public interface IJugadorRepository
    {
        IQueryable<Jugador> Jugadores { get; }
        void Guardar(Jugador jugador);
        bool Eliminar(int id);
    }
}
