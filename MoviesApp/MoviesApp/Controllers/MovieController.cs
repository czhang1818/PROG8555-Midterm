// Student Name: Chunxi Zhang
// Student ID: 8971818

using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class MovieController : Controller
    {
        // TODO: REMOVE this in-memory list completely.
        // TODO: Replace it with a Repository injected through the constructor.
        public List<Movie> Movies = new List<Movie>();

        // TODO: After implementing Repository, delete this constructor.
        public MovieController()
        {
            Movies.Add(new Movie { Id = 101, Title = "Avatar", ReleaseYear = "2026", Genre = "Action", ImgUrl = "avatar.jpg" });
            Movies.Add(new Movie { Id = 102, Title = "Man In Black", ReleaseYear = "2016", Genre = "SciFi", ImgUrl = "mib.jpg" });
            Movies.Add(new Movie { Id = 103, Title = "Home ALONE", ReleaseYear = "1998", Genre = "Comedy", ImgUrl = "hl.jpg" });
            Movies.Add(new Movie { Id = 104, Title = "UP", ReleaseYear = "2018", Genre = "Drama", ImgUrl = "up.jpg" });
        }

        // TODO: After Repository implementation, this method must call repository.GetById(id)
        // TODO: Validate the id before searching.
        public IActionResult GetById(int id)
        {
            Movie Result = Movies.Find(m => m.Id == id);
            return View("GetById", Result);
        }

        // TODO: After Repository implementation, this must call repository.GetAll()
        public IActionResult Index()
        {
            return View("Index", Movies);
        }

        // TODO: Students must implement Add, Edit, Delete actions (GET + POST)
        // TODO: All CRUD actions must use the repository.
    }
}
