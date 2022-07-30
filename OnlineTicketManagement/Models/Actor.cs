using OnlineTicketManagement.Data.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineTicketManagement.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Profile Picture")]
        [Required(ErrorMessage = "Picture is Required")]
        public string ProfilePictureUrl { get; set; }
        
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Name is Required")]
        public string FullName { get; set; }
        
        [DisplayName("Bio")]
        [Required(ErrorMessage = "Bio is Required")]
        
        public string Bio { get; set; }

        //Relationships
        public List<Actors_Movies> Actor_Movies { get; set; }

    }
}
