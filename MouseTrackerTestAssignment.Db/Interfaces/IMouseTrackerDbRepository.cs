using MouseTrackerTestAssignment.Db.Models;

namespace MouseTrackerTestAssignment.Db.Interfaces
{
    public interface IMouseTrackerDbRepository
    {
        void SaveMouseMovement(MouseMovement mouseMovement);
    }
}