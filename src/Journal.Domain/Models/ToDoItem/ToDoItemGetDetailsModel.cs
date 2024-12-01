using Journal.Domain.Types;

namespace Journal.Domain.Model.ToDoItem;

public record ToDoItemGetDetailsModel(Guid Id, string Name, string Description, TaskPriority? Priority,
    DateTimeOffset? DueDate, bool ExactDateTime, int? Duration, bool Completed);

