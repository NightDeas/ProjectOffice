using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectOffice.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Position = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirfstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedTimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastEnterTimeStamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Icon = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FinishScheduledDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorEmployeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResponsibleEmployeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ColorHex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsInGroupProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GroupProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsInGroupProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsInGroupProject_GroupProject",
                        column: x => x.GroupProjectId,
                        principalTable: "GroupProject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectsInGroupProject_Projects",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutiveEmployeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartActualTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    FinishActualTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreviousTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees",
                        column: x => x.ExecutiveEmployeedId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Projects",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_TaskStatuses",
                        column: x => x.StatusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks",
                        column: x => x.PreviousTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsInTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsInTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentsInTask_Attachments",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttachmentsInTask_Tasks",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryChangeStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ChangeTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryChangeStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryChangeStatus_TaskStatuses",
                        column: x => x.StatusId,
                        principalTable: "TaskStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryChangeStatus_Tasks",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessagesInTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesInTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagesInTask_Messages",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessagesInTask_Tasks",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskObserveEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskObserveEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskObserveEmployees_Employees",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskObserveEmployees_Tasks",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsInTask_AttachmentId",
                table: "AttachmentsInTask",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsInTask_TaskId",
                table: "AttachmentsInTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChangeStatus_StatusId",
                table: "HistoryChangeStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChangeStatus_TaskId",
                table: "HistoryChangeStatus",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesInTask_MessageId",
                table: "MessagesInTask",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesInTask_TaskId",
                table: "MessagesInTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsInGroupProject_GroupProjectId",
                table: "ProjectsInGroupProject",
                column: "GroupProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsInGroupProject_ProjectId",
                table: "ProjectsInGroupProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskObserveEmployees_EmployeesId",
                table: "TaskObserveEmployees",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskObserveEmployees_TaskId",
                table: "TaskObserveEmployees",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ExecutiveEmployeedId",
                table: "Tasks",
                column: "ExecutiveEmployeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PreviousTaskId",
                table: "Tasks",
                column: "PreviousTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentsInTask");

            migrationBuilder.DropTable(
                name: "HistoryChangeStatus");

            migrationBuilder.DropTable(
                name: "MessagesInTask");

            migrationBuilder.DropTable(
                name: "ProjectsInGroupProject");

            migrationBuilder.DropTable(
                name: "TaskObserveEmployees");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "GroupProject");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TaskStatuses");
        }
    }
}
