using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;
using Mejenguitas_UI.Infrastructure.Abstract;

namespace Mejenguitas_UI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        IJugadorRepository repository;

        public FormsAuthProvider(IJugadorRepository repo) 
        {
            repository = repo;
        }

        public Jugador Authenticate(string correo, string contrasenna)
        {            
            Jugador jugador = repository.Autenticar(correo, contrasenna);
            if (jugador != null)
            {
                FormsAuthentication.SetAuthCookie(correo, false);
            }
            return jugador;
        }

        public void LogOut()
        {      
            FormsAuthentication.SignOut();            
        }
    }
}