using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mejenguitas.Domain.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NickName { get; set; }
        public byte[] Avatar { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AvatarMimeType { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public string Telefono { get; set; }
    }
}
