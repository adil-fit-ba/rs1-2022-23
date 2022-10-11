using FIT_Api_Example.Modul2.Models;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<Student> Student { get; set; }

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
    }
}
