using Journal.Domain.Model.ToDoItem;
using Journal.Domain.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Journal.Api.Controllers
{
    [Authorize]
    [Route(Constants.BaseUrl)]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        IToDoItemService _toDoItemService;
        Guid UserId => Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public ToDoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpGet]
        [ProducesResponseType<List<ToDoItemGetListModel>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetUserToDoList()
        {
            var toDoList = await _toDoItemService.GetUserToDoItemsAsync(UserId);
            return Results.Ok(toDoList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> AddToDoItemAsync(ToDoItemCreateModel toDoItemCreate)
        {
            var item = await _toDoItemService.AddToDoItemAsync(toDoItemCreate, UserId);
            var location = Url.Action(nameof(AddToDoItemAsync), new { id = item.Id }) ?? $"api/ToDoItem/{item.Id}";
            return Results.Created(location, item);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IResult> UpdateToDoItemAsync(ToDoItemUpdateModel toDoItemUpdate)
        {
            await _toDoItemService.UpdateToDoItemAsync(toDoItemUpdate);
            return Results.NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> DeleteToDoItemAsync(Guid id)
        {
            await _toDoItemService.DeleteToDoItemAsync(id);
            return Results.NoContent();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType<ToDoItemGetDetailsModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetToDoItem(Guid id)
        {
            var toDoItem = await _toDoItemService.GetToDoItem(id);
            return Results.Ok(toDoItem);
        }
    }
}
