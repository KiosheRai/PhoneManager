using Microsoft.EntityFrameworkCore;
using PhoneManager.Domain;
using PhoneManager.Persistence;
using System;

namespace PhoneManager.Tests.Common
{
    public static class PhonesContextFactory
    {
        public static Guid phonefordelete = Guid.NewGuid();
        public static Guid phoneforupdate = Guid.NewGuid();

        public static PhoneManagerDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PhoneManagerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PhoneManagerDbContext(options);
            context.Database.EnsureCreated();
            context.Phones.AddRange(
                new Phone
                {
                    Id = Guid.Parse("DBE15A20-05A4-466D-97CA-4C3243ABEDF6"),
                    MobilePhone = "+375293213212",
                    JobTitle = "Строитель",
                    BirthDate = DateTime.Today,
                    Name = "Светов",
                    isDeleted = false
                },
                 new Phone
                 {
                     Id = phonefordelete,
                     MobilePhone = "+375292313212",
                     JobTitle = "Разрушитель",
                     BirthDate = DateTime.Today,
                     Name = "Летов",
                     isDeleted = false
                 },
                  new Phone
                  {
                      Id = phoneforupdate,
                      MobilePhone = "+375295413212",
                      JobTitle = "Управляющий",
                      BirthDate = DateTime.Today,
                      Name = "Котлетов",
                      isDeleted = false
                  }
             );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(PhoneManagerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
