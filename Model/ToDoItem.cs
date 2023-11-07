using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.Model
{
	public class ToDoItem
	{
		[Key]
		public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public ToDoStatusEnum Status { get; set; }

		public ToDoItem()
		{
			CreatedDate = DateTime.UtcNow;
			Status = ToDoStatusEnum.Active;
        }
	}
}

