using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul5_OnlineTestovi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FIT_Api_Examples.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Drzava> Drzava { get; set; } = null!;
        public DbSet<Opstina> Opstina { get; set; } = null!;
        public DbSet<Student> Student { get; set; } = null!;
        public DbSet<Predmet> Predmet { get; set; } = null!;
        public DbSet<Ispit> Ispit { get; set; } = null!;
        public DbSet<PrijavaIspita> PrijavaIspita{ get; set; } = null!;
        public DbSet<AutentifikacijaToken> AutentifikacijaToken{ get; set; } = null!;
        public DbSet<Nastavnik> Nastavnik{ get; set; } = null!;
        public DbSet<KorisnickiNalog> KorisnickiNalog{ get; set; } = null!;
        public DbSet<Obavijest> Obavijest{ get; set; } = null!;
        public DbSet<AkademskaGodina> AkademskaGodina { get; set; } = null!;
        public DbSet<UpisAkGodine> UpisAkGodine { get; set; } = null!;
        public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemu { get; set; } = null!;
        public DbSet<OmiljeniPredmeti> OmiljeniPredmeti { get; set; } = null!;


        public DbSet<AktivacijaTesta> AktivacijaTesta { get; set; } = null!;
        public DbSet<PitanjaPonudjeneOpcije> PitanjaPonudjeneOpcije { get; set; } = null!;
        public DbSet<Pitanje> Pitanje { get; set; } = null!;
        public DbSet<PredmetOblast> PredmetOblast { get; set; } = null!;
        public DbSet<StudentTest> StudentTest { get; set; } = null!;
        public DbSet<StudentTestPitanja> StudentTestPitanja { get; set; } = null!;

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            base.OnConfiguring(optionsBuilder);

          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

         
            //ovdje pise FluentAPI konfiguraciju

            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<Nastavnik>().ToTable("Nastavnik");

         


            base.OnModelCreating(modelBuilder);

        }
    }
}
