using System.ComponentModel.DataAnnotations;

namespace WebApiCoreCollectonCRUD.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id{ get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 30 characters")]
        public string Name { get; set; }
        public string Department { get; set; }
        [Range(1000000000, 9999999999, ErrorMessage = "MobileNo should be a valid 10-digit number")]
        public long MobileNo { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }

}
