using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Entities
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string ScheduleType { get; set; }
        public string ComissionPercentage { get; set; }
        public DateTime EntryDate { get; set; }
        public string Status { get; set; }
    }
}
