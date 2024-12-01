using Journal.Domain.Types;

namespace Journal.Domain.Entities;

public class ToDoItem : AuditableEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public TaskPriority? Priority { get; set; }
    public DateTimeOffset? DueDate { get; set; }
    public bool ExactDateTime { get; set; } = false;
    public int? Duration { get; set; }
    public bool Completed { get; set; } = false;
}
