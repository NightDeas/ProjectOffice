using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Models
{
    public class EmployeeOfTask
    {
        public string FullName;
        public string ShortName;

        public EmployeeOfTask(string fullName, string shortName)
        {
            FullName = fullName;
            ShortName = shortName;
        }
    }
}
