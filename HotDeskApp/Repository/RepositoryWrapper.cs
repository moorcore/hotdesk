using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDeskApp.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        protected HotDeskDBContext db { get; set; }
        public RepositoryWrapper(HotDeskDBContext context)
        {
            db = context;
        }

        public IEmployeeRepository Employee => throw new NotImplementedException();

        public Task SaveAsync()
        {
            return db.SaveChangesAsync();
        }
    }
}
