using Microsoft.EntityFrameworkCore;
using OnlineTicketManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTicketManagement.Data.Servies
{
    public class OrderServices : IOrderServices
    {
        private readonly TicketDbContext db;
        public OrderServices(TicketDbContext _db)
        {
            db = _db;
        }
        public List<Order> GetOrdersByUserId(int userId)
        {
            var orders = db.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movies).Where(a => a.UserId == userId).ToList();
            return orders;
        }

        public void StoreOrder(List<ShoppingCartItems> items, int userId, string userEmail)
        {
            var orders = new Order()
            {
                UserId = userId,
                Email = userEmail
            };
            db.Orders.Add(orders);
            db.SaveChanges();
            foreach(var item in items)
            {
                var OrderItems = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movies.Id,
                    OrderId = orders.Id,
                    Price = item.Movies.Price
                };
                db.OrderItems.Add(OrderItems);
            }
            db.SaveChanges();
        }
    }
}
