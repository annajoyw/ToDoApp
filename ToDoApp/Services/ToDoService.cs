namespace ToDoApp.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IList<ToDoItem> _todoItems;

        public ToDoService()
        {
            _todoItems = new List<ToDoItem> {
            new ToDoItem("Wash Clothes"),
            new ToDoItem("Clean Desk")
        };
        }

        public void Add(ToDoItem item)
        {
            _todoItems.Add(item);
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _todoItems.ToList();
        }

        public void Delete(ToDoItem item)
        {
            _todoItems.Remove(item);
        }

        public void Complete(ToDoItem item)
        {
            item.Completed = true;
        }

        public void Uncomplete(ToDoItem item)
        {
            item.Completed = false;
        }
    }
}
