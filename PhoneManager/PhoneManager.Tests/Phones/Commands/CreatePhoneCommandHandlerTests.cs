using Microsoft.EntityFrameworkCore;
using PhoneManager.Application.Phones.Commands.CreatePhone;
using PhoneManager.Tests.Common;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneManager.Tests.Phones.Commands
{
    public class CreatePhoneCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreatePhoneCommandHandler_Success()
        {
            //Arrange
            var handler = new CreatePhoneCommandHandler(context);
            var phoneName = "Phone name";
            var phoneNumber = "+375293245623";
            var phoneDate = DateTime.Today;
            var phoneJobTitle = "jobtitle";


            //Act
            var PhoneId = await handler.Handle(
                new CreatePhoneCommand
                {
                    Name = phoneName,
                    JobTitle = phoneJobTitle,
                    MobilePhone = phoneNumber,
                    BirthDate = phoneDate
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Phones.SingleOrDefaultAsync(Phone =>
                Phone.Id == PhoneId
                && Phone.Name == phoneName
                && Phone.MobilePhone == phoneNumber
                && Phone.JobTitle == phoneJobTitle
                && Phone.BirthDate == phoneDate));
        }
    }
}
