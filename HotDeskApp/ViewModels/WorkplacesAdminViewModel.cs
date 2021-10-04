using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.ViewModels
{
    public class WorkplacesAdminViewModel
    {
        public int WorkplaceId { get; set; }
        public int ReservationId { get; set; }
        public int DeviceId { get; set; }
        public string Description { get; set; }

        public virtual Device Device { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
