using System.Diagnostics.Metrics;
using TaskManagerApp;
using TaskManagerApp.Data;
using TaskManagerApp.Model;

namespace TaskManagerApp
{
    public class Seed
    {
        private readonly AppDbContext dataContext;
        public Seed(AppDbContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            var toDoItems = new List<ToDoItem>()
            {
                new ToDoItem {
                    Title = "Working on REST API",
                    Description = "Gonna work on REST API and finish the course",
                    Status = ToDoStatusEnum.Active },

                new ToDoItem {
                    Title = "Working on ASP.NET MVC",
                    Description = "Gonna work on MVC",
                    Status = ToDoStatusEnum.Postponed },

                new ToDoItem {
                    Title = "Minimal API",
                    Description = "MinimalAPI and finish the course",
                    Status = ToDoStatusEnum.Active },

                new ToDoItem {
                    Title = "Watch BJK MATCH",
                    Description = "Dont lose!",
                    Status = ToDoStatusEnum.Active },
            };

                dataContext.AddRange(toDoItems);
                dataContext.SaveChanges();
        }
    }
}