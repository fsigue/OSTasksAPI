using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OSTasksAPI.Model;

public partial class TaskDBContext : DbContext
{
    public TaskDBContext()
    {
    }

    public TaskDBContext(DbContextOptions<TaskDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<SubTask> SubTasks { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.100.112;Database=OSTICKET;Trusted_Connection=True;Encrypt=False;User ID=sql.webrwtrng;Password=Trngwrite123!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");
        });

        modelBuilder.Entity<SubTask>(entity =>
        {
            entity.Property(e => e.SubtaskId).ValueGeneratedNever();

            entity.HasOne(d => d.TaskNoNavigation).WithMany(p => p.SubTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubTasks_Tasks");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.TaskNo).ValueGeneratedNever();

            entity.HasOne(d => d.AssigneeNavigation).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Employee");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.TeamId).ValueGeneratedNever();

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.Teams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
