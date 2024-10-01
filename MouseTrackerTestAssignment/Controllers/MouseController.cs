using Microsoft.AspNetCore.Mvc;
using MouseTrackerTestAssignment.Db.Interfaces;
using MouseTrackerTestAssignment.Db.Models;
using MouseTrackerTestAssignment.Models.Mouse;
using Newtonsoft.Json;

namespace MouseTrackerTestAssignment.Controllers
{
    public class MouseController : Controller
    {
        private readonly IMouseTrackerDbRepository mouseTrackerDbRepository;

        public MouseController(IMouseTrackerDbRepository mouseTrackerDbRepository)
        {
            this.mouseTrackerDbRepository = mouseTrackerDbRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMousePositionsAsync([FromBody] List<MousePositionDTO> mousePositions)
        {
            string mouseMovementData = JsonConvert.SerializeObject(mousePositions);
            var mouseMovement = new MouseMovement() { Data = mouseMovementData };
            await mouseTrackerDbRepository.SaveMouseMovementAsync(mouseMovement);
            return RedirectToAction(nameof(Index));
        }
    }
}
