using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Panics.Queries
{
    public class GetPanicsQuery : IRequest<PanicDto>
    {
    }

    public class GetPanicsQueryHandler : IRequestHandler<GetPanicsQuery, PanicDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPanicsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PanicDto> Handle(GetPanicsQuery request, CancellationToken cancellationToken)
        {
            return (PanicDto)(await _context.Panics.ToListAsync())
                .OrderBy(fn => fn.FullName);
        }
    }
}
