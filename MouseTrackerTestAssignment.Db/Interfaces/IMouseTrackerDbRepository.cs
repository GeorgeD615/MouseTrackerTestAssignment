using MouseTrackerTestAssignment.Db.Models;

namespace MouseTrackerTestAssignment.Db.Interfaces
{
    public interface IMouseTrackerDbRepository
    {
        Task SaveMouseMovementAsync(MouseMovement mouseMovement);
    }
}