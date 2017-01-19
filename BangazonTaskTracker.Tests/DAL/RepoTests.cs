using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BangazonTaskTracker.Models;
using BangazonTaskTracker.DAL;
using System.Data.Entity;


namespace BangazonTaskTracker.Tests.DAL
{
    [TestClass]
    public class RepoTests
    {
        private Mock<DbSet<TaskyTask>> mock_tasks { get; set; }

        private List<TaskyTask> Tasks { get; set; }

        private Mock<TaskTrackerContext> mock_context { get; set; }
        private TaskTrackerRepository repo { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_tasks = new Mock<DbSet<TaskyTask>>();

            Tasks = new List<TaskyTask>();

            mock_context = new Mock<TaskTrackerContext>() { CallBase = true };
            repo = new TaskTrackerRepository(mock_context.Object);

            ConnectToDatastore();
        }

        public void ConnectToDatastore()
        {
            var query_tasks = Tasks.AsQueryable();

            mock_tasks.As<IQueryable<TaskyTask>>().Setup(m => m.Provider).Returns(query_tasks.Provider);
            mock_tasks.As<IQueryable<TaskyTask>>().Setup(m => m.Expression).Returns(query_tasks.Expression);
            mock_tasks.As<IQueryable<TaskyTask>>().Setup(m => m.ElementType).Returns(query_tasks.ElementType);
            mock_tasks.As<IQueryable<TaskyTask>>().Setup(m => m.GetEnumerator()).Returns(() => query_tasks.GetEnumerator());

            mock_context.Setup(c => c.Tasks).Returns(mock_tasks.Object);
            mock_tasks.Setup(u => u.Add(It.IsAny<TaskyTask>())).Callback((TaskyTask t) => Tasks.Add(t));
            mock_tasks.Setup(u => u.Remove(It.IsAny<TaskyTask>())).Callback((TaskyTask t) => Tasks.Remove(t));
        }

        public void ImportMockData()
        {
            // Generates Tasks to test
            TaskyTask task1 = new TaskyTask
            {
                TaskId = 1,
                TaskName = "Vacuum Cat",
                TaskDescription = "Vacuum Cat using maximum suction and brush attachment.",
                TaskStatus = Status.ToDo
            };

            TaskyTask task2 = new TaskyTask
            {
                TaskId = 2,
                TaskName = "Mop Ceiling",
                TaskDescription = "Ceiling needs to be thoroughly mopped with bleach.",
                TaskStatus = Status.Complete,
                CompletedOn = DateTime.Now
            };

            Tasks.Add(task1);
            Tasks.Add(task2);
        }

        [TestMethod]
        public void CanInstantiateRepo()
        {
            Assert.IsNotNull(repo);
        }


    }
}
