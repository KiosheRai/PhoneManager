using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using PhoneManager.Application.Interfaces;
using PhoneManager.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneManager.Application.Phones.Commands.DeletePhone
{
    public class DeletePhoneCommandHandler 
        : IRequestHandler<DeletePhoneCommand>
    {
        private readonly IPhoneManagerDbContext _dbContext;

        public DeletePhoneCommandHandler(IPhoneManagerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePhoneCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Phones
                .FirstOrDefaultAsync(phone => phone.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Phone), request.Id);

            entity.isDeleted = true;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
