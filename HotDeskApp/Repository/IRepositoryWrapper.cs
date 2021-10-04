using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.Repository
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        //IReservationsRepository Reservations { get; }
        Task SaveAsync();
    }
}
