using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P6ISA_API_RebecaRamirez.Models;

public partial class IsaContext : DbContext
{
    public IsaContext()
    {
    }

    public IsaContext(DbContextOptions<IsaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Engineer> Engineers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectManager> ProjectManagers { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__E67E1A04E4D4A0A4");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Address)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Identificacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD2EF1A248");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Engineer>(entity =>
        {
            entity.HasKey(e => e.EngineerId).HasName("PK__Engineer__1FA0F1EE921DB33F");

            entity.Property(e => e.EngineerId).HasColumnName("EngineerID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EngineersEngineerId).HasColumnName("EngineersEngineerID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Engineers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEngineers567608");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABED0646DDE65");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");

            entity.HasOne(d => d.Client).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKProjects674983");

            entity.HasOne(d => d.ProjectManager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKProjects701787");

            entity.HasMany(d => d.TasksTasks).WithMany(p => p.ProjectsProjects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectsTask",
                    r => r.HasOne<Task>().WithMany()
                        .HasForeignKey("TasksTaskId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKProjects_T532253"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKProjects_T371965"),
                    j =>
                    {
                        j.HasKey("ProjectsProjectId", "TasksTaskId").HasName("PK__Projects__75EFC374FA088D4F");
                        j.ToTable("Projects_Tasks");
                        j.IndexerProperty<int>("ProjectsProjectId").HasColumnName("ProjectsProjectID");
                        j.IndexerProperty<int>("TasksTaskId").HasColumnName("TasksTaskID");
                    });
        });

        modelBuilder.Entity<ProjectManager>(entity =>
        {
            entity.HasKey(e => e.ProjectManagerId).HasName("PK__Project __35F031F101050BD2");

            entity.ToTable("Project Managers");

            entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.ProjectManagers)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKProject Ma656207");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949D10752AE95");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EngineerId).HasColumnName("EngineerID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Engineer).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.EngineerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTasks249865");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC9602F665");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUser854768");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A555F2AFC69");

            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.UserRoleDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
