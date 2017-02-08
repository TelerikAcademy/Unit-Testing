using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasker.Models;
using Tasker.Models.Contracts;

namespace Tasker.Tests.Core.Fakes
{
    internal class FakeTask : ITask
    {
        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime? DueDate
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsDone
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
