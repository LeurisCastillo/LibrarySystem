using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities
{
    public class Book
    {
        [Key]

        public int Id { get; set; }
        public string Description { get; set; }
        public string TopographicSignature { get; set; }
        public string ISBN { get; set; }
        public string Autors { get; set; }
        public string Editorial { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Science { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
    }
}

