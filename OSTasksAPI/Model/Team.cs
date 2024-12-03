using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OSTasksAPI.Model;

[Table("Team", Schema = "dbo")]
public partial class Team
{
    [Key]
    [Column("TEAM_ID")]
    public Guid TeamId { get; set; }

    [Column("DEPARTMENT_ID")]
    public Guid DepartmentId { get; set; }

    [Column("DEPT_CODE")]
    [StringLength(250)]
    public string DeptCode { get; set; } = null!;

    [Column("DEPARTMENT")]
    [StringLength(250)]
    public string Department { get; set; } = null!;

    [Column("TEAM_NAME")]
    [StringLength(250)]
    public string TeamName { get; set; } = null!;

    [Column("TEAM_CODE")]
    [StringLength(250)]
    public string? TeamCode { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Teams")]
    public virtual Department DepartmentNavigation { get; set; } = null!;
}
