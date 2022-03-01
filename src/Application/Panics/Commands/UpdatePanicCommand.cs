using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Panics.Commands
{
    public class UpdatePanicCommand : IRequest
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Note { get; set; }
    }

    public class UpdatePanicCommandHandler : IRequestHandler<UpdatePanicCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePanicCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePanicCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Panics.FindAsync(request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Panic), request.Id);

            entity.FullName = request.FullName;
            entity.Phone = request.Phone;
            entity.Latitude = request.Latitude;
            entity.Longitude = request.Longitude;
            entity.Note = request.Note;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
