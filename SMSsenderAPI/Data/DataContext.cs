using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        public DbSet<Sms> Smses { get; set; }
        public DbSet<Template> Templates { get; set; }
    }
}
