using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities
{
    public class Language
    {
        [Key]

        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}

