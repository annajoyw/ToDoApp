using ToDoApp.Data;

namespace ToDoApp.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IList<ToDoItem> _todoItems = new List<ToDoItem>
        {
            new ToDoItem("Laundry Day!", new List<ToDoItem>{new ToDoItem("Buy Detergent") }, DateTime.Now) 
        };

        public ToDoService()
        {

        }

        public void AddChildItem(ToDoSubItemWrapper item)
        {
            var parentItem = _todoItems.FirstOrDefault(x => x.Text == item.ParentTodo.Text);
            parentItem.SubItems.Add(item.ChildTodo);
        }

        public void AddItem(ToDoItem item)
        {
            item.Deadline = DateTime.Now.AddDays(1);
            _todoItems.Add(item);
        }

        public void DeleteChildItem(ToDoSubItemWrapper item)
        {
            var parentItem = _todoItems.FirstOrDefault(x => x.Text == item.ParentTodo.Text);
            var childItem = parentItem.SubItems.FirstOrDefault(x => x.Text == item.ChildTodo.Text);
            parentItem.SubItems.Remove(childItem);
        }

        public void DeleteItem(ToDoItem item)
        {
            var targetItem = _todoItems.FirstOrDefault(x => x.Text == item.Text);
            _todoItems.Remove(targetItem);
        }

        public IEnumerable<ToDoItem> GetItems()
        {
            return _todoItems;
        }

        public void ToggleCompleted(ToDoItem item)
        {
            _todoItems.FirstOrDefault(x => x.Text == item.Text).Completed = !item.Completed;
        }

        public void ToggleCompletedChildItem(ToDoSubItemWrapper item)
        {
            var parentItem = _todoItems.FirstOrDefault(x => x.Text == item.ParentTodo.Text);
            var childItem = parentItem.SubItems.FirstOrDefault(x => x.Text == item.ChildTodo.Text);
            childItem.Completed = !childItem.Completed;
            bool allItemsCompleted = parentItem.SubItems.All(x => x.Completed);
            if (allItemsCompleted)
            {
                parentItem.Completed = true;
            }
            else
            {
                parentItem.Completed = false;
            }   
        }
    }
}
