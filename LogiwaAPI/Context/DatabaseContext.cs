using LogiwaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LogiwaAPI.Context
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
