using Microsoft.AspNetCore.Mvc;
using PlayGroundV2.Models;
using PlayGroundV2.Shared;
using PlayGroundV2.Shared.Tasks;
using PlayGroundV2.Web.Models.Tasks;
using System.Diagnostics;

namespace PlayGroundV2.Controllers
{
    public class TasksController : Controller
    {
        private readonly PlayGroundContext _playGroundContext;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger,
            PlayGroundContext playGroundContext)
        {
            _logger = logger;
            _playGroundContext = playGroundContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new TaskCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(TaskCreateViewModel viewModel)
        {
            var taskManager = new TaskManager(_playGroundContext);

            var task = taskManager.Create(viewModel.Name,
                viewModel.Description,
                viewModel.DueDate,
                viewModel.IsActive);

            if (task == null)
            {
                //return error message
            }

            return View(viewModel);
        }
    }
}