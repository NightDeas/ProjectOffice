using Microsoft.EntityFrameworkCore.Storage;
using ProjectOffice.DataBase.Entities;
using System.Runtime.CompilerServices;

namespace WebProjectOffice.Services
{
    public static class UserService
    {
        private static ProjectOffice.ApiLibrary.Models.UserModel _user;
        public static async Task<bool> Login(string login, string password)
        {
            var user = await ProjectOffice.ApiLibrary.Api.GetUserAsync(login, password);
            if (user == null)
                return false;
            _user = user;
            return true;
        }

        public static ProjectOffice.ApiLibrary.Models.UserModel GetUser()
        {
            return _user;
        }


        /// <summary>
        /// Проверка пользователя на разрешение на выполнение задач
        /// </summary>
        /// <param name="Role">Требуемая роль</param>
        public static bool CheckAccess(Roles Role)
        {
            if (_user.RoleId == ((int)Role))
                return true;
            else
                return false;
        }
        public static void ResetUser()
        {
            _user = null;
        }
    }

    public enum Roles
    {
        None = 0,
        Employee = 1,
        Admin = 2

    }
}
