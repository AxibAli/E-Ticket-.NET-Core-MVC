using OnlineTicketManagement.Data.Base;
using OnlineTicketManagement.Data.ViewModel;
using OnlineTicketManagement.Models;

namespace OnlineTicketManagement.Data.Servies
{
    public interface IMovieServices:IEntityBaseRepository<Movies>
    {
        Movies GetMovieById(int id);
        NewMovieDropdown GetNewMovieDropdown();
        void AddNewMovie(NewMoviesVM movie);
        void UpdateMovie(NewMoviesVM movie);

    }
}
