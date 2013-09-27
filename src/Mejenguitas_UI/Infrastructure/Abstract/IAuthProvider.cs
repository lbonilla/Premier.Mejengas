using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas_UI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        Jugador Authenticate(string username, string password);
        void LogOut();
    }
}
