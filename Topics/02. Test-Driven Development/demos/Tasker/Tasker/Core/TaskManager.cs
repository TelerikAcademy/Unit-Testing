using System;
using System.Collections.Generic;
using Tasker.Core.Contracts;
using Tasker.Models.Contracts;

namespace Tasker.Core
{
    public class TaskManager
    {
        private readonly IIdProvider idProvider;
        private readonly ILogger logger;
        
        public TaskManager(IIdProvider provider, ILogger logger)
        {
            if (provider == null)
            {
                throw new ArgumentNullException();
            }

            if (logger == null)
            {
                throw new ArgumentNullException();
            }

            this.idProvider = provider;
            this.logger = logger;

            this.Tasks = new List<ITask>();
        }

        protected ICollection<ITask> Tasks { get; private set; }

        public void Add(ITask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException();
            }

            task.Id = this.idProvider.NextId();
            this.Tasks.Add(task);
            this.logger.Log("Task added successfuly!");
        }
    }
}
