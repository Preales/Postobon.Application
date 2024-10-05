namespace Application.Common.Infraestructure.Entities
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public required string UserEmail { get; set; }
        public required string EntityName { get; set; }
        public required string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public required string Changes { get; set; }
    }
}
