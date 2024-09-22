namespace AuthApp.DTOs
{
    public class POSWithDetailsDto
    {
        public int? POSId { get; set; }
        public string? POSName { get; set; }
        public string? POSLocation { get; set; }
        public string? ImageUrl { get; set; }
        public List<ServiceDto>? Services { get; set; }
        public List<UserDto>? Clients { get; set; }
        public List<UserDto>? Prestataires { get; set; }
    }
}
