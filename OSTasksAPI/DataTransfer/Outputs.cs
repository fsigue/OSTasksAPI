namespace OSTasksAPI.DataTransfer
{
    public class TasksOutput
    {
        public string Task_no { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public DateTime Posted { get; set; }
        public DateTime Duedate { get; set; }
        public string Status { get; set; }
        public string Postedby { get; set; }
        public string Collaborator { get; set; }
    }
    public class SubTasksOutput
    {
        public string Ref_no { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Posted { get; set; }
        public string Postedby { get; set; }
    }
    public class DeptOutput
    {
        public string Dept_code { get; set; }
        public string Dept_name { get; set; }
    }
    public class TeamOutput
    {
        public string Team_code { get; set; }
        public string Team_name { get; set; }
    }
    public class EmpOutput
    {
        public string Emp_no { get; set; }
        public string Emp_name { get; set; }
        public string Email_add { get; set; }
        public string Emp_team { get; set; }
    }
}
