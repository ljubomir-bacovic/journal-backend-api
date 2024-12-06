using Journal.Domain.Model.ToDoItem;

namespace Journal.Domain.ServiceContracts;

public interface IToDoItemService
{
    Task<ToDoItemGetDetailsModel> AddToDoItemAsync(ToDoItemCreateModel toDoItemCreate, Guid userId);
    Task<List<ToDoItemGetListModel>> GetUserToDoItemsAsync(Guid userId);
    Task UpdateToDoItemAsync(ToDoItemUpdateModel toDoItemUpdate);
    Task DeleteToDoItemAsync(Guid id);
    Task<ToDoItemGetDetailsModel> GetToDoItem(Guid id);
    Task CompleteToDoItemAsync(Guid id);
}
