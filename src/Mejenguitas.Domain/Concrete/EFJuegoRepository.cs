using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Concrete
{
    public class EFJuegoRepository : IJuegoRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Juego> Juegos
        {
            get { return context.Juegos; }
        }

        public void Guardar(Juego juego)
        {
            if (juego.Id == 0)
            {
                juego.Fecha=juego.Fecha.ToUniversalTime();
                context.Juegos.Add(juego);
            }
            else
            {
                Juego dbEntry = context.Juegos.Find(juego.Id);
                if (dbEntry != null)
                {
                    dbEntry.Fecha = juego.Fecha;
                    dbEntry.Lugar = juego.Lugar;
                    dbEntry.Resultado = juego.Resultado;
                    dbEntry.EquipoGanador = juego.EquipoGanador;                    
                }
            }
            context.SaveChanges();
        } 

        public bool Eliminar(int id){

            bool result = false;
            var juego=context.Juegos.Find(id);
            if (juego != null)
            {
                context.Juegos.Remove(juego);
                context.SaveChanges();
                result = true;               
            }
            return result;
        }
    }
}
