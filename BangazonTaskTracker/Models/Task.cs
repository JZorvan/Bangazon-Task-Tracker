using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set;}

        [Required]
        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        [Required]
        public Status TaskStatus { get; set; }

        public DateTime CompletedOn { get; set; }
    }

    public enum Status
    {
        ToDo, InProgress, Complete
    }
}