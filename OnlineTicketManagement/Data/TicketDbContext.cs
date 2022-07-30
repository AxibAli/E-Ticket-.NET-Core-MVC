using Microsoft.EntityFrameworkCore;
using OnlineTicketManagement.Models;

namespace OnlineTicketManagement.Data
{
    public class TicketDbContext: DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors_Movies>().HasKey(am => new
            {
                am.MovieId,
                am.ActorId
            });

            modelBuilder.Entity<Actors_Movies>().HasOne(m => m.Movies).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actors_Movies>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.ActorId);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Actors_Movies> Actors_Movies { get; set; }
    }
}
