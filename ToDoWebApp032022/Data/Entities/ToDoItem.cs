
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoWebApp032022.Data.Entities
{
    
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Completed?")]
        public bool IsComplete { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTimeOffset? DueDate { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 1_000_000)]
        public double Cost { get; set; }

        [Display(Name = "Parent List")]
        [ForeignKey(nameof(ParentList))]
        public int ParentListId { get; set; }

        [Display(Name = "Parent List")]
        public ToDoList? ParentList { get; set; }

        [NotMapped]
        public bool IsOverdue
        {
            get
            {
                return DueDate != null && DueDate < DateTimeOffset.UtcNow && !IsComplete;
            }
        }
    }
}
