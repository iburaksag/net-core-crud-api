using TaskManagerApp.Model;

namespace TaskManagerApp.Interfaces
{
	public interface IToDoItemRepository 
    {
        Task<IEnumerable<ToDoItem>> GetAll();
        Task<ToDoItem> GetById(int id);
        bool Create(ToDoItem toDoItem);
        bool Update(ToDoItem toDoItem);
        bool Delete(ToDoItem toDoItem);
        bool Save();
    }
}

