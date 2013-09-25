using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Concrete
{
    public class EFGaleriaRepository : IGaleriaRepository
    {
        private EFDbContext context = new EFDbContext();

        public void Guardar(Galeria galeria)
        {
            if (galeria.Id == 0)
            {
                context.Galerias.Add(galeria);
                context.SaveChanges();
            }
        }

        public bool Eliminar(int id)
        {
            bool result = false;
            Galeria galeria = context.Galerias.FirstOrDefault(g => g.Id == id);
            if (galeria != null)
            {
                context.Galerias.Remove(galeria);
                context.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
