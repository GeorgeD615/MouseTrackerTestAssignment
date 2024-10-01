using Microsoft.EntityFrameworkCore;
using MouseTrackerTestAssignment.Db.Models;

namespace MouseTrackerTestAssignment.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<MouseMovement> MouseMovements { get; set; }
    }
}
