using OnlineTicketManagement.Data.Base;
using OnlineTicketManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTicketManagement.Data.Servies
{
    public class ActorServies : EntityBaseRepository<Actor>, IActorServices
    {
        
        public ActorServies(TicketDbContext db) : base(db) { }
    }
}
