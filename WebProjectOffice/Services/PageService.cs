using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging.Signing;

namespace WebProjectOffice.Services
{
    public class PageService
    {
        private  NavigationManager NavigationManager { get; set; }
		public PageService(NavigationManager navigationManager)
		{
			NavigationManager = navigationManager;
		}

		public void CheckAccess(Roles role)
        {

            if (!(UserService.GetUser().RoleId == (int)role))
                NavigationManager.NavigateTo("/Error");
        }
    }


}
