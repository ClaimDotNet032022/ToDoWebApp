using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp032022.Data.Entities
{
    [DisplayColumn("Name")]
    public class ToDoList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ToDoItem> Items { get; set; } = new List<ToDoItem>();
    }
}
