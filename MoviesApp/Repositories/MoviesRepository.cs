using MoviesApp.Models;
using MoviesApp.Data;

namespace MoviesApp.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext _db;

        public MoviesRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Movie> GetAll()
        {
            var allMovies = _db.Movies.ToList();
            return allMovies;
        }

        public Movie GetById(int id)
        {
            var oneMovie = _db.Movies.FirstOrDefault(m => m.Id == id);
            return oneMovie;
        }

        public void Add(Movie newMovie)
        {
            _db.Movies.Add(newMovie);
            _db.SaveChanges();
        }

        public void Update(Movie updatedMovie)
        {
            var existMovie = _db.Movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
            if (existMovie != null)
            {
                existMovie.Title = updatedMovie.Title;
                existMovie.ReleaseYear = updatedMovie.ReleaseYear;
                existMovie.Genre = updatedMovie.Genre;
                existMovie.ImgUrl = updatedMovie.ImgUrl;
            }
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
        }
    }
}
