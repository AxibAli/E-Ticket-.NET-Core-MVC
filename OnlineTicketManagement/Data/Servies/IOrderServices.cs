using OnlineTicketManagement.Models;
using System.Collections.Generic;

namespace OnlineTicketManagement.Data.Servies
{
    public interface IOrderServices
    {
        void StoreOrder(List<ShoppingCartItems> items, int userId, string userEmail);
        List<Order> GetOrdersByUserId(int userId);
    }
}
