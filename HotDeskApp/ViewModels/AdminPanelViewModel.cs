using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.ViewModels
{
    public class AdminPanelViewModel
    {
        public string EmployeeName { get; set; }

        public string EmployeeSurname { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual Role Role { get; set; }
    }
}
