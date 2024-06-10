using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectOffice.DataBase.Entities;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<AttachmentsInTask> AttachmentsInTasks { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<GroupProject> GroupProjects { get; set; }

    public virtual DbSet<HistoryChangeStatus> HistoryChangeStatuses { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<MessagesInTask> MessagesInTasks { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectsInGroupProject> ProjectsInGroupProjects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskObserveEmployee> TaskObserveEmployees { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3VRB7GU;Initial Catalog=113-Burnasov-ProjectOffice;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.Property(e => e.NamePhoto).HasMaxLength(255);
            entity.Property(e => e.Photo).HasColumnType("image");
        });

        modelBuilder.Entity<AttachmentsInTask>(entity =>
        {
            entity.ToTable("AttachmentsInTask");

            entity.HasIndex(e => e.AttachmentId, "IX_AttachmentsInTask_AttachmentId");

            entity.HasIndex(e => e.TaskId, "IX_AttachmentsInTask_TaskId");

            entity.HasOne(d => d.Attachment).WithMany(p => p.AttachmentsInTasks)
                .HasForeignKey(d => d.AttachmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttachmentsInTask_Attachments");

            entity.HasOne(d => d.Task).WithMany(p => p.AttachmentsInTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttachmentsInTask_Tasks");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.DeletedTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastEnterTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.MiddleName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.UpdateTimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<GroupProject>(entity =>
        {
            entity.ToTable("GroupProject");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<HistoryChangeStatus>(entity =>
        {
            entity.ToTable("HistoryChangeStatus");

            entity.HasIndex(e => e.StatusId, "IX_HistoryChangeStatus_StatusId");

            entity.HasIndex(e => e.TaskId, "IX_HistoryChangeStatus_TaskId");

            entity.Property(e => e.ChangeTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.HistoryChangeStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoryChangeStatus_TaskStatuses");

            entity.HasOne(d => d.Task).WithMany(p => p.HistoryChangeStatuses)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoryChangeStatus_Tasks");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<MessagesInTask>(entity =>
        {
            entity.ToTable("MessagesInTask");

            entity.HasIndex(e => e.MessageId, "IX_MessagesInTask_MessageId");

            entity.HasIndex(e => e.TaskId, "IX_MessagesInTask_TaskId");

            entity.HasOne(d => d.Message).WithMany(p => p.MessagesInTasks)
                .HasForeignKey(d => d.MessageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessagesInTask_Messages");

            entity.HasOne(d => d.Task).WithMany(p => p.MessagesInTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessagesInTask_Tasks");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.DeletedTime).HasColumnType("datetime");
            entity.Property(e => e.FinishScheduledDate).HasColumnType("datetime");
            entity.Property(e => e.Icon)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ShortTitle).HasMaxLength(255);
            entity.Property(e => e.StartScheduledDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProjectsInGroupProject>(entity =>
        {
            entity.ToTable("ProjectsInGroupProject");

            entity.HasIndex(e => e.GroupProjectId, "IX_ProjectsInGroupProject_GroupProjectId");

            entity.HasIndex(e => e.ProjectId, "IX_ProjectsInGroupProject_ProjectId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.GroupProject).WithMany(p => p.ProjectsInGroupProjects)
                .HasForeignKey(d => d.GroupProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectsInGroupProject_GroupProject");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectsInGroupProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectsInGroupProject_Projects");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasIndex(e => e.ExecutiveEmployeedId, "IX_Tasks_ExecutiveEmployeedId");

            entity.HasIndex(e => e.PreviousTaskId, "IX_Tasks_PreviousTaskId");

            entity.HasIndex(e => e.ProjectId, "IX_Tasks_ProjectId");

            entity.HasIndex(e => e.StatusId, "IX_Tasks_StatusId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.DeletedTime).HasColumnType("datetime");
            entity.Property(e => e.FinishActualTime).HasColumnType("datetime");
            entity.Property(e => e.IsDelete)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.ShortTitle).HasMaxLength(255);
            entity.Property(e => e.StartActualTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

            entity.HasOne(d => d.ExecutiveEmployeed).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ExecutiveEmployeedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Employees");

            entity.HasOne(d => d.PreviousTask).WithMany(p => p.InversePreviousTask)
                .HasForeignKey(d => d.PreviousTaskId)
                .HasConstraintName("FK_Tasks_Tasks");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Projects");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_TaskStatuses");
        });

        modelBuilder.Entity<TaskObserveEmployee>(entity =>
        {
            entity.HasIndex(e => e.EmployeesId, "IX_TaskObserveEmployees_EmployeesId");

            entity.HasIndex(e => e.TaskId, "IX_TaskObserveEmployees_TaskId");

            entity.HasOne(d => d.Employees).WithMany(p => p.TaskObserveEmployees)
                .HasForeignKey(d => d.EmployeesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskObserveEmployees_Employees");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskObserveEmployees)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskObserveEmployees_Tasks");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.Property(e => e.ColorHex).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.Id)
                .HasConstraintName("FK_Users_Employees");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
