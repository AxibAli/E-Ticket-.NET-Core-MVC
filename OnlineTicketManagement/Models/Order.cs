using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicketManagement.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string Email { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
