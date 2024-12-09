using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OSTasksAPI.DataTransfer
{
    public class TasksInputs
    {
        public int? RefNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string Assignee { get; set; }
        public DateTime Posted { get; set; }
        public DateTime DueDate { get; set; }
        public string PostedBy { get; set; }
        public string Collab { get; set; }
    }
}
