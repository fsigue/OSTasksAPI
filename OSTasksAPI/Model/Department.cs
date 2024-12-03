using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OSTasksAPI.Model;

[Table("Department", Schema = "dbo")]
public partial class Department
{
    [Key]
    [Column("DEPARTMENT_ID")]
    public Guid DepartmentId { get; set; }

    [Column("DEPT_CODE")]
    [StringLength(250)]
    public string DeptCode { get; set; } = null!;

    [Column("DEPARTMENT")]
    [StringLength(250)]
    public string Department1 { get; set; } = null!;

    [Column("SECTION")]
    [StringLength(250)]
    public string Section { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("DepartmentNavigation")]
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
