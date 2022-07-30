using OnlineTicketManagement.Data.Base;
using OnlineTicketManagement.Models;

namespace OnlineTicketManagement.Data.Servies
{
    public interface IMovieServices:IEntityBaseRepository<Movies>
    {
        Movies GetMovieById(int id);
    }
}
