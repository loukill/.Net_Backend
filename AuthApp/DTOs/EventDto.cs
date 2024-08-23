namespace AuthApp.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string? ClientId { get; set; }
        public string? Description { get; set; }
        public DateTime DateRequest { get; set; } 
        public string? EventStatus { get; set; }
        public string? PrestataireId { get; set; }
        public string? PrestataireName { get; set; }
        public string? AdminId { get; set; }
        public string? AdminName { get; set; }
        public string? ClientName { get; set; }
    }
}