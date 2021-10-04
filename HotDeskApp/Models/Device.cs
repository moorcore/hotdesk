using System;
using System.Collections.Generic;

#nullable disable

namespace HotDeskApp
{
    public partial class Device
    {
        public Device()
        {
            Workplaces = new HashSet<Workplace>();
        }

        public int DeviceId { get; set; }
        public string DeviceName { get; set; }

        public virtual ICollection<Workplace> Workplaces { get; set; }
    }
}
