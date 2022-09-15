using Microsoft.EntityFrameworkCore;
using PhoneManager.Application.Common.Exceptions;
using PhoneManager.Application.Phones.Commands.DeletePhone;
using PhoneManager.Tests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneManager.Tests.Phones.Commands
{
    public class DeletePhoneCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeletePhoneCommandHandler_Success()
        {
            //Arrange
            var handler = new DeletePhoneCommandHandler(context);

            //Act
            var PhoneId = await handler.Handle(
                new DeletePhoneCommand
                {
                    Id = PhonesContextFactory.phonefordelete
                },
                CancellationToken.None);

            //Assert
            Assert.Null(
                await context.Phones.SingleOrDefaultAsync(Phone =>
                Phone.Id == PhonesContextFactory.phonefordelete && Phone.isDeleted != true));
        }

        [Fact]
        public async Task DeletePhoneCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeletePhoneCommandHandler(context);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeletePhoneCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }

    }
}
