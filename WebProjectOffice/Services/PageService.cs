using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using NuGet.Packaging.Signing;

using Radzen;

namespace WebProjectOffice.Services
{
	public class PageService
	{
		public static List<string> HistoryLinkPage = new List<string>();
		private NavigationManager NavigationManager;
		private DialogService DialogService;

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
				await DialogService.Alert("Недостаточно прав входа на данную страницу!", "Ошибка доступа");
				NavigationManager.NavigateTo("/");
				return false;
            }
			return true;
		}

       
    }


}
