using OnlineTicketManagement.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicketManagement.Models
{
    public class Producer :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        public string ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "*")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "*")]
        public string Bio { get; set; }

        // Relatioships

        public List<Movies> Movies { get; set; }
    }
}
