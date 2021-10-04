using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.ViewModels
{
    public class EditEmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Surname")]
        public string EmployeeSurname { get; set; }
        public string Login { get; set; }

        public virtual Role Role { get; set; }
    }
}
