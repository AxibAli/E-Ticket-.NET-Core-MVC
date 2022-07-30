using OnlineTicketManagement.Data.Base;
using OnlineTicketManagement.Models;

namespace OnlineTicketManagement.Data.Servies
{
    public class ProducerServices : EntityBaseRepository<Producer>, IProducerServices
    {
        public ProducerServices(TicketDbContext db) : base(db)
        {
        }
    }
}
