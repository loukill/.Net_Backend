namespace AuthApp.DTOs
{
    public class EventRequest
    {
        public string? ClientName { get; set; }
        public string Description { get; set; }
        public string? PrestataireName { get; set; }
        public string? AdminName { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
