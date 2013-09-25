using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mejenguitas.Domain.Entities
{
    public class Galeria
    {
        public int Id { get; set; }
        public int IdJuego { get; set; }
        public string Descripcion { get; set; }
        public byte[] Objecto { get; set; }
        public string MimeTypeObjeto { get; set; }

        public virtual Juego Juego { get; set; }
    }
}
