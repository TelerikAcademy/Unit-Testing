using System;
using Tasker.Models.Contracts;

namespace Tasker.Models
{
    public class Task : ITask
    {
        public Task(string description)
        {
            this.Description = description;
            this.IsDone = false;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
