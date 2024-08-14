using AuthApp.Constants;

namespace AuthApp.DTOs
{
    public class RequestEventDto
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }
        public DateTime DateRequest { get; set; }
        public EventStatus EventStatus { get; set; }
    }
}
