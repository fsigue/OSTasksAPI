namespace OSTasksAPI.DataTransfer
{
    public class OpenTaskOutput
    {
        public string Task_no { get; set; }
        public DateTime Posted { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Assignee { get; set; }
        public string Status { get; set; }
    }
}
