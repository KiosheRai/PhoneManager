using Microsoft.EntityFrameworkCore;
using PhoneManager.Application.Interfaces;
using PhoneManager.Domain;
using PhoneManager.Persistence.EntityTypeConfigurations;

namespace PhoneManager.Persistence
{
    public class PhoneManagerDbContext : DbContext, IPhoneManagerDbContext
    {
        public DbSet<Phone> Phones { get; set; }

        public PhoneManagerDbContext(DbContextOptions<PhoneManagerDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PhoneConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
