using ToDoApp.Data;

namespace ToDoApp.Services
{
    public interface IToDoService
    {
        public IEnumerable<ToDoItem> GetItems();
        public void AddItem(ToDoItem item);
        public void AddChildItem(ToDoSubItemWrapper item);
        public void DeleteItem(ToDoItem item);
        public void DeleteChildItem(ToDoSubItemWrapper item);
        public void ToggleCompleted(ToDoItem item);
        public void ToggleCompletedChildItem(ToDoSubItemWrapper item);
    }
}
