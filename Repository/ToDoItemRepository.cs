using System;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Data;
using TaskManagerApp.Interfaces;
using TaskManagerApp.Model;

namespace TaskManagerApp.Repository
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly AppDbContext _context;

        public ToDoItemRepository(AppDbContext context)
        {
            _context = context;
        }


        public bool Create(ToDoItem toDoItem)
        {
            _context.Add(toDoItem);
            return Save();
        }

        public bool Delete(ToDoItem toDoItem)
        {
            _context.Remove(toDoItem);
            return Save();
        }

        public async Task<IEnumerable<ToDoItem>> GetAll()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetById(int id)
        {
            return await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Update(ToDoItem toDoItem)
        {
            _context.Update(toDoItem);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

