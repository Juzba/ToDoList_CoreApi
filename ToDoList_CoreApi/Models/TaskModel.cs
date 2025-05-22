using System.ComponentModel.DataAnnotations;

namespace ToDoList_CoreApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")] 
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;














    }
}
