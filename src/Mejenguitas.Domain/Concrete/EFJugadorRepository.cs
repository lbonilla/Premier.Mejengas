﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Abstract;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Concrete
{
    public class EFJugadorRepository:IJugadorRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Jugador> Jugadores
        {
            get { return context.Jugadores; }
        }

        public void Guardar(Jugador jugador)
        {
            if (jugador.Id == 0)
            {
                context.Jugadores.Add(jugador);
            }
            else
            {
                Jugador dbEntry = context.Jugadores.Find(jugador.Id);
                if (dbEntry != null)
                {
                    dbEntry.NickName = jugador.NickName;
                    if (jugador.Avatar != null && jugador.AvatarMimeType != null) 
                    {
                        dbEntry.Avatar = jugador.Avatar;
                        dbEntry.AvatarMimeType = jugador.AvatarMimeType;    
                    }                    
                    dbEntry.Contrasenna = jugador.Contrasenna;
                    dbEntry.Correo = jugador.Correo;
                    dbEntry.Nombre = jugador.Nombre;
                    dbEntry.Telefono = jugador.Telefono;
                    dbEntry.Administrador = jugador.Administrador;
                }
            }
            context.SaveChanges();
        }

        public bool Eliminar(int id)
        {
            bool result = false;
            var jugador = context.Jugadores.Find(id);
            if (jugador != null)
            {
                context.Jugadores.Remove(jugador);
                context.SaveChanges();
                result = true;
            }
            return result;
        }

        public Jugador Autenticar(string correo, string contrasenna) 
        {
            Jugador jugador = null;
            jugador = context.Jugadores.FirstOrDefault(j=>j.Correo == correo && j.Contrasenna == contrasenna);
            return jugador;
        }
    }
}
