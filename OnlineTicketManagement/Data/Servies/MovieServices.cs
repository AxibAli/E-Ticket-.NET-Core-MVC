using Microsoft.EntityFrameworkCore;
using OnlineTicketManagement.Data.Base;
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

        public Movies GetMovieById(int id)
        {
            var movie = _db.Movies
                .Include(n => n.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefault(m=>m.Id==id);
            return movie;
        }
    }
}
