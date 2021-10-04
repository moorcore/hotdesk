using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HotDeskApp
{
    public partial class Employee
    {
        public Employee()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int EmployeeId { get; set; }

        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Surname")]
        public string EmployeeSurname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
