using SMSsenderAPI.Models;

namespace SMSsenderAPI.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> ValidateUser(string userName, string password);
        Task<bool> ExistedUser(string userName);

    }
}
