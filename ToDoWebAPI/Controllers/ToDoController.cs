using Microsoft.AspNetCore.Mvc;
using ToDoApp;
using ToDoApp.Data;
using ToDoApp.Services;

namespace ToDoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private IToDoService _todoService;
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger, IToDoService toDoService)
        {
            _logger = logger;
            _todoService = toDoService;
        }

        [Route("get")]
        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            return _todoService.GetItems();
        }

        [Route("add-item")]
        [HttpPost]
        public IEnumerable<ToDoItem> AddItem(ToDoItem newItem)
        {

            _todoService.AddItem(newItem);
            return _todoService.GetItems();
        }

        [Route("add-child-item")]
        [HttpPost]
        public IEnumerable<ToDoItem> AddChildItem(ToDoSubItemWrapper newChildItem)
        {
            _todoService.AddChildItem(newChildItem);
            return _todoService.GetItems();
        }

        [Route("delete")]
        [HttpPost]
        public IEnumerable<ToDoItem> Delete(ToDoItem item)
        {
            _todoService.DeleteItem(item);
            return _todoService.GetItems();
        }

        [Route("delete-child-item")]
        [HttpPost]
        public IEnumerable<ToDoItem> DeleteChildItem(ToDoSubItemWrapper childItem)
        {
            _todoService.DeleteChildItem(childItem);
            return _todoService.GetItems();
        }

        [Route("toggle-completed")]
        [HttpPost]
        public IEnumerable<ToDoItem> ToggleCompleted(ToDoItem item)
        {
             _todoService.ToggleCompleted(item);
            return _todoService.GetItems();
        }

        [Route("toggle-completed-child-item")]
        [HttpPost]
        public IEnumerable<ToDoItem> ToggleCompletedChildItem(ToDoSubItemWrapper childItem)
        {
            _todoService.ToggleCompletedChildItem(childItem);
            return _todoService.GetItems();
        }
    }
}