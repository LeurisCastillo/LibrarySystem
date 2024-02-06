using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities
{
    public class LoanAndReturn
    {
        [Key]

        public int Id { get; set; }
        public string Employee { get; set; }
        public string Book { get; set; }
        public string User { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal PricePerDay { get; set; }
        public int Days { get; set; }
        public decimal Comments { get; set; }
        public decimal Status { get; set; }
    }
}
