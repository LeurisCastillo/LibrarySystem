using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities
{
    public class User
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string LicenseNumber { get; set; }
        public string PersonType { get; set; }
        public string Status { get; set; }
    }
}
