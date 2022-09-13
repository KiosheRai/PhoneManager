using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneManager.Application.Common.Exceptions;
using PhoneManager.Application.Interfaces;
using PhoneManager.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneManager.Application.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommandHandler
        : IRequestHandler<UpdatePhoneCommand>
    {
        private readonly IPhoneManagerDbContext _dbContext;

        public UpdatePhoneCommandHandler(IPhoneManagerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdatePhoneCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Phones
                .FirstOrDefaultAsync(phone => phone.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Phone), request.Id);

            entity.Name = request.Name;
            entity.MobilePhone = request.MobilePhone;
            entity.JobTitle = request.JobTitle;
            entity.BirthDate = request.BirthDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
