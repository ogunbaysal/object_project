using Microsoft.EntityFrameworkCore;
using server.Models.Category;
using server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Helpers
{
    public class ModelContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories {get; set;}
        public ModelContext(DbContextOptions options) : base(options) { }

    }
}
