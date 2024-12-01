using AutoMapper;
using AutoMapper.QueryableExtensions;
using Journal.Core.Exceptions;
using Journal.Domain.DataAccess;
using Journal.Domain.Entities;
using Journal.Domain.Model.ToDoItem;
using Journal.Domain.ServiceContracts;
using Microsoft.EntityFrameworkCore;

namespace Journal.Core.Services;

public class ToDoItemService : IToDoItemService
{
    IDataContext _dataContext;
    IRepository<ToDoItem> _toDoItemRepository;
    private readonly IMapper _mapper;
    public ToDoItemService(IDataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _toDoItemRepository = dataContext.GetRepository<ToDoItem>();
    }
    public async Task<ToDoItemGetDetailsModel> AddToDoItemAsync(ToDoItemCreateModel toDoItemCreate, Guid userId)
    {

        var toDoItem = _mapper.Map<ToDoItem>(toDoItemCreate, 
            opt => opt.AfterMap((dest, src) => src.UserId = userId));

        _toDoItemRepository.AddOrUpdate(toDoItem);
        await _dataContext.SaveChangesAsync();
        return _mapper.Map<ToDoItemGetDetailsModel>(toDoItem);
    }

    public async Task<List<ToDoItemGetListModel>> GetUserToDoItemsAsync(Guid userId)
    {
         return await _toDoItemRepository.AsQueryable()
            .Where(x => x.UserId == userId)
            .OrderBy(x => x.DueDate)
            .ThenBy(x => x.Priority)
            .AsNoTracking()
            .ProjectTo<ToDoItemGetListModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task UpdateToDoItemAsync(ToDoItemUpdateModel toDoItemUpdate)
    {
        var toDoItem = _toDoItemRepository.Find(toDoItemUpdate.Id) ?? throw new ToDoItemNotFoundException(toDoItemUpdate.Id);
        _mapper.Map(toDoItemUpdate, toDoItem);

        _toDoItemRepository.AddOrUpdate(toDoItem);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteToDoItemAsync(Guid id)
    {
        var toDoItem = _toDoItemRepository.Find(id) ?? throw new ToDoItemNotFoundException(id);
        _toDoItemRepository.Remove(toDoItem);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<ToDoItemGetDetailsModel> GetToDoItem(Guid id)
    {
        var toDoItem = await _toDoItemRepository.FindAsync(id) ?? throw new ToDoItemNotFoundException(id);
        return _mapper.Map<ToDoItemGetDetailsModel>(toDoItem);
    }
}