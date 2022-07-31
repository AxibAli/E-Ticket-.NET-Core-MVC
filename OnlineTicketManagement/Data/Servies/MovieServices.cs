using Microsoft.EntityFrameworkCore;
using OnlineTicketManagement.Data.Base;
using OnlineTicketManagement.Data.ViewModel;
using OnlineTicketManagement.Models;
using System.Linq;

namespace OnlineTicketManagement.Data.Servies
{
    public class MovieServices:EntityBaseRepository<Movies> , IMovieServices
    {
        private readonly TicketDbContext _db;
        public MovieServices(TicketDbContext db) : base(db)
        {
            _db = db;
        }

        public void AddNewMovie(NewMoviesVM movie)
        {
            var movieData = new Movies()
            {
                Name = movie.Name,
                Description = movie.Description,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                CinemaId = movie.CinemaId,
                ProducerId = movie.ProducerId,
                MovieCategory = movie.MovieCategory
            };
            _db.Movies.Add(movieData);
            _db.SaveChanges();
            
            foreach(var actorId  in movie.ActorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    MovieId = movieData.Id,
                    ActorId = actorId
                };
                _db.Actors_Movies.Add(newActorMovie);

            }
            _db.SaveChanges();
        }

        public Movies GetMovieById(int id)
        {
            var movie = _db.Movies
                .Include(n => n.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefault(m=>m.Id==id);
            return movie;
        }

        public NewMovieDropdown GetNewMovieDropdown()
        {
            var response = new NewMovieDropdown()
            {
                Actors = _db.Actors.OrderBy(a => a.FullName).ToList(),
                Producers = _db.Producers.OrderBy(a => a.FullName).ToList(),
                Cinemas = _db.Cinemas.OrderBy(a => a.Name).ToList()
            };
            return response;
        }

        public void UpdateMovie(NewMoviesVM movie)
        {
            var dbMovies = _db.Movies.FirstOrDefault(n => n.Id == movie.Id);
            if(dbMovies != null)
            {
                dbMovies.Name = movie.Name;
                dbMovies.Description = movie.Description;
                dbMovies.StartDate = movie.StartDate;
                dbMovies.EndDate = movie.EndDate;
                dbMovies.Price = movie.Price;
                dbMovies.ImageUrl = movie.ImageUrl;
                dbMovies.CinemaId = movie.CinemaId;
                dbMovies.ProducerId = movie.ProducerId;
                dbMovies.MovieCategory = movie.MovieCategory;
                _db.SaveChanges();
            }

            var existingActor = _db.Actors_Movies.Where(n => n.MovieId == movie.Id).ToList();
            _db.Actors_Movies.RemoveRange(existingActor);
            _db.SaveChanges();
            foreach (var actorId in movie.ActorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                _db.Actors_Movies.Add(newActorMovie);

            }
            _db.SaveChanges();
        }
    }
}
