using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OSTasksAPI.Model;

[Table("Tasks", Schema = "dbo")]
public partial class Task
{
    [Column("TASK_ID")]
    public Guid TaskId { get; set; }

    [Key]
    [Column("TASK_NO")]
    public int TaskNo { get; set; }

    [Column("TITLE")]
    [StringLength(250)]
    public string Title { get; set; } = null!;

    [Column("DESCRIPTION")]
    [StringLength(250)]
    public string Description { get; set; } = null!;

    [Column("ASSIGNEE")]
    [StringLength(250)]
    public string Assignee { get; set; } = null!;

    [Column("TASK_STATUS")]
    [StringLength(250)]
    public string TaskStatus { get; set; } = null!;

    [Column("POSTED", TypeName = "datetime")]
    public DateTime Posted { get; set; }

    [Column("DUE_DATE", TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    [Column("POSTED_BY")]
    [StringLength(250)]
    public string PostedBy { get; set; } = null!;

    [Column("COLLAB")]
    [StringLength(250)]
    public string Collab { get; set; } = null!;

    [Column("DEPARTMENT")]
    [StringLength(250)]
    public string? Department { get; set; }

    [ForeignKey("Assignee")]
    [InverseProperty("Tasks")]
    public virtual Employee AssigneeNavigation { get; set; } = null!;

    [InverseProperty("TaskNoNavigation")]
    public virtual ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
}
