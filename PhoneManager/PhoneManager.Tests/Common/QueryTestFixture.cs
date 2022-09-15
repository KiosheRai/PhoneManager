using AutoMapper;
using PhoneManager.Application.Common.Mappings;
using PhoneManager.Application.Interfaces;
using PhoneManager.Persistence;
using PhoneManager.Tests.Common;
using System;
using Xunit;

namespace Notes.Test.Common
{
    public class QueryTestFixture : IDisposable
    {
        public PhoneManagerDbContext context;
        public IMapper mapper;

        public QueryTestFixture()
        {
            context = PhonesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new AssemblyMappingProfile(
                    typeof(IPhoneManagerDbContext).Assembly));
            });

            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose() =>
            PhonesContextFactory.Destroy(context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>{ }
}
