using System.ComponentModel.DataAnnotations;

namespace OnlineTicketManagement.Models
{
    public class ShoppingCartItems
    {
        [Key]
        public int Id { get; set; }
        public Movies Movies { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }


    }
}
