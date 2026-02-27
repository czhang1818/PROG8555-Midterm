// Student Name: Chunxi Zhang
// Student ID: 8971818

using Microsoft.AspNetCore.Mvc;
using MoviesApp.Models;
using MoviesApp.Repositories;

namespace MoviesApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMoviesRepository _repository;

        public MovieController(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var movies = _repository.GetAll();
            return View(movies);
        }

        public IActionResult GetById(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(newMovie);
                return RedirectToAction("Index");
            }
            return View(newMovie);
        }

        public IActionResult Edit(int id)
        {
            var updateMovie = _repository.GetById(id);
            if (updateMovie == null) return NotFound();
            return View(updateMovie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie updateMovie)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(updateMovie);
                return RedirectToAction("Index");
            }
            return View(updateMovie);
        }

        public IActionResult Delete(int id)
        {
            var deleteMovie = _repository.GetById(id);
            if (deleteMovie == null) return NotFound();
            return View(deleteMovie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}