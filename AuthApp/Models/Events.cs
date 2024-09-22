using AuthApp.Constants;
using System.ComponentModel.DataAnnotations;

namespace AuthApp.Models
{
    public class Events
    {
        [Key]
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string? PrestataireId { get; set; } 
        public string? AdminId { get; set; }
        public DateTime DateRequest { get; set; }
        public EventStatus EventStatus { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? PrestataireName { get; set; }
        public string? AdminName { get; set; }
        public string? ClientName { get; set; }
        public string? PrestataireResponse { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int PosId { get; set; }
        public POS POS { get; set; }
        public int? ServiceId { get; set; }

        public virtual AppUser Client { get; set; }
        public virtual AppUser? Prestataire { get; set; }
        public virtual AppUser? Admin { get; set; }

    }
}
