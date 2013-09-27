using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Mejenguitas.Domain.Entities
{
    public class Juego
    {
        public Juego()
        {
            this.Galerias = new HashSet<Galeria>();
        }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Resultado:")]
        public string Resultado { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha:")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Lugar:")]
        public string Lugar { get; set; }

        [Display(Name="Equipo Ganador:")]
        [HiddenInput(DisplayValue = false)]
        public int EquipoGanador { get; set; }
        
        [HiddenInput(DisplayValue=false)]
        public int Estado { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<Galeria> Galerias { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
