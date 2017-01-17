using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BangazonTaskTracker.Models;
using System.Data.Entity;

namespace BangazonTaskTracker.DAL
{
    public class TaskTrackerContext : DbContext
    {
        public virtual DbSet<TaskyTask> Tasks { get; set; }
    }
}