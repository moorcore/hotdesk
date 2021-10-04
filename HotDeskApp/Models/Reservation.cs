using System;
using System.Collections.Generic;

#nullable disable

namespace HotDeskApp
{
    public partial class Reservation
    {
        public Reservation()
        {
            Workplaces = new HashSet<Workplace>();
        }

        public int ReservationId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
    }
}
