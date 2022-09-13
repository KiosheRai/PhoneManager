using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneManager.Application.Common.Exceptions;
using PhoneManager.Application.Interfaces;
using PhoneManager.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneManager.Application.Phones.Queries.GetPhoneDetails
{
    public class GetPhoneDetailsQueryHandler
        : IRequestHandler<GetPhoneDetailsQuery, PhoneDetailsVm>
    {
        private readonly IPhoneManagerDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPhoneDetailsQueryHandler(IPhoneManagerDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PhoneDetailsVm> Handle(GetPhoneDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Phones
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Phone), request.Id);

            return _mapper.Map<PhoneDetailsVm>(entity);
        }
    }
}
