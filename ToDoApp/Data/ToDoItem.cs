using System.Text.Json.Serialization;
using ToDoApp.Data;

namespace ToDoApp
{
    public class ToDoItem
    {
      
        public ToDoItem(string text)
        {
            Text = text;
        }
        [JsonConstructor]
        public ToDoItem(string text, List<ToDoItem> subItems)
        {
            Text = text;
            SubItems = subItems;
        }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
        [JsonPropertyName("deadline")]
        public DateTime Deadline { get; set; }
        [JsonPropertyName("subItems")]
        public List<ToDoItem> SubItems { get; set; } = new List<ToDoItem> { };
    }
}
