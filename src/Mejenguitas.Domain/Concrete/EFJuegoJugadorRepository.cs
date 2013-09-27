using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Concrete
{
    public class EFJuegoJugadorRepository : IJuegoJugadorRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<JuegoJugador> JuegosJugadores { get { return context.JuegosJugadores; } }

        public void Guardar(int idJuego, int idJugador,  int equipo, string puesto)
        {
            JuegoJugador juegoJugador = context.JuegosJugadores.FirstOrDefault(j => j.IdJuego == idJuego && j.IdJugador == idJugador);
            if (juegoJugador == null)
            {
                juegoJugador = new JuegoJugador { IdJuego = idJuego, IdJugador = idJugador, Puesto = puesto, Equipo = equipo };
                context.JuegosJugadores.Add(juegoJugador);
            }
            else
            {
                juegoJugador.Equipo = equipo;
                juegoJugador.Puesto = puesto;
            }
            context.SaveChanges();
        }
    }
}
