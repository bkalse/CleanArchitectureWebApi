namespace CleanCQRS.Domain.Common.Entities
{
    public abstract class BaseEntity : AuditableEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
