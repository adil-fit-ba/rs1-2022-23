using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul2.Models;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Predmet> Predmet{ get; set; }
        public DbSet<Ocjena> Ocjena{ get; set; }
        public DbSet<Ispit> Ispit { get; set; }
        public DbSet<PrijavaIspita> PrijavaIspita { get; set; }

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
    }
}
