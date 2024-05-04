using AutoMapper;
using Microsoft.Identity.Client;
using ProjectOfficeApi.Controllers;

namespace ProjectOfficeApi.Services
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() {
            CreateMap<TaskRequest, Entities.Task>();
        }
    }
}
