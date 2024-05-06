using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Services
{
    class ApiService
    {
        public const string URL_adress = "https://localhost:7197";
        private static HttpClient client = new HttpClient();

        public static async Task<List<Entities.Project>> GetProjects()
        {
            List<Entities.Project> projects = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Project");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                projects = JsonConvert.DeserializeObject<List<Entities.Project>>(responseBody);
            }
            return projects;
        }

        public static async Task<Entities.Project> GetProject(Guid id)
        {
            Entities.Project project = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Project/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                project = JsonConvert.DeserializeObject<Entities.Project>(responseBody);
            }
            return project;
        }

        public static async Task<List<Entities.Employee>> GetEmployees()
        {
            List<Entities.Employee> employees = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Employee");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<Entities.Employee>>(responseBody);
            }
            return employees;
        }

        public static async Task<List<Entities.Task>> GetTasks()
        {
            List<Entities.Task> tasks = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Task");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                tasks = JsonConvert.DeserializeObject<List<Entities.Task>>(responseBody);
            }
            return tasks;
        }

        public static async Task<List<Entities.Task>> GetTasks(Guid projectId)
        {
            List<Entities.Task> tasks = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Task/Project/{projectId}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                tasks = JsonConvert.DeserializeObject<List<Entities.Task>>(responseBody);
            }
            return tasks;
        }

         public static async Task<Entities.Task> GetTask(Guid id)
        {
            Entities.Task task = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/Task/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                task = JsonConvert.DeserializeObject<Entities.Task>(responseBody);
            }
            return task;
        }

        public static async Task DeleteTask(Guid id)
        {
            //Entities.Task task = new();
            HttpResponseMessage reponse = await client.DeleteAsync($"{URL_adress}/api/Task/{id}");
            //if (response.IsSuccessStatusCode)
            //{
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    task = JsonConvert.DeserializeObject<Entities.Task>(responseBody);
            //}
        }

        public static async Task<List<Entities.TaskStatus>> GetTaskStatuses()
        {
            List<Entities.TaskStatus> taskstatuses = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/TaskStatus");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                taskstatuses = JsonConvert.DeserializeObject<List<Entities.TaskStatus>>(responseBody);
            }
            return taskstatuses;
        }

        public static async Task<Entities.TaskStatus> GetTaskStatus(int id)
        {
            Entities.TaskStatus taskstatus = new();
            HttpResponseMessage response = await client.GetAsync($"{URL_adress}/api/TaskStatus/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                taskstatus = JsonConvert.DeserializeObject<Entities.TaskStatus>(responseBody);
            }
            return taskstatus;
        }
    }
}
