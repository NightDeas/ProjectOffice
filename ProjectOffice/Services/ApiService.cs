using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using ProjectOffice.DataBase.Entities;
using ProjectOffice.Models.DTO;

using SQLitePCL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Services
{
    class ApiService
    {
        public const string URL_adress = "https://localhost:7197";
        private static HttpClient client = new HttpClient();


        public static async Task<List<ProjectOffice.DataBase.Entities.TaskObserveEmployee>> GetTaskObserveEmployees()
        {
            List<ProjectOffice.DataBase.Entities.TaskObserveEmployee> TaskObserveEmployee = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/TaskObserveEmployees");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                TaskObserveEmployee = JsonConvert.DeserializeObject<List<ProjectOffice.DataBase.Entities.TaskObserveEmployee>>(responseBody);
            }
            return TaskObserveEmployee;
        }

        public static async Task<ProjectOffice.DataBase.Entities.TaskObserveEmployee> GetTaskObserveEmployee(int id)
        {
            ProjectOffice.DataBase.Entities.TaskObserveEmployee TaskObserveEmployee = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/TaskObserveEmployees/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                TaskObserveEmployee = JsonConvert.DeserializeObject<ProjectOffice.DataBase.Entities.TaskObserveEmployee>(responseBody);
            }
            return TaskObserveEmployee;
        }

        public static async Task<int> PostTaskObserveEmployee(ProjectOffice.DataBase.Entities.TaskObserveEmployee model)
        {
            int id = 0;
            HttpResponseMessage response = await client.PostAsync($"{URL_adress}/api/TaskObserveEmployees",
                new StringContent(System.Text.Json.JsonSerializer.Serialize(model), null, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                int.TryParse(responseBody, out id);
            }
            return id;
        }

        public static async System.Threading.Tasks.Task PutTaskObserveEmployee(TaskObserveEmployee model)
        {
            //HttpResponseMessage response = await client.PutAsync($"{URL_adress}/api/Task", new StringContent(JsonConvert.SerializeObject(task)));
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //}
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(model);
            var request = new HttpRequestMessage(HttpMethod.Put, $"{URL_adress}/api/TaskObserveEmployees/{model.Id}");
            request.Content = new StringContent(jsonContent, null, "application/json");
            var response = await client.SendAsync(request);
            var jsonText = await response.Content.ReadAsStringAsync();
        }

        public static async System.Threading.Tasks.Task DeleteTaskObserveEmployee(int id)
        {
            //Entities.Task task = new();
            HttpResponseMessage reponse = await client.DeleteAsync($"{URL_adress}/api/TaskObserveEmployees/{id}");
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    task = JsonConvert.DeserializeObject<Entities.Task>(responseBody);
            //}
        }

        public static async Task<List<ProjectOffice.DataBase.Entities.AttachmentsInTask>> GetAttachmentInTask()
        {
            List<ProjectOffice.DataBase.Entities.AttachmentsInTask> AttachmentsInTask = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/AttachmentsInTask");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                AttachmentsInTask = JsonConvert.DeserializeObject<List<ProjectOffice.DataBase.Entities.AttachmentsInTask>>(responseBody);
            }
            return AttachmentsInTask;
        }

        public static async Task<ProjectOffice.DataBase.Entities.AttachmentsInTask> GetAttachmentsInTask(int id)
        {
            ProjectOffice.DataBase.Entities.AttachmentsInTask AttachmentsInTask = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/AttachmentsInTask/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                AttachmentsInTask = JsonConvert.DeserializeObject<ProjectOffice.DataBase.Entities.AttachmentsInTask>(responseBody);
            }
            return AttachmentsInTask;
        }

        public static async Task<int> PostAttachmentInTask(ProjectOffice.DataBase.Entities.AttachmentsInTask model)
        {
            int id = 0;
            HttpResponseMessage response = await client.PostAsync($"{URL_adress}/api/AttachmentInTask",
                new StringContent(System.Text.Json.JsonSerializer.Serialize(model), null, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                int.TryParse(responseBody, out id);
            }
            return id;
        }

        public static async System.Threading.Tasks.Task PutAttahmentInTask(AttachmentsInTask model)
        {
            //HttpResponseMessage response = await client.PutAsync($"{URL_adress}/api/Task", new StringContent(JsonConvert.SerializeObject(task)));
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //}
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(model);
            var request = new HttpRequestMessage(HttpMethod.Put, $"{URL_adress}/api/AttachmentsInTask/{model.Id}");
            request.Content = new StringContent(jsonContent, null, "application/json");
            var response = await client.SendAsync(request);
            var jsonText = await response.Content.ReadAsStringAsync();
        }

        public static async System.Threading.Tasks.Task DeleteAttachmentInTask(int id)
        {
            //Entities.Task task = new();
            HttpResponseMessage reponse = await client.DeleteAsync($"{URL_adress}/api/AttachmentsInTask/{id}");
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    task = JsonConvert.DeserializeObject<Entities.Task>(responseBody);
            //}
        }
        public static async Task<List<ProjectOffice.DataBase.Entities.Project>> GetProjects()
        {
            List<ProjectOffice.DataBase.Entities.Project> projects = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Project");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                projects = JsonConvert.DeserializeObject<List<ProjectOffice.DataBase.Entities.Project>>(responseBody);
            }
            return projects;
        }

        public static async Task<ProjectOffice.DataBase.Entities.Project> GetProject(Guid id)
        {
            ProjectOffice.DataBase.Entities.Project project = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Project/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<ProjectOffice.DataBase.Entities.Project>(responseBody);
            }
            return project;
        }

        public static async Task<List<ProjectOffice.DataBase.Entities.Employee>> GetEmployees()
        {
            List<ProjectOffice.DataBase.Entities.Employee> employees = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Employee");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<ProjectOffice.DataBase.Entities.Employee>>(responseBody);
            }
            return employees;
        }

        public static async Task<List<ProjectOffice.DataBase.Entities.Task>> GetTasks()
        {
            List<ProjectOffice.DataBase.Entities.Task> tasks = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Task");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                tasks = JsonConvert.DeserializeObject<List<ProjectOffice.DataBase.Entities.Task>>(responseBody);
            }
            return tasks;
        }

        public static async Task<List<ProjectOffice.DataBase.Entities.Task>> GetTasks(Guid projectId)
        {
            List<ProjectOffice.DataBase.Entities.Task> tasks = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Task/Project/{projectId}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                tasks = JsonConvert.DeserializeObject<List<ProjectOffice.DataBase.Entities.Task>>(responseBody);
            }
            return tasks;
        }

        public static async Task<int> PostAttachment(AttachmentModel model)
        {
            int id = 0;
            HttpResponseMessage response = await client.PostAsync($"{URL_adress}/api/Attachment",
                new StringContent(System.Text.Json.JsonSerializer.Serialize(model), null, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                id = int.Parse(responseBody);
            }
            return id;
        }

        public static async Task<ProjectOffice.DataBase.Entities.Attachment> GetAttachment(int id)
        {
            ProjectOffice.DataBase.Entities.Attachment attachment = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Attachment/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                attachment = JsonConvert.DeserializeObject<ProjectOffice.DataBase.Entities.Attachment>(responseBody);
            }
            return attachment;
        }

        public static async Task<ProjectOffice.DataBase.Entities.Task> GetTask(Guid id)
        {
            ProjectOffice.DataBase.Entities.Task task = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Task/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<ProjectOffice.DataBase.Entities.Task>(responseBody);
            }
            return task;
        }

        public static async System.Threading.Tasks.Task PostTask(TaskModel task)
        {
            HttpResponseMessage response = await client.PostAsync($"{URL_adress}/api/Task", new StringContent(System.Text.Json.JsonSerializer.Serialize(task), null, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Guid taskId = JsonConvert.DeserializeObject<Guid>(responseBody);
            }
        }

        public static async System.Threading.Tasks.Task PutTask(TaskModel task)
        {
            //HttpResponseMessage response = await client.PutAsync($"{URL_adress}/api/Task", new StringContent(JsonConvert.SerializeObject(task)));
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //}
            var jsonContent = System.Text.Json.JsonSerializer.Serialize(task);
            var request = new HttpRequestMessage(HttpMethod.Put, $"{URL_adress}/api/Task/{task.Id}");
            request.Content = new StringContent(jsonContent, null, "application/json");
            var response = await client.SendAsync(request);
            var jsonText = await response.Content.ReadAsStringAsync();
        }

        public static async System.Threading.Tasks.Task DeleteTask(Guid id)
        {
            //Entities.Task task = new();
            HttpResponseMessage reponse = await client.DeleteAsync($"{URL_adress}/api/Task/{id}");
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    task = JsonConvert.DeserializeObject<Entities.Task>(responseBody);
            //}
        }

        public static async Task<List<ProjectOffice.DataBase.Entities.TaskStatus>> GetTaskStatuses()
        {
            List<ProjectOffice.DataBase.Entities.TaskStatus> taskstatuses = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/TaskStatus");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                taskstatuses = JsonConvert.DeserializeObject<List<ProjectOffice.DataBase.Entities.TaskStatus>>(responseBody);
            }
            return taskstatuses;
        }

        public static async Task<ProjectOffice.DataBase.Entities.TaskStatus> GetTaskStatus(int id)
        {
            ProjectOffice.DataBase.Entities.TaskStatus taskstatus = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/TaskStatus/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                taskstatus = JsonConvert.DeserializeObject<ProjectOffice.DataBase.Entities.TaskStatus>(responseBody);
            }
            return taskstatus;
        }
    }
}
