using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class Worker
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter surname!")]
        [StringLength(100, ErrorMessage = "The surname must not exceed 100 characters!")]
        [RegularExpression(@"^[A-Z][a-z]*", ErrorMessage = "The surname must consist only of letters and begin with a capital letter!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Enter name!")]
        [StringLength(100, ErrorMessage = "The name must not exceed 100 characters!")]
        [RegularExpression(@"^[A-Z][a-z]*", ErrorMessage = "The name must consist only of letters and begin with a capital letter!")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "The middle name must not exceed 100 characters!")]
        [RegularExpression(@"^[A-Z][a-z]*", ErrorMessage = "The middle name must consist only of letters and begin with a capital letter!")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter date of employment!")]
        [RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Invalid date format!")]
        public string DateOfEmployment { get; set; }

        public string Position { get; set; }

        public Company Company { get; set; }
    }
}
