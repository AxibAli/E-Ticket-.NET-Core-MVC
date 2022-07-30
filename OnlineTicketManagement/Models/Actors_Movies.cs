namespace OnlineTicketManagement.Models
{
    public class Actors_Movies
    {
        public int MovieId { get; set; }
        public Movies Movies { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

    }
}
