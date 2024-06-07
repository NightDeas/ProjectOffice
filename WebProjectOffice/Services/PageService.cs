using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using NuGet.Packaging.Signing;

using Radzen;

namespace WebProjectOffice.Services
{
    public class PageService
    {
        public static List<string> HistoryLinkPage = new List<string>();
        public NavigationManager NavigationManager;
        [Inject]
        protected DialogService DialogService { get; set; }

        public PageService(NavigationManager navigationManager, DialogService dialogService)
        {
            NavigationManager = navigationManager;
            DialogService = dialogService;
        }
        public void Navigate(string Uri)
        {
            HistoryLinkPage.Add(Uri);
            NavigationManager.NavigateTo(Uri);
        }
        public void NavigateToPage(Uri Uri)
        {
            Navigate(Uri.AbsoluteUri);
        }
        public void NavigateToPage(string Uri)
        {
            Navigate(Uri);
        }
        public async Task<bool> CheckAccess(Roles role)
        {
            if (!(UserService.GetUser().RoleId == (int)role))
            {
                await DialogService.Alert("Недостаточно прав доступа", "Ошибка");
                NavigationManager.NavigateTo("/");
                return false;
            }
            return true;
        }


    }


}
