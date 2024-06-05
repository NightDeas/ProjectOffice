using ProjectOffice.DataBase.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.ApiLibrary.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public int RoleId { get; set; }

        public bool IsBanned { get; set; }

        public string? Reason { get; set; }


        public static UserModel ToDbModel(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                RoleId = user.RoleId,
                IsBanned = user.IsBanned,
                Reason = user.Reason,
            };
        }


    }
}
