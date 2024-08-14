using System.ComponentModel.DataAnnotations;

namespace AuthApp.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public ICollection<UserService> UserServices { get; set; }
    }
}
