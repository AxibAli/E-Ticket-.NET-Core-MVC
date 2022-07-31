using OnlineTicketManagement.Models;
using System.Collections.Generic;

namespace OnlineTicketManagement.Data.ViewModel
{
    public class NewMovieDropdown
    {
        public NewMovieDropdown()
        {
            Producers = new List<Producer>();
            Actors = new List<Actor>();
            Cinemas = new List<Cinema>();
        }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Producer> Producers { get; set; }
    }
}
