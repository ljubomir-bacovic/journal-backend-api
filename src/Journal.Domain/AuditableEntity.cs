namespace Journal.Domain;

public abstract class AuditableEntity : BaseEntity<Guid>
{
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
    //public T CreatedBy { get; set; } = default!;
    //public T UpdatedBy { get; set; } = default!;
}
