using System.ComponentModel.DataAnnotations;


namespace HotDeskApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Incorrect login!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Incorrect password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
