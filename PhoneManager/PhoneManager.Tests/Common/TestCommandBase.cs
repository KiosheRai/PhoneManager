using PhoneManager.Persistence;
using System;

namespace PhoneManager.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly PhoneManagerDbContext context;

        public TestCommandBase() =>
            context = PhonesContextFactory.Create();


        public void Dispose() =>
            PhonesContextFactory.Destroy(context);
    }
}
