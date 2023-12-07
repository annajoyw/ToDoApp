using System.Linq;
using ToDoApp;
using ToDoApp.Data;
using ToDoApp.Services;
using Xunit;

namespace ToDoAppTests
{
    public class ToDoServiceTests
    {
        private IToDoService _todoService = new ToDoService();

        [Fact]
        public void Get_ReturnsItems()
        {
            Assert.NotNull(_todoService.GetItems());
        }

        [Fact]
        public void Add_UpdatesToDoList()
        {
            var newTodo = new ToDoItem("Walk the dog");
            _todoService.AddItem(newTodo);
            var items = _todoService.GetItems();
            Assert.Equal(2, items.Count());
        }

        [Fact]
        public void Delete_UpdatesToDoList()
        {
            var todo = new ToDoItem("Wash Clothes");
            _todoService.DeleteItem(todo);
            var items = _todoService.GetItems();
            Assert.Equal(0, items.Count());
        }

        [Fact]
        public void ToggleCompleted_UpdatesToDoList()
        {
            var todo = new ToDoItem("Wash Clothes");
            _todoService.ToggleCompleted(todo);
            var items = _todoService.GetItems();
            Assert.Equal(true, items.FirstOrDefault().Completed);
        }

        [Fact]
        public void AddChildToDo_UpdatesToDoList()
        {
            var newChildTodo = new ToDoItem("Get Quaters");
            var todo = new ToDoItem("Wash Clothes");
            var childTodoWrapper = new ToDoSubItemWrapper(todo, newChildTodo);
            _todoService.AddChildItem(childTodoWrapper);
            var items = _todoService.GetItems();
            Assert.Equal(2, items.FirstOrDefault().SubItems.Count());
        }

        [Fact]
        public void DeleteChildToDo_UpdatesToDoList()
        {
            var newChildTodo = new ToDoItem("Get Detergent");
            var todo = new ToDoItem("Wash Clothes");
            var childTodoWrapper = new ToDoSubItemWrapper(todo, newChildTodo);
            _todoService.DeleteChildItem(childTodoWrapper);
            var items = _todoService.GetItems();
            Assert.Equal(0, items.FirstOrDefault().SubItems.Count());
        }

        [Fact]
        public void ToggleCompletedChildToDo_UpdatesToDoList()
        {
            var newChildTodo = new ToDoItem("Get Detergent");
            var todo = new ToDoItem("Wash Clothes");
            var childTodoWrapper = new ToDoSubItemWrapper(todo, newChildTodo);
            _todoService.ToggleCompletedChildItem(childTodoWrapper);
            var items = _todoService.GetItems();
            Assert.Equal(true, items.FirstOrDefault().SubItems.FirstOrDefault().Completed);
        }
    }
}