using ToDoApp.Data;

namespace ToDoApp.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IList<ToDoItem> _todoItems;
        private readonly ToDoItem _selectedItem;

        public ToDoService()
        {
            //_todoItems = new List<ToDoItem> {
            //new ToDoItem("Wash Clothes", new List<ToDoItem>{new ToDoItem("Get Detergent") })
        }
        

        public void Add(ToDoItem item)
        {
            _todoItems.Add(item);
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _todoItems.ToList();
        }

        public ToDoItem GetSelected()
        {
            return _selectedItem;
        }

        public void Delete(ToDoItem item)
        {
            _todoItems.Remove(item);
        }


        public void DeleteSubTodo(ToDoItem subItem, ToDoItem item)
        {
            item.SubItems.Remove(subItem);
            //_todoItems.Remove(item);
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
