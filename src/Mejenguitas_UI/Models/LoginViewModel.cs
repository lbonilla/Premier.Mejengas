using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mejenguitas_UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Por favor ingrese el Usuario")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese la Contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}