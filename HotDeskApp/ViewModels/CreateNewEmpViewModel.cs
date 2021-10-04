using System.ComponentModel.DataAnnotations;


namespace HotDeskApp.ViewModels
{
    public class CreateNewEmpViewModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Surname")]
        public string EmployeeSurname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
