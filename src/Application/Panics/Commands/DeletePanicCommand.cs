using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Panics.Commands
{
    public class DeletePanicCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePanicCommandHandler : IRequestHandler<DeletePanicCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePanicCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePanicCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Panics.FindAsync(request.Id, cancellationToken);

            if(entity == null)
                throw new NotFoundException(nameof(Panic), request.Id);

            _context.Panics.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
