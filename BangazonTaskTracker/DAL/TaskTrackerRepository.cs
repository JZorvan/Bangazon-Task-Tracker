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
    }
}
