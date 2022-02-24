using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Panic> Panics { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
