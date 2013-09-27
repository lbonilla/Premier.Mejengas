using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Concrete
{
    public class EFComentarioRepository : IComentarioRepository
    {
        private EFDbContext context = new EFDbContext();

        public void Guardar(Comentario comentario)
        {
            if (comentario.Id == 0)
            {
                context.Comentarios.Add(comentario);
                context.SaveChanges();
            }
        }
    }
}
