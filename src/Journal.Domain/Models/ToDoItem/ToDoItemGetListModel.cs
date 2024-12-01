namespace Journal.Domain.Model.ToDoItem;

public record ToDoItemGetListModel(Guid Id, string Name, DateTimeOffset DueDate);

