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
        public IActionResult SendMousePositions([FromBody] List<MousePositionDTO> mousePositions)
        {
            string mouseMovementData = JsonConvert.SerializeObject(mousePositions);
            var mouseMovement = new MouseMovement() { Data = mouseMovementData };
            mouseTrackerDbRepository.SaveMouseMovement(mouseMovement);
            return RedirectToAction(nameof(Index));
        }
    }
}
