using Journal.Domain.Types;

namespace Journal.Domain.Model.ToDoItem;

public record ToDoItemCreateModel(string Name, string? Description, int Priority,
    DateTime? DueDate, bool ExactDateTime, int? Duration);
