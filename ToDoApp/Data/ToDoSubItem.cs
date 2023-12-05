namespace ToDoApp.Data
{
    public class ToDoSubItem
    {
        public ToDoSubItem(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
        public bool Completed { get; set; }
    }
}
