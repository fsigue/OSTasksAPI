using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OSTasksAPI.Model;

[Table("Employee", Schema = "dbo")]
public partial class Employee
{
    [Column("EMPLOYEE_ID")]
    public Guid EmployeeId { get; set; }

    [Column("DEPARTMENT_ID")]
    public Guid DepartmentId { get; set; }

    [Key]
    [Column("EMPLOYEE_NO")]
    [StringLength(250)]
    public string EmployeeNo { get; set; } = null!;

    [Column("FIRSTNAME")]
    [StringLength(250)]
    public string Firstname { get; set; } = null!;

    [Column("LASTNAME")]
    [StringLength(250)]
    public string Lastname { get; set; } = null!;

    [Column("MIDNAME")]
    [StringLength(250)]
    public string Midname { get; set; } = null!;

    [Column("EMAIL_ADD")]
    [StringLength(250)]
    public string EmailAdd { get; set; } = null!;

    [Column("TEAM_CODE")]
    [StringLength(250)]
    public string? TeamCode { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Employees")]
    public virtual Department Department { get; set; } = null!;

    [InverseProperty("AssigneeNavigation")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
