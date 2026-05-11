using AutoMapper;
using SMSsenderAPI.Dto;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.AutoMapperProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateUsersMapping();
        }

        private void CreateUsersMapping()
        {

            CreateMap<UserDto, User>();

        }
    }
}
