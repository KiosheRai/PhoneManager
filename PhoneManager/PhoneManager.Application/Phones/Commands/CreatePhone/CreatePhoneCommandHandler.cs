using MediatR;
using PhoneManager.Application.Interfaces;
using PhoneManager.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneManager.Application.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommandHandler 
        : IRequestHandler<CreatePhoneCommand, Guid>
    {
        private readonly IPhoneManagerDbContext _dbContext;

        public CreatePhoneCommandHandler(IPhoneManagerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePhoneCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new Phone
            {
               Id = Guid.NewGuid(),
               Name = request.Name,
               MobilePhone = request.MobilePhone,
               BirthDate = request.BirthDate,
               JobTitle = request.JobTitle,
               isDeleted = false
            };

            await _dbContext.Phones.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
