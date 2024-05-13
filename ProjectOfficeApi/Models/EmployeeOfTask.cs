using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Models
{
    public class EmployeeOfTask
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public EmployeeOfTask(string fullName, string shortName)
        {
            FullName = fullName;
            ShortName = shortName;
        }
    }
}
