using OnlineTicketManagement.Data.Base;
using OnlineTicketManagement.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicketManagement.Models
{
    public class NewMoviesVM
    {
        public int Id { get; set; }
        [DisplayName("Movie Name")]
        [Required(ErrorMessage = "Movie Name is Required")]
        public string Name { get; set; }
        [DisplayName("Movie Description")]
        [Required(ErrorMessage = "Movie Description is Required")]
        public string Description { get; set; }
        [DisplayName("Movie Price PKR")]
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
        [DisplayName("Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster is Required")]
        public string ImageUrl { get; set; }
        [DisplayName("Movie Start Date")]
        [Required(ErrorMessage = "Start date is Required")]
        public DateTime StartDate { get; set; }
        [DisplayName("Movie End Date")]
        [Required(ErrorMessage = "Movie end date is Required")]
        public DateTime EndDate { get; set; }
        [DisplayName("Select Movie Category")]
        [Required(ErrorMessage = "Movie Category is Required")]
        public MoviesCategory MovieCategory { get; set; }
        [DisplayName("Select Actor(s)")]
        [Required(ErrorMessage = "Actors is Required")]
        public List<int> ActorIds { get; set; }
        [DisplayName("Select Cinema")]
        [Required(ErrorMessage = "Ciname is Required")]
        public int CinemaId { get; set; }
        [DisplayName("Select Producer")]
        [Required(ErrorMessage = "Producer is Required")]
        public int ProducerId { get; set; }

    }
}
