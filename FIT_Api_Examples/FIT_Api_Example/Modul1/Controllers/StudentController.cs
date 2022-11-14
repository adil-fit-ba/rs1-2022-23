using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Modul1.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{ID}")]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.Student.Include(s => s.OpstinaRodjenja.drzava).FirstOrDefault(s => s.ID == id)); ;
        }


        [HttpPost]
        public ActionResult Snimi([FromBody] StudentSnimiVM x)
        {
            Student? student;
            if (x.id ==0)
            {
                student = new Student();
                _dbContext.Add(student);

                student.SlikaKorisnika = Config.SlikeURL + "empty.png";
            }
            else
            {
                student = _dbContext.Student.Include(s => s.OpstinaRodjenja.drzava).FirstOrDefault(s => s.ID == x.id);
                if (student == null)
                    return BadRequest("pogresan ID");
            }

            student.Ime = x.ime.RemoveTags();
            student.Prezime = x.prezime.RemoveTags();
            student.BrojIndeksa = x.broj_indeksa;
            student.DatumRodjenja = x.datum_rodjenja;
            student.OpstinaRodjenjaID = x.opstina_rodjenja_id;

            _dbContext.SaveChanges();
            return Ok(student);
        }

        [HttpPost("{ID}")]
        public ActionResult Delete(int id)
        {
            Student? student = _dbContext.Student.Find(id);

            if (student == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(student);

            _dbContext.SaveChanges();
            return Ok(student);
        }
      
        [HttpGet]
        public PagedList<Student> GetAllPaged(string? ime_prezime, int items_per_page, int page_number= 1)
        {
            var data = _dbContext.Student
                .Include(s=>s.OpstinaRodjenja.drzava)
                .Where(x => ime_prezime == null || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime) || (x.Prezime + " " + x.Ime).StartsWith(ime_prezime)).OrderByDescending(s => s.ID)
                .AsQueryable();
            return PagedList<Student>.Create(data, page_number, items_per_page);
        }

        [HttpGet]
        public List<Student> GetAll(string? ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.OpstinaRodjenja.drzava)
                .Where(x => ime_prezime == null || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime) || (x.Prezime + " " + x.Ime).StartsWith(ime_prezime)).OrderByDescending(s => s.ID)
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{ID}")]
        public ActionResult AddProfileImage(int id, [FromForm] StudentImageAddVM x)
        {
                Student? student = _dbContext.Student.Include(s=>s.OpstinaRodjenja.drzava).FirstOrDefault(s => s.ID == id);

                if (student == null) 
                    return BadRequest("neispravan Student ID");
                if (x.slika_studenta.Length > 300 * 1000)
                    return BadRequest("max velicina fajla je 300 KB");

                string ekstenzija = Path.GetExtension(x.slika_studenta.FileName);

                var filename = $"{Guid.NewGuid()}{ekstenzija}";

                x.slika_studenta.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                student.SlikaKorisnika = Config.SlikeURL + filename;
                _dbContext.SaveChanges();

                return Ok(student);
           
        }
    }
}
