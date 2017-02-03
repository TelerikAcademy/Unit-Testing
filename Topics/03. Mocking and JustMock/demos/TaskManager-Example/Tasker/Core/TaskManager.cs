using System;
using System.Collections.Generic;
using System.Linq;
using Tasker.Core.Contracts;
using Tasker.Core.Providers;
using Tasker.Models;
using Tasker.Models.Contracts;

namespace Tasker.Core
{
    public class TaskManager : ITaskManager
    {
        private ICollection<ITask> tasks;

        private readonly IIdProvider idProvider;
        private readonly ILogger logger;

        public TaskManager(IIdProvider idProvider, ILogger logger)
        {
            this.tasks = new List<ITask>();

            this.idProvider = idProvider;
            this.logger = logger;
        }

        public IList<ITask> Members()
        {
            return new List<ITask>(this.tasks);
        }

        public void Add(ITask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException();
            }

            task.Id = this.idProvider.NextId();

            this.tasks.Add(task);
            this.logger.Log($"A new task with id {task.Id} was added!");
        }

        public void Remove(int id)
        {
            var task = this.tasks.SingleOrDefault(x => x.Id == id);

            if (task == null)
            {
                this.logger.Log($"Task with ID {id} was not found!");
            }
            else
            {
                this.tasks.Remove(task);
                this.logger.Log($"The task with ID {id} was removed.");
            }
        }
    }
}
