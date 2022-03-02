using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Panics.Queries
{
    public class GetPanicsQuery : IRequest<IList<PanicDto>>
    {
    }

    public class GetPanicsQueryHandler : IRequestHandler<GetPanicsQuery, IList<PanicDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPanicsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<PanicDto>> Handle(GetPanicsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Panics
                .ProjectTo<PanicDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
