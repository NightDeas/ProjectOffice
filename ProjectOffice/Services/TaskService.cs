﻿using Azure.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ProjectOffice.Entities;
using ProjectOffice.Models;
using ProjectOffice.Pages;
using ProjectOffice.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectOffice.Services
{
    public static class TaskService
    {
        public static TaskControl OldSelectTask { get; set; }
        public static Pages.TaskPage TaskPage { get; } = new Pages.TaskPage();
        public static async System.Threading.Tasks.Task LoadTask(Guid projectId)
        {
            TaskPage.TaskListStackPanel.Children.Clear();
            //var tasks = App.context.Tasks
            //    .Where(x => x.ProjectId == projectId && x.IsDelete == false)
            //    .Include(x => x.ExecutiveEmployeed)
            //.ToList();
            var tasks = await ApiService.GetTasks(projectId);

            foreach (var task in tasks)
            {
                TaskInfo info = new TaskInfo()
                {
                    Name = task.FullTitle,
                    Employee = new EmployeeOfTask(task.ExecutiveEmployeed.FullName, task.ExecutiveEmployeed.ShortName),
                    Date = task.Deadline ?? DateTime.MinValue,
                    ShortName = task.ShortTitle,
                    StatusId = task.StatusId,
                };
                //taskControls.Add(new UserControls.TaskControl(info));
                TaskPage.TaskListStackPanel.Children.Add(new UserControls.TaskControl(info)
                {
                    Tag = task.Id
                });
            }
        }

        public static void LoadDetailTask(DetailedTaskInfo info)
        {
            TaskPage.DetailTaskGrid.Children.Clear();
            UserControls.DetailedTaskControl detailedTaskControl = new(info);
            detailedTaskControl.SetValue(Grid.ColumnProperty, 1);
            TaskService.TaskPage.DetailTaskGrid.Children.Add(detailedTaskControl);
            TaskPage.DetailTaskGrid.Visibility = Visibility.Visible;
        }


        public static void SetStyleSelectTask(TaskControl taskControl)
        {
            ResetStyleOldSelectTask();
            taskControl.BorderMain.Style = (Style)taskControl.Resources["selectTask"];
            OldSelectTask = taskControl;
            taskControl.ImageNext.Visibility = Visibility.Hidden;
        }


        private static void ResetStyleOldSelectTask()
        {
            if (OldSelectTask == null)
                return;
            OldSelectTask.BorderMain.Style = (Style)OldSelectTask.Resources["default"];
            OldSelectTask.ImageNext.Visibility = Visibility.Visible;
        }
    }
}
