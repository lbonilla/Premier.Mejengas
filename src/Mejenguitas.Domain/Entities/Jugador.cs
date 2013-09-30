using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mejenguitas.Domain.Entities
{
    public class Jugador
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el Nombre")]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el Alias")]
        [Display(Name="Alias:")]
        public string NickName { get; set; }

        [Display(Name = "Imagen:")]
        public byte[] Avatar { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AvatarMimeType { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el Correo Electrónico")]
        [Display(Name = "Correo Electrónico:")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Formato invalido de Correo Electrónico")]        
        public string Correo { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la Contraseña")]
        [Display(Name = "Contraseña:")]
        [DataType(DataType.Password)]        
        [MinLengthAttribute(3,ErrorMessage="La contraseña debe contener al menos 3 caracteres")]
        public string Contrasenna { get; set; }

        [Display(Name = "Teléfono:")]
        public string Telefono { get; set; }

        [Display(Name = "Es Administrador:")]        
        public bool Administrador { get; set; }        
    }
}
