using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP_Modul10_103022400096.api;

namespace TP_Modul10_103022400096.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>()
        {
            new Film("The Shawshank Redemption", "Frank Darabont", "1994", "Drama", "9.3"),
            new Film("The Godfather", "Francis Ford Coppola", "1972", "Crime, Drama", "9.2"),
            new Film("The Dark Knight", "Christopher Nolan", "2008", "Action, Crime, Drama", "9.0"),
            new Film("Pulp Fiction", "Quentin Tarantino", "1994", "Crime, Drama", "8.9"),
            new Film("The Lord of the Rings: The Return of the King", "Peter Jackson", "2003", "Adventure, Drama, Fantasy", "8.9")
        };
       
        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetAll()
        {
            return Ok(films);
        }

        [HttpGet("{index}")]
        public ActionResult<Film> GetByIndex(int index)
        {
            if (index < 0 || index >= films.Count)
            {
                return NotFound("Film tidak ditemukan");
            }
            return Ok(films[index]);
        }

        [HttpPost]
        public ActionResult Post(Film newFilm)
        {
            films.Add(newFilm);
            return Ok("Film berhasil ditambahkan");
        }

        [HttpDelete("{index}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= films.Count)
            {
                return NotFound("Film tidak ditemukan");
            }
            films.RemoveAt(id);
            return Ok("Film berhasil dihapus");
        }
    }
}
