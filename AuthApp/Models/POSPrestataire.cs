using System.Text.Json.Serialization;

namespace AuthApp.Models
{
    public class POSPrestataire
    {
        public int POSId { get; set; }
        [JsonIgnore]
        public POS POS { get; set; }
        public string PrestataireId { get; set; }
        public AppUser Prestataire { get; set; }
    }
}
