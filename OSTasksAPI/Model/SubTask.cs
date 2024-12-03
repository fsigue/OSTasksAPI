using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OSTasksAPI.Model;

[Table("SubTasks", Schema = "dbo")]
public partial class SubTask
{
    [Key]
    [Column("SUBTASK_ID")]
    public Guid SubtaskId { get; set; }

    [Column("TASK_NO")]
    public int TaskNo { get; set; }

    [Column("REF_NO")]
    public int? RefNo { get; set; }

    [Column("TITILE")]
    [StringLength(250)]
    public string Titile { get; set; } = null!;

    [Column("DESCRIPTION")]
    [StringLength(250)]
    public string Description { get; set; } = null!;

    [Column("POSTED", TypeName = "datetime")]
    public DateTime Posted { get; set; }

    [Column("POSTED_BY")]
    [StringLength(250)]
    public string PostedBy { get; set; } = null!;

    [ForeignKey("TaskNo")]
    [InverseProperty("SubTasks")]
    public virtual Task TaskNoNavigation { get; set; } = null!;
}
