using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Abstract
{
    public interface IJuegoRepository
    {
        IQueryable<Juego> Juegos { get; }
        void Guardar(Juego juego);
        bool Eliminar(int id);
    }
}
