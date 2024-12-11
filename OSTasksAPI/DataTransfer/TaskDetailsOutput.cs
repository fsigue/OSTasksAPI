namespace OSTasksAPI.DataTransfer
{
    public class TaskDetailsOutput
    {
        public string Task_no { get; set; }
        public DateTime Posted { get; set; }
        public DateTime DueDate { get; set; }
        public string Department { get; set; }
        public string Assignee { get; set; }
        public string Collaborators { get; set; }

        public string Status { get; set; }
    }
}
