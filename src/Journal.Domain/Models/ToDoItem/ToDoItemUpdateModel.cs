using Journal.Domain.Types;

namespace Journal.Domain.Model.ToDoItem;

public record ToDoItemUpdateModel(Guid Id, string Name, string Description, TaskPriority? Priority,
    DateTime? DueDate, bool ExactDateTime, int? Duration, bool IsCompleted);