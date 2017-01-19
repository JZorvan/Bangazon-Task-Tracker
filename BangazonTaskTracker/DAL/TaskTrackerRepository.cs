using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BangazonTaskTracker.Models;

namespace BangazonTaskTracker.DAL
{
    public class TaskTrackerRepository
    {
        public TaskTrackerContext Context { get; set; }
        
        public TaskTrackerRepository()
        {
            Context = new TaskTrackerContext();
        }
        
        public TaskTrackerRepository(TaskTrackerContext _context)
        {
            Context = _context;
        }

        // Get List of Tasks
        public List<TaskyTask> GetTasks()
        {
            return Context.Tasks.ToList();
        }

        // Find a Task by Name
        public TaskyTask FindTaskByName(string name)
        {
            TaskyTask found_task = Context.Tasks.FirstOrDefault(t => t.TaskName.ToLower() == name.ToLower());
            return found_task;
        }

        // Add Task
        public void AddTask(TaskyTask task_to_add)
        {

            if (FindTaskByName(task_to_add.TaskName) == null)
            {
                Context.Tasks.Add(task_to_add);
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("Error! A task named " + task_to_add.TaskName + " already exists.");
            }
        }

        // Delete Task
        public TaskyTask DeleteTask(string name)
        {

            TaskyTask found_task = FindTaskByName(name);
            if (found_task != null)
            {
                Context.Tasks.Remove(found_task);
                Context.SaveChanges();
                return found_task;
            }
            else
            {
                throw new Exception("Error! That task does not exist.");
            }
        }
    }
}
