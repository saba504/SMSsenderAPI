using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Data;
using SMSsenderAPI.Interfaces;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {

        }
        public async Task<bool> ExistedUser(string userName)
        {
            return await context.Users.AnyAsync(x => x.UserName == userName);
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;

            }
            return null;
        }
    }
}
