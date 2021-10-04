using System.ComponentModel.DataAnnotations;

namespace HotDeskApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is a required field!")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Surname is a required field!")]
        public string EmployeeSurname { get; set; }

        [Required(ErrorMessage = "Login is a required field!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is a required field!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
