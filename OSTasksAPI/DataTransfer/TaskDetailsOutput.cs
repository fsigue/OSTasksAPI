namespace OSTasksAPI.DataTransfer
{
    public class TaskDetailsOutput
    {
        public string Task_no { get; set; }
        public string Task_title { get; set; }
        public DateTime Posted { get; set; }
        public string DueDate { get; set; }
        public string Department { get; set; }
        public string Assignee { get; set; }
        public string Collaborators { get; set; }
        public string Descrpition { get; set; }

        public string Status { get; set; }
    }
}
