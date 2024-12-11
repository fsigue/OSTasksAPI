using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSTasksAPI.DataTransfer;
using OSTasksAPI.Model;
using System.Threading.Tasks;

namespace OSTasksAPI.Services
{
    public class TasksService
    {
        private readonly TaskDBContext _tasksService;
        public TasksService(TaskDBContext tasksRepository)
        {
            _tasksService = tasksRepository;
        }

        #region GetAllTasks
        public IEnumerable<MainTaskOutput> GetAllTasks()
        {
            var qryResult = _tasksService.Tasks
                            .Select(m => new MainTaskOutput
                            {
                                Task_no = m.TaskNo.ToString(),
                                Posted = m.Posted,
                                Title = m.Title,
                                Department = m.Department,
                                Assignee = m.Assignee.ToString(),
                                Status = m.TaskStatus,
                            }).ToList();

            return qryResult;
        }
        #endregion


        #region GetAllOpenTasks
        public IEnumerable<OpenTaskOutput> GetAllOpenTasks()
        {
            var qryResult = _tasksService.Tasks
                            .Where(record => record.TaskStatus == "Open")
                            .Select(m => new OpenTaskOutput
                            {
                                Task_no = m.TaskNo.ToString(),
                                Posted = m.Posted,
                                Title = m.Title,
                                Department = m.Department,
                                Assignee = m.Assignee.ToString(),
                                Status = m.TaskStatus,
                            }).ToList();

            return qryResult;
        }
        #endregion

        #region GetAllClosedTasks
        public IEnumerable<ClosedTaskOutput> GetAllClosedTasks()
        {
            var qryResult = _tasksService.Tasks
                            .Where(record => record.TaskStatus == "Closed")
                            .Select(m => new ClosedTaskOutput
                            {
                                Task_no = m.TaskNo.ToString(),
                                Posted = m.Posted,
                                Title = m.Title,
                                Department = m.Department,
                                Assignee = m.Assignee.ToString(),
                                Status = m.TaskStatus,
                            }).ToList();

            return qryResult;
        }
        #endregion

        #region GetSubTasks
        public IEnumerable<TaskDetailsOutput> GetSubTasks(int tasknum)
        {

            var qryResult = _tasksService.SubTasks
                            .Where(m => m.TaskNo == tasknum)
                            .OrderByDescending(m => m.Posted)
                            .Select(m => new TaskDetailsOutput
                            {
                                Task_no = m.TaskNo.ToString(),
                                Task_title = m.Titile,
                                Descrpition = m.Description,
                                Posted = m.Posted,
                                Assignee = m.PostedBy,
                                DueDate = "",
                                Collaborators = m.PostedBy,
                                Department = "",
                                Status = "",

                            }).ToList();

            return qryResult;
        }
        #endregion

        #region CreateNewTask
        public IEnumerable<TasksOutput> CreateNewTask(TasksInputs input)
        {
            int newTaskNumber = NextTaskNumber();

            Guid newGuid = Guid.NewGuid();

            var newTask = new Model.Task
            {
                TaskId = newGuid,
                TaskNo = newTaskNumber,
                Title = input.Title,
                Description = input.Description,
                Department = input.Department,
                Assignee = input.Assignee,
                TaskStatus = "Open",
                Posted = input.Posted,
                DueDate = input.DueDate,
                PostedBy = input.PostedBy,
                Collab = input.Collab,
            };

            _tasksService.Tasks.Add(newTask);


            if (input.RefNo != null) {

                string refDate = RefDate(input.RefNo).ToString();

                Guid newSubGuid = Guid.NewGuid();

                var newSubTask = new Model.SubTask
                {
                    SubtaskId = newSubGuid,
                    TaskNo = newTaskNumber,
                    RefNo = input.RefNo,
                    Titile = "Task Created From Thread Entry",
                    Description = "This Task was created from ",
                    Posted = input.Posted,
                    PostedBy = input.PostedBy,
                };

                _tasksService.SubTasks.Add(newSubTask);

                Guid newRefGuid = Guid.NewGuid();

                var newRefTask = new Model.SubTask
                {
                    SubtaskId = newRefGuid,
                    TaskNo = input.RefNo ?? 0,
                    RefNo = newTaskNumber,
                    Titile = "Task Created From Thread Entry",
                    Description = "Thread Entry " + refDate,
                    Posted = input.Posted,
                    PostedBy = input.PostedBy,
                };

                _tasksService.SubTasks.Add(newRefTask);

            }


            _tasksService.SaveChanges();

            TasksOutput result = new TasksOutput();
            result.Task_no = newTask.TaskNo.ToString();
            result.Title = newTask.Title;
            result.Description = newTask.Description;
            result.Assignee = newTask.Assignee.ToString();
            result.Department = newTask.Department.ToString();
            result.Status = newTask.TaskStatus.ToString();
            result.Posted = newTask.Posted;
            result.Postedby = newTask.PostedBy.ToString();
            result.Duedate = newTask.DueDate;
            result.Collaborator = newTask.Collab;

            return new List<TasksOutput> { result };
        }
        public int NextTaskNumber()
        {
            int nextNo = 100001;
            var lastNo = _tasksService.Tasks
                        .OrderByDescending(t => t.TaskNo)
                        .Select(t => t.TaskNo)
                        .FirstOrDefault();

            if (lastNo != 0)
            {
                nextNo = lastNo + 1;
            }

            return nextNo;
        }

        public DateTime RefDate(int? refNo)
        {
            var postedDate = _tasksService.Tasks
                            .Where(r => r.TaskNo == refNo)
                            .Select(r => r.Posted)
                            .FirstOrDefault();

            return postedDate;
        }

        #endregion

        #region GetAllDept
        public IEnumerable<DeptOutput> GetAllDept()
        {
            var result = _tasksService.Departments
                        .Select(r => new DeptOutput
                        {
                            Dept_code = r.DeptCode.Trim(),
                            Dept_name = r.Department1.Trim()
                        })
                        .ToList();

            return result;
        }
        #endregion

        #region GetAllTeam
        public IEnumerable<TeamOutput> GetAllTeam()
        {
            var result = _tasksService.Teams
                        .Select(r => new TeamOutput
                        {
                            Team_code = r.TeamCode.Trim(),
                            Team_name = r.TeamName.Trim()
                        })
                        .ToList();

            return result;
        }
        #endregion

        #region GetAllEmployee
        public IEnumerable<EmpOutput> GetAllEmployee()
        {
            var result = _tasksService.Employees
                        .Select(r => new EmpOutput
                        {
                            Emp_no = r.EmployeeNo.Trim(),
                            Emp_name = r.Firstname.Trim() + " " + r.Lastname.Trim(),
                            Email_add = r.EmailAdd.Trim(),
                            Emp_team = r.TeamCode
                        })
                        .ToList();

            return result;
        }
        #endregion
    }
}

