using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneManager.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneManager.Application.Phones.Queries.GetPhoneList
{
    public class GetPhoneListQueryHandler
        : IRequestHandler<GetPhoneListQuery, PhoneListVm>
    {
        private readonly IPhoneManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPhoneListQueryHandler(IPhoneManagerDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PhoneListVm> Handle(GetPhoneListQuery request,
            CancellationToken cancellationToken)
        {
            var query = await _dbContext.Phones
                .Where(x=>x.isDeleted == false)
                .ProjectTo<PhoneLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PhoneListVm { Phones = query };
        }
    }
}
