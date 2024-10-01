using MouseTrackerTestAssignment.Db.Interfaces;
using MouseTrackerTestAssignment.Db.Models;

namespace MouseTrackerTestAssignment.Db.Implementations
{
    public class MouseTrackerDbRepository : IMouseTrackerDbRepository
    {
        private readonly DatabaseContext dbContext;

        public MouseTrackerDbRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveMouseMovement(MouseMovement mouseMovement)
        {
            dbContext.MouseMovements.Add(mouseMovement);
            dbContext.SaveChanges();
        }
    }
}
