using System;
using System.Collections.Generic;

#nullable disable

namespace HotDeskApp
{
    public partial class Workplace
    {
        public int WorkplaceId { get; set; }
        public int ReservationId { get; set; }
        public int DeviceId { get; set; }
        public string Description { get; set; }

        public virtual Device Device { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
