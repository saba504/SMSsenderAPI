using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SMSsenderAPI.Models;

namespace SMSsenderAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(options: opts) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Sms2Template>(entity =>
            //{
            //    entity.Property(e => e.Sms)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Template)
            //    .IsRequired()
            //    .HasMaxLength(255)
            //    .IsUnicode(false);

                
            //});
         }


        public DbSet<Sms> Smses { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Sms2Template> Sms2Template { get; set; }
    }
}
