using System.ComponentModel.DataAnnotations;

namespace FirstProject_Library.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required,MaxLength(20)]
        public string FirstName { get; set; }
        [Required,MaxLength(20)]
        public string LastName { get; set; }
        [Required,MaxLength(50)]
        public string MyCategory { get; set; }
        public int Salary { get; set; }
        public List<Book>Books { get; set; }
    }
}
