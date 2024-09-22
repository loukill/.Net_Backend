namespace AuthApp.Models
{
    public class POS
    {
        public int POSId { get; set; }
        public string? POSName { get; set; }
        public string? POSLocation { get; set; }
        public string? ImageUrl { get; set; }
        public string? AdminId { get; set; } 
        public AppUser? Admin { get; set; } 

        // Propriétés de navigation pour les relations
        public ICollection<Service>? Services { get; set; }
        public ICollection<AppUser>? Clients { get; set; } 
        public ICollection<AppUser>? Prestataires { get; set; }
        public ICollection<POSClient> POSClients { get; set; } 
        public ICollection<POSPrestataire> POSPrestataires { get; set; }
    }
}
