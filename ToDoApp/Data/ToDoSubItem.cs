﻿using System.Text.Json.Serialization;

namespace ToDoApp.Data
{
    public class ToDoSubItem
    {
        [JsonConstructor]
        public ToDoSubItem(ToDoItem parentTodo, ToDoItem childTodo)
        {
            ParentTodo = parentTodo;
            ChildTodo = childTodo;
        }
        [JsonPropertyName("parentTodo")]
        public ToDoItem ParentTodo { get; set; }
        [JsonPropertyName("childTodo")]
        public ToDoItem ChildTodo { get; set; }
    }
}
