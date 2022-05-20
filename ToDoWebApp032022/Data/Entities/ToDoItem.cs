namespace ToDoWebApp032022.Data.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentListId { get; set; }

        public ToDoList ParentList { get; set; }
    }
}
