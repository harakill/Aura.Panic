using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Panics.Queries
{
    public class PanicListDto : IMapFrom<Panic>
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Note { get; set; }
    }
}
