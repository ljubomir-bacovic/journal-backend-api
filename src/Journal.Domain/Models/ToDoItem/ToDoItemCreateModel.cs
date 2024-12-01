using Journal.Domain.Types;

namespace Journal.Domain.Model.ToDoItem;

public record ToDoItemCreateModel(string Name, string Description, TaskPriority? Priority,
    DateTimeOffset? DueDate, bool ExactDateTime, int? Duration);
