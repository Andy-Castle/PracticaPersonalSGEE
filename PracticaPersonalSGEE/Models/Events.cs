namespace PracticaPersonalSGEE.Models
{
    public class Events
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public required DateTime EventDate { get; set; }

        public required int OrganizedId { get; set; }

        public Users? Users { get; set; }
    }
}
