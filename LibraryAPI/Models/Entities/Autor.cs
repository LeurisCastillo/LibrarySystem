using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
        public string NativeLanguage { get; set; }
        public string status { get; set; }
    }
}
