using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Panics.Commands
{
    public class CreatePanicCommand : IRequest<int>
    {
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Note { get; set; }
    }

    public class CreatePanicCommandHandler : IRequestHandler<CreatePanicCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePanicCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePanicCommand request, CancellationToken cancellationToken)
        {
            var entity = new Panic
            {
                FullName = request.FullName,
                Phone = request.Phone,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Note = request.Note,
            };

            _context.Panics.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
