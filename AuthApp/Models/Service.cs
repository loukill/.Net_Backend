using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuthApp.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Prix { get; set; }
        public int POSId { get; set; }

        [JsonIgnore]
        public POS? POS { get; set; }
        public ICollection<UserService>? UserServices { get; set; }
    }
}
