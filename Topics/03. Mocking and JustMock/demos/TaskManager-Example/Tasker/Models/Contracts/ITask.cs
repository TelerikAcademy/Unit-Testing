using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Models.Contracts
{
    public interface ITask
    {
        int Id { get; set; }

        string Description { get; set; }

        bool IsDone { get; set; }

        DateTime? DueDate { get; set; }
    }
}
