using Microsoft.EntityFrameworkCore.Storage;
using ProjectOffice.DataBase.Entities;
using System.Runtime.CompilerServices;

namespace WebProjectOffice.Services
{
    public static class UserService
    {
        private static User _user;

        public static async Task<bool> Login(string login, string password)
        {
            var user = await Services.ApiService.GetUser(login, password);
            if (user == null)
                return false;
            _user = user;
            return true;
        }

        public static User GetUser()
        {
            if (_user == null)
                _user = new();
            return _user;
        }

        public static void SetUser(User user)
        {
            _user = user;
        }

        /// <summary>
        /// Проверка пользователя на разрешение на выполнение задач
        /// </summary>
        /// <param name="Role">Требуемая роль</param>
        private static bool CheckAccess(Roles Role)
        {
            if (_user.Role.Id == ((int)Role))
                return true;
            else
                return false;
        }
    }

    public enum Roles
    {
        None = 0,
        Employee = 1,
        Admin = 2

    }
}
