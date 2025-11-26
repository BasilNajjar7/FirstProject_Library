using System.ComponentModel.DataAnnotations;

namespace FirstProject_Library.Model
{
    public class BookReceive
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required, MaxLength(50)]
        public string Auther { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
    }
}