using OnlineTicketManagement.Data.Base;
using OnlineTicketManagement.Models;

namespace OnlineTicketManagement.Data.Servies
{
    public class CinemaServices : EntityBaseRepository<Cinema> , ICinemaServies
    {
        public CinemaServices(TicketDbContext db):base(db)
        {

        }
    }
}
