using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.ApiLibrary.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }

        public string Position { get; set; } = null!;

        public string? FirfstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public string? Email { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public DateTime CreatedTimeStamp { get; set; }

        public DateTime? UpdateTimeStamp { get; set; }

        public DateTime? DeletedTimeStamp { get; set; }

        public DateTime? LastEnterTimeStamp { get; set; }


    }
}
