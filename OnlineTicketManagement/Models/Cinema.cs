using OnlineTicketManagement.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicketManagement.Models
{
    public class Cinema :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Logo is a Required Field")]
        public string Logo { get; set; }
        [Required(ErrorMessage = "Name is a Required Field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is a Required Field")]
        public string Description { get; set; }

        // RelationShips

        public List<Movies> Movies { get; set; }


    }
}
