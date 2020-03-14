using server.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ModelContext _context;
        public BaseRepository(ModelContext context)
        {
            _context = context;
        }
    }
}
