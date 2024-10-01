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

        public async Task SaveMouseMovementAsync(MouseMovement mouseMovement)
        {
            await dbContext.MouseMovements.AddAsync(mouseMovement);
            await dbContext.SaveChangesAsync();
        }
    }
}
