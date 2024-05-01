using Microsoft.IdentityModel.Tokens;
using ProjectOffice.Properties;
using ProjectOffice.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjectOffice.Services
{
    public static class MenuSerivce
    {
        private static ProjectInPanelControl oldSelectProject;

        public static ProjectInPanelControl OldSelectProject
        {
            get { return oldSelectProject; }
            set { oldSelectProject = value; }
        }

        public static void LoadProjects(MainWindow mainWindow)
        {
            var listProject = App.context.Projects.ToList();
            List<ProjectInPanelControl> projects = new();
            foreach (var project in listProject)
            {
                //projects.Add();
                mainWindow.MenuStackPanel.Children.Add(new ProjectInPanelControl(project.FullTitle)
                {
                    Style = (Style)Application.Current.MainWindow.Resources["childrenInPanel"],
                    Tag = project.Id,
                });
            }
        }

        public static void AutoSelectProject(MainWindow mainWindow)
        {
            if (Properties.Settings.Default.ProjectIdLastSelect.IsNullOrEmpty())
                RaiseEventMouseLeftButtonDown(null);
            else
            {
                Guid id = Guid.Parse(Properties.Settings.Default.ProjectIdLastSelect);
                bool any = App.context.Projects.Any(x => x.Id == id);
                if (any)
                {
                    foreach (var project in mainWindow.MenuStackPanel.Children)
                    {
                        if ((project as ProjectInPanelControl).Tag.ToString() == id.ToString())
                        {
                            RaiseEventMouseLeftButtonDown((ProjectInPanelControl)project);
                            return;
                        }
                    }

                }
            }
        }

        private static void RaiseEventMouseLeftButtonDown(ProjectInPanelControl project)
        {
            project ??= App.mainWindow.MenuStackPanel.Children[0] as ProjectInPanelControl;
            MouseButtonEventArgs routedEventArgs = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            routedEventArgs.RoutedEvent = ProjectInPanelControl.MouseLeftButtonDownEvent;
            routedEventArgs.Source = project;
            project.RaiseEvent(routedEventArgs);

        }


        public static void SetStyleSelectProject(ProjectInPanelControl projectInPanelControl)
        {
            ResetStyleOldSelectProject();
            projectInPanelControl.contentLb.Style = (Style)projectInPanelControl.Resources["selectProject"];
            OldSelectProject = projectInPanelControl;
        }

        public static void SaveSelectProject(ProjectInPanelControl projectInPanelControl)
        {
            Properties.Settings.Default.ProjectIdLastSelect = projectInPanelControl.Tag.ToString();
            Properties.Settings.Default.Save();
        }

        private static void ResetStyleOldSelectProject()
        {
            if (OldSelectProject != null)
                OldSelectProject.contentLb.Style = (Style)OldSelectProject.Resources["default"];
        }


    }
}
