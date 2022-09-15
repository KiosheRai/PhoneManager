using Microsoft.EntityFrameworkCore;
using PhoneManager.Application.Common.Exceptions;
using PhoneManager.Application.Phones.Commands.UpdatePhone;
using PhoneManager.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneManager.Tests.Phones.Commands
{
    public class UpdatePhoneCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdatePhoneCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdatePhoneCommandHandler(context);
            var updatename = "new name";
            var updatejob = "new job";
            var updatephone = "+375293254365";
            var updateDate = DateTime.Today;
            //Act
            var PhoneId = await handler.Handle(
                new UpdatePhoneCommand
                {
                    Id = PhonesContextFactory.phoneforupdate,
                    Name = updatename,
                    JobTitle = updatejob,
                    MobilePhone = updatephone,
                    BirthDate = updateDate,
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Phones.SingleOrDefaultAsync(Phone =>
                Phone.Id == PhonesContextFactory.phoneforupdate
                && Phone.Name == updatename
                && Phone.BirthDate == updateDate
                && Phone.MobilePhone == updatephone
                && Phone.JobTitle == updatejob));
        }

        [Fact]
        public async Task UpdatePhoneCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdatePhoneCommandHandler(context);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
               await handler.Handle(
                   new UpdatePhoneCommand
                   {
                       Id = Guid.NewGuid()
                   },
                   CancellationToken.None));
        }

    }
}
