using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sms> Smses { get; set; }
        public DbSet<Template> Templates { get; set; }
    }
}
