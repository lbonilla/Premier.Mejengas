using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public DbSet<JuegoJugador> JuegosJugadores { get; set; }

        // Twist our database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            //Binding Foreign Key Objects
            modelBuilder.Entity<Galeria>()
                        .HasRequired(g => g.Juego)
                        .WithMany(j => j.Galerias)
                        .HasForeignKey(g => g.IdJuego);
        }
    }
}
