
namespace Domain.Entities
{
    public class Panic : AuditableEntity
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Note { get; set; }
    }
}
