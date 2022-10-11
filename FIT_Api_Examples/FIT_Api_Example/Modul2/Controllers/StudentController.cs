using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
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

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_dbContext.Student.Include(s => s.opstina_rodjenja.drzava).FirstOrDefault(s => s.id == id)); ;
        }

        [HttpPost]
        public ActionResult Add([FromBody] StudentAddVM x)
        {
            var newStudent = new Student
            {
                ime = x.ime.RemoveTags(),
                prezime = x.prezime.RemoveTags(),
                broj_indeksa = x.broj_indeksa,
                datum_rodjenja = x.datum_rodjenja,
                opstina_rodjenja_id = x.opstina_rodjenja_id,
                slika_studenta = Config.SlikeURL + "empty.png",
                created_time = DateTime.Now
            };

            _dbContext.Add(newStudent);
            _dbContext.SaveChanges();
            return Get(newStudent.id);
        }
        

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] StudentUpdateVM x)
        {
            Student student = _dbContext.Student.Include(s => s.opstina_rodjenja.drzava).FirstOrDefault(s => s.id == id);

            if (student == null)
                return BadRequest("pogresan ID");

            student.ime = x.ime.RemoveTags();
            student.prezime = x.prezime.RemoveTags();
            student.broj_indeksa = x.broj_indeksa;
            student.datum_rodjenja = x.datum_rodjenja;
            student.opstina_rodjenja_id = x.opstina_rodjenja_id;

            _dbContext.SaveChanges();
            return Get(id);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Student student = _dbContext.Student.Find(id);

            if (student == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(student);

            _dbContext.SaveChanges();
            return Ok(student);
        }
      
        [HttpGet]
        public PagedList<Student> GetAllPaged(string ime_prezime, int items_per_page, int page_number= 1)
        {
            var data = _dbContext.Student
                .Include(s=>s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime)).OrderByDescending(s => s.id)
                .AsQueryable();
            return PagedList<Student>.Create(data, page_number, items_per_page);
        }

        [HttpGet]
        public List<Student> GetAll(string? ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime)).OrderByDescending(s => s.id)
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpPost("{id}")]
        public ActionResult AddProfileImage(int id, [FromForm] StudentImageAddVM x)
        {
            try
            {
                Student student = _dbContext.Student.Include(s=>s.opstina_rodjenja.drzava).FirstOrDefault(s => s.id == id);

                if (x.slika_studenta != null && student != null)
                {
                    if (x.slika_studenta.Length > 300 * 1000)
                        return BadRequest("max velicina fajla je 300 KB");

                    string ekstenzija = Path.GetExtension(x.slika_studenta.FileName);

                    var filename = $"{Guid.NewGuid()}{ekstenzija}";

                    x.slika_studenta.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
                    student.slika_studenta = Config.SlikeURL + filename;
                    _dbContext.SaveChanges();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }
    }
}
