using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Models
{
    public class TaskInfo
    {
        public string Name;
        public EmployeeOfTask Employee;
        public DateTime Date;
        public string ShortName;
        public int StatusId;
    }
}
