namespace ToDoApp.Services
{
    public interface IToDoService
    {
        public void Add(ToDoItem item);
        public IEnumerable<ToDoItem> GetAll();
        public void Delete(ToDoItem item);
        public void DeleteSubTodo(ToDoItem subItem, ToDoItem item);
        public void Complete(ToDoItem item);
        public void Uncomplete(ToDoItem item);
        public ToDoItem GetSelected();
    }
}
