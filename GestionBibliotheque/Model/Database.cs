using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotheque.Model
{
    internal class Database : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
           
        public DbSet<Emprunte> Empruntes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=LibraryApp;Username=postgres;Password=admin;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User { CIN="EE123456", Nom="Mark", Prenom="Alex", Email="test@gmail.com", Password="admin1234", IsAdmin=true });
        }
    }

}
