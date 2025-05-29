using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace TodoList.Repository
{
    public class JsonTaskRepository : ITodoRepository
    {
        private List<Todo> _tasks;
        private string _filepath;

        public JsonTaskRepository(string filepath)
        {
            _filepath = filepath;
            if (!File.Exists(_filepath))
            {
                _tasks = new List<Todo>();
                File.WriteAllText(_filepath, "[]");
            }
            else
            {
                var json = File.ReadAllText(_filepath);
                _tasks = JsonSerializer.Deserialize<List<Todo>>(json) ?? new List<Todo>();
            }

        }

        public List<Todo> GetAll()
        {
            return _tasks;
        }               
        
        public Todo GetById(int id)
        {

            int index = _tasks.FindIndex(td => td.Id == id);

            if(index != -1) { return _tasks[index]; }
            else { throw new Exception($"Task with id {id} doesn't exist"); }
        }

        public void Add(Todo todo) {
            int nextId = _tasks.Any() ? _tasks.Max(x => x.Id) + 1 : 1;

            todo.Id = nextId;
            
            _tasks.Add(todo);

            SaveInFile();
        }

        public void Update(Todo todo)
        {
            int index = _tasks.FindIndex(td => td.Id == todo.Id);

            todo.Id = index;

            if (index != -1) {
                _tasks[index] = todo;
                SaveInFile();
            }

            else throw new Exception("The task doens't exist");
        }

        public void Delete(int id)
        {
            int index = _tasks.FindIndex(td => td.Id == id);

            if(index != -1)
            {
                _tasks.RemoveAt(index);
                SaveInFile();
            }
            else
            {
                throw new Exception("The index of the task doesn't exist");
            }
        }

        public void SaveInFile()
        {
            var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, json);
        }
        

    }
}
