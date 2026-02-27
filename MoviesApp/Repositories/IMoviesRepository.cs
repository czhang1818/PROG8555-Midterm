using MoviesApp.Models;

namespace MoviesApp.Repositories
{
    public interface IMoviesRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}