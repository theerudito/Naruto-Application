using Microsoft.EntityFrameworkCore;
using Naruto.Models.Model;

namespace Naruto.Data
{
    public class Application_ContextDB : DbContext
    {
        public Application_ContextDB(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}

        public DbSet<Auth> Auth { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Clan> Clan { get; set; }
        public DbSet<Jutsus> Jutsu { get; set; }
        public DbSet<Villages> Village { get; set; }
        public DbSet<Ocupations> Ocupation { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
