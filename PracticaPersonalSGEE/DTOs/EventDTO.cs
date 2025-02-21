namespace PracticaPersonalSGEE.DTOs
{
    public class EventDTO
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public required DateTime EventDate { get; set; }

        public required int OrganizedId { get; set; }
    }
}
