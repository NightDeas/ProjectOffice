using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.ApiLibrary.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? Type { get; set; }
    }
}
