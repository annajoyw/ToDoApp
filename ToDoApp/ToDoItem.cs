namespace ToDoApp
{
    public class ToDoItem
    {
        public ToDoItem(string text)
        {
            Text = text;
        }

        public ToDoItem(string text, List<ToDoItem> subItems)
        {
            Text = text;
            SubItems = subItems;
        }

        public string Text { get; set; }
        public bool Completed { get; set; }
        public List<ToDoItem> SubItems { get; set; } = new List<ToDoItem> { };
    }
}
