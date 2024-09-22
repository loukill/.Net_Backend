namespace AuthApp.Models
{
    public class POSClient
    {
        public int POSId { get; set; }
        public POS POS { get; set; }
        public string ClientId { get; set; }
        public AppUser Client { get; set; }
        public string AdminId { get; set; }
        public AppUser Admin { get; set; }
    }
}
