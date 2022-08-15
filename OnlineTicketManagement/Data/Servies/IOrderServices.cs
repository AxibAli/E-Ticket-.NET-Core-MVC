using OnlineTicketManagement.Models;
using System.Collections.Generic;

namespace OnlineTicketManagement.Data.Servies
{
    public interface IOrderServices
    {
        void StoreOrder(List<ShoppingCartItems> items, string userId, string userEmail);
        List<Order> GetOrdersByUserId(string userId);
    }
}
