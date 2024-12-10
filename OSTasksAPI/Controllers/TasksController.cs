using Microsoft.AspNetCore.Mvc;
using OSTasksAPI.DataTransfer;
using OSTasksAPI.Services;

namespace OSTasksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TasksService _tasksService;

        public TasksController(TasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet("tasks")]
        public IActionResult GetTasks()
        {

            var task = _tasksService.GetAllTasks();
            if (task != null && task.Any())
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpGet("tasks/open")]
        public IActionResult OpenTasks()
        {

            var task = _tasksService.GetAllOpenTasks();
            if (task is object)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpGet("tasks/closed")]
        public IActionResult ClosedTasks()
        {

            var task = _tasksService.GetAllClosedTasks();
            if (task is object)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpGet("tasks/id")]
        public IActionResult GetTasksById(int num)
        {

            var task = _tasksService.GetSubTasks(num);
            if (task is object)
            {
                return Ok(task);
            }
            return NotFound();
        }


        [HttpPost("Create Tasks")]
        public IActionResult CreateTasks([FromBody] TasksInputs input)
        {

            var task = _tasksService.CreateNewTask(input);
            if (task is object)
            {
                return Ok(task);
            }
            return NotFound();
        }


        [HttpGet("Department List")]
        public IActionResult DeptList()
        {

            var task = _tasksService.GetAllDept();
            if (task is object)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpGet("Team List")]
        public IActionResult TeamList()
        {

            var task = _tasksService.GetAllTeam();
            if (task is object)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpGet("Employee List")]
        public IActionResult EmpList()
        {

            var task = _tasksService.GetAllEmployee();
            if (task is object)
            {
                return Ok(task);
            }
            return NotFound();
        }

    }
}
