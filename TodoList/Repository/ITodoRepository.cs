using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace TodoList.Repository
{
    interface ITodoRepository
    {
        public List<Todo> GetAll();
        public Todo? GetById(int id);
        public void Update(Todo todo);
        public void Delete(int id);
        public void Add(Todo todo);
    }
}
