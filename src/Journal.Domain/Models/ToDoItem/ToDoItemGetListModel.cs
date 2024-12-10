using Journal.Domain.Types;

namespace Journal.Domain.Model.ToDoItem;

public record ToDoItemGetListModel(Guid Id, string Name, string? Description, DateTime DueDate, bool IsCompleted, 
    TaskPriority? Priority);

