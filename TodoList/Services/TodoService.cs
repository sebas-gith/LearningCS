using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;
using TodoList.Repository;

namespace TodoList.Services
{
    class TodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository) {

            _repository = repository;
        }

        public List<Todo> GetAll() {
            return _repository.GetAll();

        }

        public void Add(Todo todo)
        {
            Todo td = new Todo()
            {
                Title = todo.Title,
                CreatedAt = DateTime.Now,
                IsCompleted = false,
                Description = todo.Description,
                DueDate = todo.DueDate,
            };

            _repository.Add(td);
        }

        public List<Todo> GetCompletedTasks()
        {
            return _repository.GetAll().Where(t => t.IsCompleted).ToList();
        }

        public List<Todo> GetTasksDueToday()
        {
            return _repository.GetAll()
                .Where(t => t.DueDate.Date == DateTime.Today)
                .ToList();
        }

        public Todo SearchByTitle(string title)
        {
            return _repository.GetAll()
                .Where(t => t.Title.Contains(title))
                .First();
        }
        public List<Todo> GetOverDueTasks()
        {
            return _repository.GetAll()
                .Where(t => t.DueDate < DateTime.Today)
                .ToList();
        }
        public void MarkAsCompleted(int id)
        {
            Todo todo = _repository.GetById(id);
            todo.IsCompleted = true;
            _repository.Update(todo);
        }

        public Todo GetById(int id)
        {
            
            return _repository.GetById(id);
        }

        public void Update(Todo todo)
        {
            _repository.Update(todo);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
