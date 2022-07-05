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
            var taskManager = new TaskManager(_playGroundContext);

            var tasks = taskManager.FindAll();

            var viewModel = new TaskIndexViewModel();

            viewModel.Tasks = tasks.Select(x => new TaskViewModel
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return View(viewModel);
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
                return View("Error");
                //return error message
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var taskManager = new TaskManager(_playGroundContext);
            var task = taskManager.FindById(id);
            if (task == null)
            {
                return NotFound();
            }

            var viewModel = new TaskEditViewModel();
            viewModel.Id = id;
            viewModel.Name = task.Name;
            viewModel.Description = task.Description;
            viewModel.DueDate = task.DueDate;
            viewModel.IsActive = task.IsActive;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(TaskEditViewModel viewModel)
        {
            var taskManager = new TaskManager(_playGroundContext);

            var task = taskManager.Update(
                viewModel.Id,
                viewModel.Name,
                viewModel.Description,
                viewModel.DueDate,
                viewModel.IsActive);

            if (task == null)
            {
                return BadRequest();
                //return error message
            }

            return View(viewModel);
        }

       
        
    }
}