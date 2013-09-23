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
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Resultado { get; set; }
        
        [Required]        
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }


        public string Lugar { get; set; }
        public int EquipoGanador { get; set; }
    }
}
