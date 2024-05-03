using AutoMapper;

using ProjectOfficeApi.Controllers;

namespace ProjectOfficeApi.Services
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() {
            CreateMap<Entities.Task, TaskRequest>();
        }
    }
}
