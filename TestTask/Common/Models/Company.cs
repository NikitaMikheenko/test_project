using System.ComponentModel.DataAnnotations;

namespace Common
{
    public class Company
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter name!")]
        [StringLength(100, ErrorMessage = "The name must not exceed 100 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter size!")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Enter organiztion-legal form!")]
        [StringLength(100, ErrorMessage = "Organiztion-legal form must not exceed 100 characters!")]
        public string OrganizationLegalForm { get; set; }
    }
}
