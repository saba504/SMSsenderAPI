using AutoMapper;
using SMSsenderAPI.Dto;
using SMSsenderAPI.Interfaces;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Services
{
    public class UserServices
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;


        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;

        }
        public async Task AddUser(UserDto userDTO)
        {
            userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            var user = mapper.Map<User>(userDTO);
            await userRepository.Add(user);
        }
        public async Task<User> ValidateUser(string UserName, string Password)
        {
            return await userRepository.ValidateUser(UserName, Password);

        }
    }
}
